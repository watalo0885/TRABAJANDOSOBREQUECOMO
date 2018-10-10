using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Interfood.Entities;
using Interfood.Business;
using System.Web.Security;

public partial class PanelDeControl : System.Web.UI.Page
{
    vExtendedPropertiesBus busEp = new vExtendedPropertiesBus();
    vExtendedPropertiesEntityFilter filterEp = new vExtendedPropertiesEntityFilter();
    EncuestaAlimentariaBus bus = new EncuestaAlimentariaBus();
    EncuestaAlimentariaEntityFilter filter = new EncuestaAlimentariaEntityFilter();

    protected void Page_Load(object sender, EventArgs e)
    {
        MembershipUser oUser = Membership.GetUser(Page.User.Identity.Name);
        if (oUser != null)
        {
            Menu1.nameSelectedOption = "GOTO_MY_RESUME_PAGE";

            //----------------------------------
            //-- ENCUESTAS DEFINIDAS
            //----------------------------------
            filter.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
            filter.UserId = new Guid(oUser.ProviderUserKey.ToString());
            DataTable dtUsers = bus.SearchCount(filter);
            if (dtUsers != null && dtUsers.Rows.Count > 0)
                ltrEncuestasDefinidas.Text = dtUsers.Rows[0]["Column1"].ToString();

            //----------------------------------
            //-- Limite de Encuestas
            //----------------------------------
            filterEp.OpeUserName = Helpers.Operators.Operadores_NVarChar.Igual;
            filterEp.UserName = Page.User.Identity.Name;
            DataTable dtEp = busEp.Search(filterEp);
            if (dtEp != null && dtEp.Rows.Count > 0)
                ltrLimite.Text = dtEp.Rows[0]["LimiteDeEncuestas"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
