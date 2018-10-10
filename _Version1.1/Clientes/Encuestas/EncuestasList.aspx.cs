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


public partial class Clientes_Encuestas_EncuestasList : System.Web.UI.Page
{


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

        //-- Filtro las encuestas del usuario logueado.
        //-----------------------------------------------
        ViewState_vEncuestaHeaderEntityFilter.OrderBy = "EncuestaNro";
        ViewState_vEncuestaHeaderEntityFilter.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
        ViewState_vEncuestaHeaderEntityFilter.UserId = MyUsers.GetLoggedUserId();
        Menu1.nameSelectedOption = "GOTO_ENCUESTASLIST";
    }

    #region ODS
    protected void odsEncuestas_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["EntityFilter"] = ViewState_vEncuestaHeaderEntityFilter;
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

    #region Elimino ENCUESTA
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
                Int32 encuestaNro = int.Parse("0" + e.CommandArgument.ToString().Trim());

                EncuestaAlimentariaBus bus = new EncuestaAlimentariaBus();
                EncuestaAlimentariaEntityKey key = new EncuestaAlimentariaEntityKey();
                key.EncuestaNro = encuestaNro;
                bus.Delete(key);
                ltrMessage.Text = string.Format("<span style='color:green;'>La Encuesta NRO {0} fue Eliminada!</span>", encuestaNro);
                ltrMessage.Visible = true;
                lvGeneric.DataBind();
            }
        }
        catch (Exception ex)
        {
            ltrMessage.Text = "<span style='color:red;'>Oooops, ocurrió un Error!!!</span>";
            ltrMessage.Visible = true;
            Logger.LogExceptionStatic(ex);
        }
    }
    #endregion

    protected void lnkNuevaDieta_Click(object sender, EventArgs e)
    {
        CustomBus busCustom = new CustomBus();
        EncuestaAlimentariaBus busEncuesta = new EncuestaAlimentariaBus();
        EncuestaAlimentariaEntityInsert insertEncuesta = new EncuestaAlimentariaEntityInsert();
        EncuestaAlimentariaEntityFilter filter = new EncuestaAlimentariaEntityFilter();

        vExtendedPropertiesBus busEp = new vExtendedPropertiesBus();
        vExtendedPropertiesEntityFilter filterEp = new vExtendedPropertiesEntityFilter();

        //-- Obtengo la cantidad de encuestas configuradas
        //-----------------------------------------------------
        filterEp.OpeUserName = Helpers.Operators.Operadores_NVarChar.Igual;
        filterEp.UserName = Page.User.Identity.Name;
        DataTable dtEp = busEp.Search(filterEp);
        if (dtEp != null && dtEp.Rows.Count > 0)
        {
            Int32 limiteDeEncuestas = int.Parse("0" + dtEp.Rows[0]["LimiteDeEncuestas"].ToString());

            MembershipUser oUser = Membership.GetUser(Page.User.Identity.Name);
            if (oUser != null)
            {
                filter.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
                filter.UserId = new Guid(oUser.ProviderUserKey.ToString());
                DataTable dtEncuesta = busEncuesta.SearchCount(filter);
                if (dtEncuesta != null && dtEncuesta.Rows.Count > 0)
                {
                    Int32 cantidadDeEncuestas = int.Parse("0" + dtEncuesta.Rows[0]["Column1"].ToString());
                    if (cantidadDeEncuestas >= limiteDeEncuestas)
                    {
                        ltrMessage.Text = "<div style='background-color:#ffebe8;color:black;padding:5px;border:solid 1px #dd3c10;font-family:\"lucida grande\",tahoma;'><b>ATENCION</b>: Usted ha llegado al límite de encuestas. Para agregar una encuesta nueva, elimine una previamente creada o bien pida al Administrador del Sistema que amplíe su <b>Limite de Encuestas</b> !!!</div>";
                        ltrMessage.Visible = true;
                        return;
                    }
                    else
                    {
                        //-- INSERTO ENCUESTA VACIA
                        //-------------------------------------------------------------------
                        insertEncuesta.UserId = MyUsers.GetLoggedUserId();
                        Int32 encuestaNro = busEncuesta.Insert_Return_Scalar(insertEncuesta);
                        if (encuestaNro > 0)
                        {
                            busCustom.InsertarAlimentos(encuestaNro);
                            Response.Redirect(string.Format("EncuestasAdd.aspx?EncuestaNro={0}", encuestaNro));
                        }
                    }
                }
            }
        }
    }
}
