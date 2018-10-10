using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Chenso.Business;
using Chenso.Entities;
using System.Web.Security;
using System.Data;

public partial class Admin_RoleManager : System.Web.UI.Page
{
    aspnet_RolesBus RolesBus = new aspnet_RolesBus();
    aspnet_RolesEntityKey RolesKey = new aspnet_RolesEntityKey();
    aspnet_RolesEntityUpdate RolesUpdate = new aspnet_RolesEntityUpdate();
    aspnet_RolesEntityFilter RolesFilter = new aspnet_RolesEntityFilter();

    protected void Page_Load(object sender, EventArgs e)
    {
        RolesFilter.OrderBy = "RoleName asc";
        RolesBus.Search(RolesFilter);
    }

    #region ODS
    protected void odsRoles_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["EntityFilter"] = RolesFilter;
    }
    #endregion

    protected void btnCreateNewRole_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                Roles.CreateRole(txtRoleName.Text.Trim());

            }
            catch (Exception ex)
            {
                ltrError.Text = ex.Message;
            }
            lvRoleManager.DataBind();
        }
    }

    #region Elimino el Role
    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lvRoleManager_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            string roleName = e.CommandArgument.ToString();

            if (e.CommandName.ToString().ToUpper() == "ELIMINAR")
            {
                String[] aRoles = Roles.GetUsersInRole(e.CommandArgument.ToString());
                if (aRoles.Count() == 0)
                {
                    Roles.DeleteRole(roleName);
                    lvRoleManager.DataBind();
                    ltrError.Text = string.Format("Role {0} deleted!", roleName);
                }
                else
                {
                    ltrError.Text = string.Format("The Role {0} have Users assign!", roleName);
                }
            }

        }
        catch (Exception ex)
        {
            ltrError.Text = ex.Message;
        }
    }
    #endregion
}
