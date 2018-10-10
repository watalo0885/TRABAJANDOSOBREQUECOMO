using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Helpers.Logger;
using Interfood.Business;
using Interfood.Entities;
using System.Configuration;
using System.Text;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Admin_Administration_Managers_AlimentoNutriente : System.Web.UI.Page
{
    vAlimentoNutrienteBus busAlimentoNutriente = new vAlimentoNutrienteBus();
    vAlimentoNutrienteEntityFilter filterAlimentoNutriente = new vAlimentoNutrienteEntityFilter();
    vAlimentoNutrienteEntityFilter filterNutrienteCbo = new vAlimentoNutrienteEntityFilter();
    

    AlimentoEntityFilter filterAlimento = new AlimentoEntityFilter();

    AlimentoNutrienteBus busAN = new AlimentoNutrienteBus();
    AlimentoNutrienteEntityKey keyAN = new AlimentoNutrienteEntityKey();
    AlimentoNutrienteEntityFilter filterAN = new AlimentoNutrienteEntityFilter();
    AlimentoNutrienteEntityUpdate updateAN = new AlimentoNutrienteEntityUpdate();
    AlimentoNutrienteEntityInsert insertAN = new AlimentoNutrienteEntityInsert();

    EncuestaAliNutBus busEncAliNut = new EncuestaAliNutBus();
    EncuestaAliNutEntityFilter filterEncAliNut = new EncuestaAliNutEntityFilter();
    EncuestaAliNutEntityKey keyEncAliNut = new EncuestaAliNutEntityKey();

    #region Button Refresh
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        lvGeneric.DataBind();
    }
    #endregion

    #region PageSize - ChangeCantRows
    protected bool _hasProcessedHeaderMain = false;

    public int PageSize
    {
        get
        {
            if (ViewState["PageSize"] == null)
                ViewState["PageSize"] = ConfigurationManager.AppSettings["PagerPageSize"].ToString();
            return int.Parse(ViewState["PageSize"].ToString());
        }
        set { ViewState["PageSize"] = value; }
    }

    protected void ChangeCantRows(object sender, EventArgs e)
    {
        if (lvGeneric.FindControl("pagerBottom") != null)
        {
            PageSize = int.Parse(((DropDownList)sender).SelectedValue);
            ((DataPager)lvGeneric.FindControl("pagerBottom")).PageSize = PageSize;

            DataTable dtAlimentoNutriente = busAlimentoNutriente.Search(filterAlimentoNutriente);
            lvGeneric.DataSource = dtAlimentoNutriente;
            lvGeneric.DataBind();
        }
    }

    protected void ChangeCantRowsNutrientes(object sender, EventArgs e)
    {
        if (lvAddNutrientes.FindControl("pagerBottom") != null)
        {
            PageSize = int.Parse(((DropDownList)sender).SelectedValue);
            ((DataPager)lvAddNutrientes.FindControl("pagerBottom")).PageSize = PageSize;

            BindearAddNutrientes();
        }
    }
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        divBtnAddNutrientes.Visible = false;
        btnAgregarNutrientes.Visible = false;
        ltrMessage.Visible = false;
        filterAlimento.OrderBy = "Nombre asc";

        #region JQuery
        StringBuilder refresh = new StringBuilder("function Refresh() { document.getElementById('{0}').click(); } ");
        refresh.Replace("{0}", btnRefresh.ClientID);
        refresh.Append("function pageLoad(sender, args) { if (args.get_isPartialLoad()) { tb_init('a.thickbox'); } } ");
        refresh.Append("function updated() { tb_remove(); } ");
        ScriptManager.RegisterStartupScript(Page, GetType(), "refresh", refresh.ToString(), true);
        #endregion

        if (!IsPostBack)
        {
            PageSize = 20;
            if (lvGeneric.FindControl("pagerBottom") != null)
            {
                ((DataPager)lvGeneric.FindControl("pagerBottom")).PageSize = PageSize;
                ((DropDownList)lvGeneric.FindControl("cboPageSize")).SelectedValue = PageSize.ToString();
            }
        }

        if (cboAlimentos.SelectedValue == "0")
        {
            lvGeneric.Visible = false;
            btnGrabar.Visible = false;
        }
        else
        {
            lvGeneric.Visible = true;
            btnGrabar.Visible = true;
        }

        //-- Filtro los nutrientes del Alimento Seleccionado en el Combo
        //---------------------------------------------------------------------------
        filterAlimentoNutriente.OpeAlimentoId = Helpers.Operators.Operadores_Int.Igual;
        filterAlimentoNutriente.AlimentoId = int.Parse("0" + cboAlimentos.SelectedValue.Trim());
        filterAlimentoNutriente.OrderBy = "NutrienteNombre asc";

        Menu1.nameSelectedOption = "GOTO_NUTRIENTES_POR_ALIMENTOS_LIST";
    }

    #region ItemDataBound_lvGeneric
    /// <summary>
    /// Cambio la clase para mostrar el orden.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    protected void ItemDataBound_lvGeneric(object sender, ListViewItemEventArgs args)
    {
        ListView listView = (ListView)sender;

        //----------------------------------------------------
        //-- 1 - Actualizo la URL del link para MapQuest
        //-- 2 - Veo si muestro o no la LUPA
        //----------------------------------------------------
        if (args.Item.ItemType == ListViewItemType.DataItem && args.Item != null)
        {
            //--------------------------------------------------------------
            //-- Creo el objeto que tiene los datos de la ROW del Listview
            //--------------------------------------------------------------
            ListViewDataItem dataItem = (ListViewDataItem)args.Item;
            DataRowView rowView = (DataRowView)dataItem.DataItem;

        }

        //--------------------------------------------------------------
        //  Se dio clik en un HEADER para ordenar
        //--------------------------------------------------------------
        if (listView.SortExpression.Length > 0)
        {
            //  if this is the first time ItemDataBound has fired, figure out what column
            //  is being sorted by
            if (!this._hasProcessedHeaderMain)
            {
                //-- Creo una referencia a la primera ROW = HEADERS de la 
                //-- TABLA que se definio en el LAYOUT TEMPLATE !!!       
                HtmlTableRow header = ((HtmlTable)listView.FindControl("tbGeneric")).Rows[0];

                //  Busco el LINKBUTTON que contenga en su CommandArgument el mismo 
                //  valor que el SortExpression del ListView                        
                for (int i = 0; i < header.Cells.Count; i++)
                {
                    //-- Objeto Celda                  
                    HtmlTableCell th = header.Cells[i];

                    //  Busco el LINKBUTTON dentro de los 
                    //  Controles de la Celda             
                    foreach (Control c in th.Controls)
                    {
                        LinkButton linkButton = c as LinkButton;

                        if (linkButton != null)
                        {
                            string originalHeaderStyle = th.Attributes["class"] ?? string.Empty;
                            //  make sure the header doesn't have the sortasc or sortdesc classes
                            th.Attributes["class"] =
                                originalHeaderStyle.Replace("sortasc", string.Empty).Replace("sortdesc", string.Empty).Trim();

                            if (linkButton.CommandArgument == listView.SortExpression)
                            {
                                //  add the sort class to this item                        
                                th.Attributes["class"] =
                                    string.Format("{0} {1}", th.Attributes["class"] ?? string.Empty, listView.SortDirection == SortDirection.Ascending ? "sortasc" : "sortdesc").Trim();
                            }
                        }
                    }
                }

                this._hasProcessedHeaderMain = true;
            }
        }
    }
    #endregion

    #region Elimino el ALIMENTO
    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ItemCommand_lvGeneric(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString().ToUpper() == "ELIMINAR")
            {
                //-- Busco el ALIMENTO y el NUTRIENTE para ver si existe en algunas ENCUESTAS
                //----------------------------------------------------------------------------
                filterEncAliNut.OpeAlimentoId = Helpers.Operators.Operadores_Int.Igual;
                filterEncAliNut.AlimentoId = int.Parse("0" + cboAlimentos.SelectedValue);
                filterEncAliNut.OpeNutrienteId = Helpers.Operators.Operadores_Int.Igual;
                filterEncAliNut.NutrienteId = int.Parse("0" + e.CommandArgument.ToString());

                DataTable dtEAN = busEncAliNut.Search(filterEncAliNut);
                if (dtEAN != null && dtEAN.Rows.Count > 0)
                {
                    ltrMessage.Visible = true;
                    ltrMessage.Text = "<span style='color:#8b0000;padding:5px;'><b>El Nutriente no puede eliminarse. Ya se utilizó en algunas Encuestas.</b></span>";
                }
                else
                {
                    //-- No existe en ninguna ENCUESTA entonces lo ELIMINO !!!
                    //----------------------------------------------------------
                    keyAN.AlimentoId = int.Parse("0" + cboAlimentos.SelectedValue);
                    keyAN.NutrienteId = int.Parse("0" + e.CommandArgument.ToString());
                    busAN.Delete(keyAN);

                    ltrMessage.Visible = true;
                    ltrMessage.Text = "<span style='color:#6b8e23;padding:5px;'><b>Nutriente Eliminado!</b></span>";
                    BindearListView();
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogExceptionStatic(ex);
        }
    }
    #endregion

    #region ODS
    protected void odsAlimentos_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["EntityFilter"] = filterAlimento;
    }
    #endregion

    #region Grabar
    protected void Grabar(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < lvGeneric.Items.Count; i++)
            {
                keyAN.AlimentoId = int.Parse("0" + cboAlimentos.SelectedValue.Trim());
                keyAN.NutrienteId = int.Parse("0" + ((TextBox)((HtmlTableRow)lvGeneric.Items[i].Controls[1]).Cells[2].FindControl("txtNutrienteId")).Text.Trim());

                updateAN.Cantidad = decimal.Parse("0" + ((TextBox)((HtmlTableRow)lvGeneric.Items[i].Controls[1]).Cells[2].FindControl("txtCantidad")).Text.Trim());

                busAN.Update(keyAN, updateAN);

                ltrMessage.Text = "<span style='color:green;'>Nutriente/s grabados correctamente!</span>";
                ltrMessage.Visible = true;
                btnGrabar.Visible = true;

                btnAgregarNutrientes.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Logger.LogExceptionStatic(ex);
            ltrMessage.Text = string.Format("<span style='color:red;'>Oooops, ocurrió un error. Descripción: {0}</span>", ex.Message);
            ltrMessage.Visible = true;
        }
    }
    #endregion

    #region Selecciono ALIMENTO - CBO
    protected void cboAlimentos_SelectedIndexChanged(object sender, EventArgs e)
    {
        //-- Filtro los nutrientes del Alimento Seleccionado para el Combo NUTRIENTES
        //---------------------------------------------------------------------------
        filterNutrienteCbo.OpeAlimentoId = Helpers.Operators.Operadores_Int.Igual;
        filterNutrienteCbo.AlimentoId = int.Parse("0" + cboAlimentos.SelectedValue.Trim());
        filterNutrienteCbo.OrderBy = "NutrienteNombre asc";
        DataTable dtNutrienteCbo = busAlimentoNutriente.Search(filterNutrienteCbo);
        cboNutrientes.Items.Clear();
        cboNutrientes.Items.Add(new ListItem("-- Ver todos los Nutrientes --", "0"));
        cboNutrientes.DataTextField = "NutrienteNombre";
        cboNutrientes.DataValueField = "NutrienteId";
        cboNutrientes.DataSource = dtNutrienteCbo;
        cboNutrientes.DataBind();

        BindearListView();
        divAddNutrientes.Visible = false;
        btnAgregarNutrientes.Visible = true;
    }
    #endregion

    #region Selecciono NUTRIENTE - CBO
    protected void cboNutrientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)sender).SelectedValue != "0")
        {
            filterAlimentoNutriente.OpeNutrienteId = Helpers.Operators.Operadores_Int.Igual;
            filterAlimentoNutriente.NutrienteId = int.Parse("0" + ((DropDownList)sender).SelectedValue);
        }
        BindearListView();
        divAddNutrientes.Visible = false;
        btnAgregarNutrientes.Visible = true;
    }
    #endregion


    #region Selecciono FUENTE - CBO
    protected void cboFuentes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (((DropDownList)sender).SelectedValue != "0")
        {
            filterAlimentoNutriente.OpeNutrienteId = Helpers.Operators.Operadores_Int.Igual;
            filterAlimentoNutriente.NutrienteId = int.Parse("0" + ((DropDownList)sender).SelectedValue);
        }
        BindearListView();
        divAddNutrientes.Visible = false;
        btnAgregarNutrientes.Visible = true;
    }
    #endregion

    #region PagePropertiesChanged
    protected void lvGeneric_PagePropertiesChanged(object sender, EventArgs e)
    {
        BindearListView();
    }
    #endregion

    #region BindearListView
    private void BindearListView()
    {
        DataTable dtAlimentoNutriente = busAlimentoNutriente.Search(filterAlimentoNutriente);
        lvGeneric.DataSource = dtAlimentoNutriente;
        lvGeneric.DataBind();
        btnGrabar.Visible = true;

    }
    #endregion

    protected void lnkAddNutriente_Click(object sender, EventArgs e)
    {
        BindearAddNutrientes();
        lnkBtnAddNutrientes.Focus();
    }

    protected void Filtrar(object sender, EventArgs e)
    {
        txtFiltro.Text = ((Button)sender).Text.Trim();
        if (txtFiltro.Text.ToUpper() == "Ver Todos".Trim().ToUpper()) txtFiltro.Text = "";
        BindearAddNutrientes();
    }

    private void FiltrarNutrientes(string textButton)
    {
        txtFiltro.Text = textButton;
        BindearAddNutrientes();       
    }

    private void BindearAddNutrientes()
    {
        vAlimentoNutrienteParaAgregarBus bus = new vAlimentoNutrienteParaAgregarBus();
        vAlimentoNutrienteParaAgregarEntityFilter filter = new vAlimentoNutrienteParaAgregarEntityFilter();

        filter.Clear();
        filter.OrderBy = "NutrienteNombre";
        filter.OpeAlimentoId = Helpers.Operators.Operadores_Int.Igual;
        filter.AlimentoId = int.Parse("0" + cboAlimentos.SelectedValue);
        if (!string.IsNullOrEmpty(txtFiltro.Text))
        {
            filter.OpeNutrienteNombre = Helpers.Operators.Operadores_VarChar.QueComienceCon;
            filter.NutrienteNombre = txtFiltro.Text.Trim();
        }
        DataTable dtAddNutrientes = bus.Search(filter);
        lvAddNutrientes.DataSource = dtAddNutrientes;
        lvAddNutrientes.DataBind();

        divAddNutrientes.Visible = true;
        btnAgregarNutrientes.Visible = true;
        divBtnAddNutrientes.Visible = true;
    }

    #region PagePropertiesChanged
    protected void lvAddNutrientes_PagePropertiesChanged(object sender, EventArgs e)
    {
        BindearAddNutrientes();
    }
    #endregion

    #region AgregarNutrientes
    protected void AgregarNutrientes(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < lvAddNutrientes.Items.Count; i++)
            {
                insertAN.Cantidad = decimal.Parse("0" + ((TextBox)((HtmlTableRow)lvAddNutrientes.Items[i].Controls[1]).Cells[1].FindControl("txtCantidad")).Text.Trim());

                if (insertAN.Cantidad > 0)
                {
                    insertAN.AlimentoId = int.Parse("0" + cboAlimentos.SelectedValue.Trim());
                    insertAN.NutrienteId = int.Parse("0" + ((TextBox)((HtmlTableRow)lvAddNutrientes.Items[i].Controls[1]).Cells[1].FindControl("txtNutrienteId")).Text.Trim());
                    busAN.Insert(insertAN);
                }
            }

            ltrMessage.Text = "<span style='color:green;'>Nutriente/s agregados correctamente!</span>";
            ltrMessage.Visible = true;

            BindearListView();
            BindearAddNutrientes();
        }
        catch (Exception ex)
        {
            Logger.LogExceptionStatic(ex);
            ltrMessage.Text = string.Format("<span style='color:red;'>Oooops, ocurrió un error. Descripción: {0}</span>", ex.Message);
            ltrMessage.Visible = true;
        }
    }
    #endregion
}
