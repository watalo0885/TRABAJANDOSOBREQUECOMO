using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Chenso.Utilities.Common;
using Helpers.Logger;

public partial class UserControls_Membership_ChangePassword : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipUser oUser = Membership.GetUser(MyUsers.GetLoggedUserId());

            if (oUser.ChangePassword(ChangePassword1.CurrentPassword, ChangePassword1.NewPassword))
                ltrMessages.Text = "<span style='color:green;'>Su contraseña se cambió correctamente!</span>";
            else
                ltrMessages.Text = "<span style='color:red;'>Oooops, ocurrió un error!<br /> Quizá ingresó mal su contraseña <b>actual</b>. Por favor vuelva a intentarlo!";
        }
        catch (Exception ex)
        {
            Logger.LogExceptionStatic(ex);
        }
    }
}
