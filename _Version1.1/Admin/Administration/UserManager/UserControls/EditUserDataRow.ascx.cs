using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Interfood.Entities;
using Interfood.Business;
using System.Web.Security;
using Helpers.Logger;
using System.Data;

public partial class Admin_Administration_UserManager_UserControls_EditUserDataRow : System.Web.UI.UserControl
{
    aspnet_ExtendedPropertiesBus busEP = new aspnet_ExtendedPropertiesBus();
    aspnet_ExtendedPropertiesEntityFilter filterEP = new aspnet_ExtendedPropertiesEntityFilter();
    aspnet_ExtendedPropertiesEntityInsert insertEP = new aspnet_ExtendedPropertiesEntityInsert();
    aspnet_ExtendedPropertiesEntityKey keyEP = new aspnet_ExtendedPropertiesEntityKey();
    aspnet_ExtendedPropertiesEntityUpdate updateEP = new aspnet_ExtendedPropertiesEntityUpdate();

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrMessage.Visible = false;

        if (!IsPostBack)
        {
            if (Request["Mode"] != null)
                Mode.Text = Request["Mode"].Trim().ToUpper();

            switch (Mode.Text.Trim().ToUpper())
            {
                case "INSERT":
                    TitleInsert.Visible = true;
                    btnSaveNewRecord.Visible = true;
                    btnCancel.Visible = true;
                    datosBloqueos.Visible = false;
                    trUsuario.Visible = false;
                    break;
                case "UPDATE":
                    TitleUpdate.Visible = true;
                    btnCancel.Visible = true;
                    btnSaveNewRecord.Visible = true;
                    EntityId.Text = Request["Id"].ToString();
                    DataToControls();
                    datosLogin.Visible = false;
                    datosBloqueos.Visible = true;
                    break;

                default:
                    TitleInsert.Visible = true;
                    btnSaveNewRecord.Visible = true;
                    btnCancel.Visible = true;
                    break;
            }
        }
    }

    #region DataToControls
    private void DataToControls()
    {
        //-- Creo el usuario y lo HABILITO
        //-------------------------------------------------------
        MembershipUser oUser = Membership.GetUser(EntityId.Text);

        if (oUser != null)
        {
            UpdateImagesLock();

            chkHabilitado.Checked = oUser.IsApproved;

            filterEP.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
            filterEP.UserId = new Guid(oUser.ProviderUserKey.ToString());

            DataTable dtEP = busEP.Search(filterEP);
            if (dtEP != null && dtEP.Rows.Count > 0)
            {
                //-- Cargo los controles
                //---------------------------------------------------------
                txtApellido.Text = dtEP.Rows[0]["Apellido"].ToString();
                txtCelular.Text = dtEP.Rows[0]["Celular"].ToString();
                txtEmail.Text = dtEP.Rows[0]["Email"].ToString();
                txtEmpresa.Text = dtEP.Rows[0]["Empresa"].ToString();
                txtFax.Text = dtEP.Rows[0]["Fax"].ToString();
                txtLimiteDeEncuestas.Text = dtEP.Rows[0]["LimiteDeEncuestas"].ToString();
                txtNombres.Text = dtEP.Rows[0]["Nombres"].ToString();
                txtTelefonoFijo1.Text = dtEP.Rows[0]["TelefonoFijo1"].ToString();
                txtTelefonoFijo2.Text = dtEP.Rows[0]["TelefonoFijo2"].ToString();
                txtUsuario.Text = oUser.UserName;
                lblFechaAlta.Text = DateTime.Parse(dtEP.Rows[0]["FechaAlta"].ToString()).ToString("dd/MM/yyyy hh':'mm");

                //-- Cargo el Rol del Usuario
                //---------------------------------------------------------
                if (Roles.IsUserInRole(oUser.UserName, "Administrador")) radioRoles.SelectedValue = "Administrador";
                if (Roles.IsUserInRole(oUser.UserName, "Cliente")) radioRoles.SelectedValue = "Cliente";

                lblUsuario.Text = oUser.UserName;
            }
        }
    }
    #endregion

    #region GrabarUsuario
    protected void GrabarUsuario(object sender, EventArgs e)
    {
        try
        {
            switch (Mode.Text.Trim().ToUpper())
            {
                case "INSERT":
                    InsertarUsuario();
                    break;
                case "UPDATE":
                    UpdateUsuario();
                    break;
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

    #region DesbloquearUsuario
    protected void DesbloquearUsuario(object sender, EventArgs e)
    {
        try
        {
            //-- DESBLOQUEO EL USUARIO
            //--------------------------------------------------------
            MembershipUser oUser = Membership.GetUser(EntityId.Text);
            oUser.UnlockUser();
            UpdateImagesLock();
        }
        catch (Exception ex)
        {
            Logger.LogExceptionStatic(ex);
            ltrMessage.Text = string.Format("<span style='color:red;'>Oooops, ocurrió un error. Descripción: {0}</span>", ex.Message);
            ltrMessage.Visible = true;
        }

    }
    #endregion

    #region InsertarUsuario
    protected void InsertarUsuario()
    {
        Page.Validate("Personales");
        Page.Validate("Roles");
        Page.Validate("Login");

        if (Page.IsValid)
        {
            try
            {
                MembershipCreateStatus status = new MembershipCreateStatus();

                //-- Creo el usuario y lo HABILITO
                //-------------------------------------------------------
                MembershipUser oUser = Membership.CreateUser(txtUsuario.Text.Trim(), txtClave.Text.Trim(), txtEmail.Text, null, null, true, out status);

                //-- Verifico datos al intentar crear el usuario
                //-------------------------------------------------------
                if (MembershipCreateStatus.Success == status)
                {
                    //-- Inserto PROPIEDADES EXTENDIDAS
                    //--------------------------------------------------------
                    insertEP.Apellido = txtApellido.Text.ToUpperInvariant();
                    insertEP.Celular = txtCelular.Text;
                    insertEP.Email = txtEmail.Text;
                    insertEP.Empresa = txtEmpresa.Text.ToUpperInvariant();
                    insertEP.Fax = txtFax.Text;
                    insertEP.FechaAlta = DateTime.Now;
                    insertEP.LimiteDeEncuestas = int.Parse("0" + txtLimiteDeEncuestas.Text.Trim());
                    insertEP.Nombres = txtNombres.Text.ToUpperInvariant();
                    insertEP.TelefonoFijo1 = txtTelefonoFijo1.Text;
                    insertEP.TelefonoFijo2 = txtTelefonoFijo2.Text;
                    insertEP.UserId = new Guid(oUser.ProviderUserKey.ToString());

                    busEP.Insert(insertEP);

                    //-- ASIGNO ROL
                    //--------------------------------------------------------
                    Roles.AddUserToRole(oUser.UserName, radioRoles.SelectedValue);
                    

                    ltrMessage.Text = "<span style='color:green;font-size:11px;'>Usuario agregado correctamente!</span>";
                }
                if (MembershipCreateStatus.DuplicateEmail == status)
                {
                    ltrMessage.Text = "<span style='color:red;font-size:11px;'>El mail ingresado ya pertenece a otro usuario. Por favor ingrese uno nuevo.</span>";
                }
                else if (MembershipCreateStatus.DuplicateUserName == status)
                {
                    ltrMessage.Text = "<span style='color:red;font-size:11px;'>El Usuario ingresado ya existe. Por favor ingrese uno nuevo.</span>";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ltrMessage.Visible = true;
        }
    }
    #endregion

    #region UpdateUsuario
    protected void UpdateUsuario()
    {
        Page.Validate("Personales");
        Page.Validate("Roles");

        if (Page.IsValid)
        {
            try
            {
                //-- Cargo entidad KEY
                //--------------------------------------------------------
                keyEP.UserId = new Guid(Membership.GetUser(EntityId.Text).ProviderUserKey.ToString());

                //-- Cargo entidad UPDATE
                //--------------------------------------------------------
                updateEP.Apellido = txtApellido.Text.ToUpperInvariant();
                updateEP.Celular = txtCelular.Text;
                updateEP.Email = txtEmail.Text;
                updateEP.Empresa = txtEmpresa.Text.ToUpperInvariant();
                updateEP.Fax = txtFax.Text;
                updateEP.FechaAlta = DateTime.Now;
                updateEP.LimiteDeEncuestas = int.Parse("0" + txtLimiteDeEncuestas.Text.Trim());
                updateEP.Nombres = txtNombres.Text.ToUpperInvariant();
                updateEP.TelefonoFijo1 = txtTelefonoFijo1.Text;
                updateEP.TelefonoFijo2 = txtTelefonoFijo2.Text;
                updateEP.UserId = new Guid(Membership.GetUser(EntityId.Text).ProviderUserKey.ToString());

                //-- GRABO PROPIEDADES EXTENDIDAS
                //--------------------------------------------------------
                busEP.Update(keyEP, updateEP);


                //-- ELIMINO usuario de TODOS los Roles
                //------------------------------------------------
                if (Roles.IsUserInRole(EntityId.Text, "Administrador"))
                    Roles.RemoveUserFromRoles(EntityId.Text, new string[] { "Administrador" });

                if (Roles.IsUserInRole(EntityId.Text, "Cliente"))
                    Roles.RemoveUserFromRoles(EntityId.Text, new string[] { "Cliente" });

                //-- ASIGNO ROL SELECCIONADO
                //--------------------------------------------------------
                Roles.AddUserToRole(EntityId.Text, radioRoles.SelectedValue);

                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Usuario modificado correctamente!</span>";

                //-- MODIFICO MAIL e IsApproved EN MEMBERSHIP
                //--------------------------------------------------------
                MembershipUser oUser = Membership.GetUser(EntityId.Text);
                oUser.Email = txtEmail.Text;
                oUser.IsApproved = chkHabilitado.Checked;
                Membership.UpdateUser(oUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ltrMessage.Visible = true;
        }
    }
    #endregion

    #region Validaciones personalizadas
    /// <summary>
    /// Validaciones Custom
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void ValidarEmail(object source, ServerValidateEventArgs args)
    {
        //-- Si retorna null => el mail no existe y es correcto
        //-------------------------------------------------------------
        if (string.IsNullOrEmpty(Membership.GetUserNameByEmail(txtEmail.Text)))
            args.IsValid = true;
        else
        {
            //-- Si retorna un usuario para el EMAIl, tengo que averiguar
            //-- si es el usuario a quien estoy EDITANDO o no !!!
            //-------------------------------------------------------------
            if (Membership.GetUserNameByEmail(txtEmail.Text).Trim().ToUpper() != lblUsuario.Text.Trim().ToUpper())
                args.IsValid = false;
            else
                args.IsValid = true;
        }
    }
    #endregion

    #region UpdateImagesLock
    private void UpdateImagesLock()
    {
        MembershipUser oUser = Membership.GetUser(EntityId.Text);
        imgBloqueado.Visible = oUser.IsLockedOut;
        imgNoBloqueado.Visible = !oUser.IsLockedOut;
        btnDesbloquearUsuario.Visible = oUser.IsLockedOut;
    }
    #endregion
}
