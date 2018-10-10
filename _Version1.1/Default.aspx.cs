using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using Chenso.Utilities.Common;
using System.Text;
using System.Configuration;
using Helpers.Logger;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void SendPasword(object sender, EventArgs e)
    {
        Page.Validate("SendPassword");

        if (Page.IsValid)
        {
            try
            {
                //-- Enviar Contraseña
                //------------------------------
                string email = ((TextBox)Login1.FindControl("txtEmail")).Text;
                string usuario = Membership.GetUserNameByEmail(email);
                if (string.IsNullOrEmpty(usuario))
                {
                    ((Literal)Login1.FindControl("ltrMessage")).Text = "<span style='color:red;font-size:10px;'>El email ingresado no pertenece a un Usuario Registrado. <br />Por favor, ingrese un email válido!</span>";
                }
                else
                {
                    //-- LEVANTO EL TEMPLATE
                    //-----------------------------------------------
                    StringBuilder sbTemplate = new StringBuilder(MySite_EMail.GetTemplate("~/Templates/Emails", "RecuperarClave.htm"));
                    if (!string.IsNullOrEmpty(sbTemplate.ToString()))
                    {
                        MembershipUser oUser = Membership.GetUser(usuario);
                        String password = oUser.GetPassword();

                        sbTemplate.Replace("{{Usuario}}", usuario);
                        sbTemplate.Replace("{{Contraseña}}", password);
                        sbTemplate.Replace("{{FullSiteName}}", MySite.GetFullSiteName_FromAppConfig());

                        MySite_EMail.Send(email,
                            null,
                            "Interfood - Recupero de Contraseña",
                            sbTemplate.ToString(),
                            true,
                            System.Net.Mail.MailPriority.Normal);

                        ((Literal)Login1.FindControl("ltrMessage")).Text = "<span style='color:green;font-size:10px;'>Se han enviado correctamente sus datos privados! <br />Por favor verifique su Correo Electrónico.</span>";
                    }
                }
            }
            catch (Exception ex)
            {
                ((Literal)Login1.FindControl("ltrMessage")).Text = "<span style='color:red;font-size:10px;'>Oooops, ocurrió un error al enviar el Email. <br />Por favor inténtelo mas tarde.</span>";
                Logger.LogExceptionStatic(ex);
            }
        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ((HtmlGenericControl)Login1.FindControl("divSendPassword")).Visible = true;
    }

    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(Login1.UserName, "Administrador"))
            Response.Redirect("~/Admin/Administration/AdministrationMgr.aspx");
        else if (Roles.IsUserInRole(Login1.UserName, "Cliente"))
            Response.Redirect("~/Clientes/PanelDeControl.aspx");
    }
}
