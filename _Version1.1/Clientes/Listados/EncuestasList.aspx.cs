using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Interfood.Business;
using Interfood.Entities;
using Chenso.Utilities.Common;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using Helpers.Logger;
using System.Web.Security;
using System.Text;
using System.IO;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Owc11;


public partial class Clientes_Encuestas_EncuestasList : System.Web.UI.Page
{
    Int32 encuestaNro = 0;


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
        //-- Filtro las encuestas del usuario logueado.
        //-----------------------------------------------
        ViewState_vEncuestaHeaderEntityFilter.OrderBy = "EncuestaNro";
        ViewState_vEncuestaHeaderEntityFilter.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
        ViewState_vEncuestaHeaderEntityFilter.UserId = MyUsers.GetLoggedUserId();
        Menu1.nameSelectedOption = "GOTO_ALIMENTOS_POR_ENCUESTAS";
    }

    #region ODS
    protected void odsEncuestas_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["EntityFilter"] = ViewState_vEncuestaHeaderEntityFilter;
    }
    protected void odsEncuestas_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        DataTable dt = e.ReturnValue as DataTable;
        if (dt != null && dt.Rows.Count <= 0)
            AllExport.Visible = false;
    }

    #endregion

    #region ViewState_vEncuestaHeaderEntityFilter
    public vEncuestaHeaderEntityFilter ViewState_vEncuestaHeaderEntityFilter
    {
        get
        {
            if (ViewState["ViewState_vEncuestaHeaderEntityFilter"] == null) ViewState["ViewState_vEncuestaHeaderEntityFilter"] = new vEncuestaHeaderEntityFilter();
            return (vEncuestaHeaderEntityFilter)ViewState["ViewState_vEncuestaHeaderEntityFilter"];
        }
        set
        {
            if (ViewState["ViewState_vEncuestaHeaderEntityFilter"] == null)
                ViewState["ViewState_vEncuestaHeaderEntityFilter"] = value;
        }
    }
    #endregion

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

            HtmlImage ImgXlsAlimentos = ((HtmlImage)dataItem.FindControl("ImgXlsAlimentos"));
            string pagina = string.Format("GenerarXls.aspx?EncuestaNro={0}&Listado=1", rowView["EncuestaNro"].ToString());
            string onClick = string.Format("window.open('{0}');return false;", Chenso.Utilities.Common.MySite.GetFullSiteName_FromAppConfig() + pagina);
            ImgXlsAlimentos.Attributes.Add("onClick", onClick);

            HtmlImage ImgXlsNutrientes = ((HtmlImage)dataItem.FindControl("ImgXlsNutrientes"));
            pagina = string.Format("GenerarXls.aspx?EncuestaNro={0}&Listado=2", rowView["EncuestaNro"].ToString());
            onClick = string.Format("window.open('{0}');return false;", Chenso.Utilities.Common.MySite.GetFullSiteName_FromAppConfig() + pagina);
            ImgXlsNutrientes.Attributes.Add("onClick", onClick);

            HtmlImage ImgXlsNutrientesPorAlimentos = ((HtmlImage)dataItem.FindControl("ImgXlsNutrientesPorAlimentos"));
            pagina = string.Format("GenerarXls.aspx?EncuestaNro={0}&Listado=3", rowView["EncuestaNro"].ToString());
            onClick = string.Format("window.open('{0}');return false;", Chenso.Utilities.Common.MySite.GetFullSiteName_FromAppConfig() + pagina);
            ImgXlsNutrientesPorAlimentos.Attributes.Add("onClick", onClick);

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

}
