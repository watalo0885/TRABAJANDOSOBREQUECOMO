using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Interfood.Entities;
using Interfood.Business;
using Helpers.Logger;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Web.Security;
using System.Configuration;
using System.Text;

public partial class Owners_UserManager_UserManager : System.Web.UI.Page
{
    protected bool _hasProcessedHeaderMain = false;
    vExtendedPropertiesEntityFilter filter = new vExtendedPropertiesEntityFilter();

    aspnet_ExtendedPropertiesBus busEP = new aspnet_ExtendedPropertiesBus();
    aspnet_ExtendedPropertiesEntityFilter filterEP = new aspnet_ExtendedPropertiesEntityFilter();
    aspnet_ExtendedPropertiesEntityKey keyEP = new aspnet_ExtendedPropertiesEntityKey();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ((DataPager)lvUserManager.FindControl("pagerBottom")).PageSize = PageSize;
            ((DropDownList)lvUserManager.FindControl("cboPageSize")).SelectedValue = PageSize.ToString();
        }

        StringBuilder refresh = new StringBuilder("function Refresh() { document.getElementById('{0}').click(); } ");
        refresh.Replace("{0}", btnRefresh.ClientID);
        refresh.Append("function pageLoad(sender, args) { if (args.get_isPartialLoad()) { tb_init('a.thickbox'); } } ");
        refresh.Append("function updated() { tb_remove(); } ");
        ScriptManager.RegisterStartupScript(Page, GetType(), "refresh", refresh.ToString(), true);


        Menu1.nameSelectedOption = "goto_User_Manager".ToUpper();
    }

    #region Users Selecting
    protected void odsUsers_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["EntityFilter"] = filter;
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

            //--------------------------------------------------------------
            //-- Si es un Administrador, no mostrar el boton eliminar
            //--------------------------------------------------------------
            MembershipUser oUser = Membership.GetUser(rowView["UserName"].ToString());
            if (oUser != null)
            {
                String[] roleForUser = Roles.FindUsersInRole("Administrador", oUser.UserName);
                ((ImageButton)dataItem.FindControl("btnDelete")).Visible = roleForUser.Length > 0 ? false : true;
            }


            if (bool.Parse(rowView["IsLockedOut"].ToString()) || !bool.Parse(rowView["IsApproved"].ToString()))
                ((HtmlImage)dataItem.FindControl("imgBloqueado")).Visible = true;
            else
                ((HtmlImage)dataItem.FindControl("imgBloqueado")).Visible = false;
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

    #region Elimino el USUARIO
    /// <summary>
    /// Eliminar el usuario. El tema a ver aca es q no deberiamos 
    /// eliminar un usuario que haya contestado un CLAIM por ejemplo.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ItemCommand_lvGeneric(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.ToString().ToUpper() == "ELIMINAR")
            {
                MembershipUser usuario = Membership.GetUser(e.CommandArgument.ToString());

                //-- Lo elimino SI NO TIENE CLAIMS relacionados
                //---------------------------------------------------
                if (Membership.DeleteUser(usuario.UserName))
                {
                    keyEP.UserId = new Guid(usuario.ProviderUserKey.ToString());
                    busEP.Delete(keyEP);
                }
                lvUserManager.DataBind();
            }
        }
        catch (Exception ex)
        {
            Logger.LogExceptionStatic(ex);
        }
    }
    #endregion

    #region Button Refresh
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        lvUserManager.DataBind();
    }
    #endregion

    #region PageSize - ChangeCantRows
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
        ((DataPager)lvUserManager.FindControl("pagerBottom")).PageSize = PageSize;
    }
    #endregion
}

