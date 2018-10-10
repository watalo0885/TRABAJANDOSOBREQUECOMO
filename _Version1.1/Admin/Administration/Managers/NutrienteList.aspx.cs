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

public partial class NutrinteList : System.Web.UI.Page
{
    NutrienteBus busNutriente = new NutrienteBus();
    NutrienteEntityFilter filterNutriente = new NutrienteEntityFilter();
    NutrienteEntityInsert insertNutriente = new NutrienteEntityInsert();
    NutrienteEntityKey keyNutriente = new NutrienteEntityKey();
    NutrienteEntityUpdate updateNutriente = new NutrienteEntityUpdate();

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
        PageSize = int.Parse(((DropDownList)sender).SelectedValue);
        ((DataPager)lvGeneric.FindControl("pagerBottom")).PageSize = PageSize;
    }
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {
        ltrMessage.Visible = false;

        if (!IsPostBack)
        {
            if (lvGeneric.Items.Count > 0)
            {
                ((DataPager)lvGeneric.FindControl("pagerBottom")).PageSize = PageSize;
                ((DropDownList)lvGeneric.FindControl("cboPageSize")).SelectedValue = PageSize.ToString();
            }
        }

        StringBuilder refresh = new StringBuilder("function Refresh() { document.getElementById('{0}').click(); } ");
        refresh.Replace("{0}", btnRefresh.ClientID);
        refresh.Append("function pageLoad(sender, args) { if (args.get_isPartialLoad()) { tb_init('a.thickbox'); } } ");
        refresh.Append("function updated() { tb_remove(); } ");
        ScriptManager.RegisterStartupScript(Page, GetType(), "refresh", refresh.ToString(), true);

        Menu1.nameSelectedOption = "GOTO_NUTRIENTE_LIST";

        filterNutriente.OrderBy = "Nombre asc";
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

            if (rowView["Estado"].ToString().Trim() == "ACT")
                ((HtmlImage)dataItem.FindControl("imgActivo")).Visible = true;
            else
                ((HtmlImage)dataItem.FindControl("imgInactivo")).Visible = true;
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

    #region Elimino el NUTRIENTE
    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ItemCommand_lvGeneric(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            String[] arguments = e.CommandArgument.ToString().Split('|');

            Int32 nutrienteId = int.Parse("0" + arguments[0]);
            string nutriente = arguments[1];

            if (e.CommandName.ToString().ToUpper() == "ELIMINAR")
            {
                //-- Si existe la relacion de al menos un registro, 
                //-- NO SE PUEDE ELIMINAR EL NUTRIENTE
                //--------------------------------------------------
                AlimentoNutrienteBus busAliNutriente = new AlimentoNutrienteBus();
                AlimentoNutrienteEntityFilter filterAliNutriente = new AlimentoNutrienteEntityFilter();
                filterAliNutriente.OpeNutrienteId = Helpers.Operators.Operadores_Int.Igual;
                filterAliNutriente.NutrienteId = nutrienteId;
                DataTable dtControl = busAliNutriente.Search(filterAliNutriente);
                if (dtControl != null && dtControl.Rows.Count > 0)
                {
                    ltrMessage.Text = string.Format("<span style='color:red;'>No es posible eliminar el Nutriente [<b>{0}</b>] ya que tiene Alimentos asignados!</span>", nutriente);
                    ltrMessage.Visible = true;
                    return;
                }

                //-- Elimino el nutriente
                //--------------------------------------------------
                keyNutriente.NutrienteId = nutrienteId;
                busNutriente.Delete(keyNutriente);
                lvGeneric.DataBind();

                ltrMessage.Text = string.Format("<span style='color:red;'>El nutriente [<b>{0}</b>] fue Eliminado!</span>", nutriente);
                ltrMessage.Visible = true;

            }
        }
        catch (Exception ex)
        {
            Logger.LogExceptionStatic(ex);
        }
    }
    #endregion

    #region ODS
    protected void odsNutrientes_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["EntityFilter"] = filterNutriente;
    }
    #endregion

    protected void Filtrar_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Filtrar(btn.CommandName.Trim().ToUpper());
    }

    private void Filtrar(string command)
    {
        filterNutriente.Clear();

        switch (command)
        {
            case "BUSCAR":
                filterNutriente.OpeNombre = Helpers.Operators.Operadores_VarChar.QueContengaA;
                filterNutriente.Nombre = txtSearchNutriente.Text.Trim();
                break;
            case "TODOS":
                txtSearchNutriente.Text = "";
                break;
            default:
                break;
        }

        filterNutriente.OrderBy = "Nombre asc";
        lvGeneric.DataBind();
    }
}
