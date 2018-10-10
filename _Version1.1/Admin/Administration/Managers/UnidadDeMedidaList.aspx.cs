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

public partial class UnidadDeMedidaList : System.Web.UI.Page
{
    NutrienteBus busNutrientes = new NutrienteBus();
    NutrienteEntityFilter filterNutrientes = new NutrienteEntityFilter();

    UnidadMedidaBus bus = new UnidadMedidaBus();
    UnidadMedidaEntityFilter filter = new UnidadMedidaEntityFilter();
    UnidadMedidaEntityInsert insert = new UnidadMedidaEntityInsert();
    UnidadMedidaEntityKey key = new UnidadMedidaEntityKey();

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

        Menu1.nameSelectedOption = "GOTO_UNIDADDEMEDIDAS_LIST";

        filter.OrderBy = "Nombre";
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

    #region Elimino el Unidad de Medida
    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ItemCommand_lvGeneric(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            string UnidadMedidaId = e.CommandArgument.ToString();

            if (e.CommandName.ToString().ToUpper() == "ELIMINAR")
            {
                //-- Si existe la relacion de al menos un registro, 
                //-- NO SE PUEDE ELIMINAR EL TIPO DE ALIMENTO
                //--------------------------------------------------
                filterNutrientes.OpeUDMId = Helpers.Operators.Operadores_VarChar.Igual;
                filterNutrientes.UDMId = UnidadMedidaId;
                DataTable dtControl = busNutrientes.Search(filterNutrientes);
                if (dtControl != null && dtControl.Rows.Count > 0)
                {
                    ltrMessage.Text = "<span style='color:red;'>No es posible eliminar la Unidad de Medida ya que tiene Nutrientes asignados!</span>";
                    ltrMessage.Visible = true;
                    return;
                }

                //-- Elimino el Tipo de Alimento
                //--------------------------------------------------
                key.UDMId = UnidadMedidaId;
                bus.Delete(key);
                lvGeneric.DataBind();

                ltrMessage.Text = "<span style='color:red;'>Unidad de Medida eliminada correctamente!</span>";
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
    protected void odsUnidadDeMedida_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["EntityFilter"] = filter;
    }
    #endregion
}
