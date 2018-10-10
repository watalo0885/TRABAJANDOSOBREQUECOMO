using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_UserControls_UserData : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
        {
            string [] aUser = Page.User.Identity.Name.Split('@');
            ltrUserName.Text = aUser[0].ToString();
        }
    }
}
