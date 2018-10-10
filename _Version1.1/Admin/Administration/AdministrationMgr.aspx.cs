using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using Interfood.Entities;
using Interfood.Business;

public partial class Admin_Administration_AdministrationMgr : System.Web.UI.Page
{
    vExtendedPropertiesBus busEp = new vExtendedPropertiesBus();
    vExtendedPropertiesEntityFilter filterEp = new vExtendedPropertiesEntityFilter();

    protected void Page_Load(object sender, EventArgs e)
    {
        //-- USUARIOS DESABILITADOS
        //----------------------------------
        filterEp.OpeIsApproved = Helpers.Operators.Operadores_Bit.Igual;
        filterEp.IsApproved = false;
        DataTable dtUsers = busEp.SearchCount(filterEp);
        if (dtUsers != null && dtUsers.Rows.Count > 0)
            ltrUsuariosInactivos.Text = dtUsers.Rows[0]["Column1"].ToString();

        //-- USUARIOS bloqueados
        //----------------------------------
        filterEp.Clear();
        filterEp.OpeIsLockedOut = Helpers.Operators.Operadores_Bit.Igual;
        filterEp.IsLockedOut = true;
        dtUsers = busEp.SearchCount(filterEp);
        if (dtUsers != null && dtUsers.Rows.Count > 0)
            ltrUsuariosBloqueados.Text = dtUsers.Rows[0]["Column1"].ToString();

        //-- USUARIOS 
        //----------------------------------
        filterEp.Clear();
        dtUsers = busEp.SearchCount(filterEp);
        if (dtUsers != null && dtUsers.Rows.Count > 0)
            ltrUsuarios.Text = dtUsers.Rows[0]["Column1"].ToString();

        //-- USUARIOS logueados hoy
        //----------------------------------
        filterEp.Clear();
        filterEp.OpeLastLoginDate = Helpers.Operators.Operadores_DateTime.Igual;
        filterEp.LastLoginDateDesde = DateTime.Now;
        dtUsers = busEp.SearchCount(filterEp);
        if (dtUsers != null && dtUsers.Rows.Count > 0)
            ltrLogueadosHoy.Text = dtUsers.Rows[0]["Column1"].ToString();

        //-- USUARIOS Administradores
        //----------------------------------
        filterEp.Clear();
        filterEp.OpeRoleName = Helpers.Operators.Operadores_NVarChar.Igual;
        filterEp.RoleName = "Administrador";
        dtUsers = busEp.SearchCount(filterEp);
        if (dtUsers != null && dtUsers.Rows.Count > 0)
            ltrUsuariosAdministradores.Text = dtUsers.Rows[0]["Column1"].ToString();


        //-- CLIENTES
        //----------------------------------
        filterEp.Clear();
        filterEp.OpeRoleName = Helpers.Operators.Operadores_NVarChar.Igual;
        filterEp.RoleName = "Cliente";
        dtUsers = busEp.SearchCount(filterEp);
        if (dtUsers != null && dtUsers.Rows.Count > 0)
            ltrClientes.Text = dtUsers.Rows[0]["Column1"].ToString();

        Menu1.nameSelectedOption = "GOTO_MY_RESUME_PAGE";
    }
}
