using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserControls_menu : System.Web.UI.UserControl
{
    public string nameSelectedOption = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_MY_RESUME_PAGE")
            goto_My_Resume_Page.Attributes.Add("class", "menu-option-selected");
        else
            goto_My_Resume_Page.Attributes.Add("class", "menu-option");


        if (nameSelectedOption.Trim().ToUpper() == "GOTO_ENCUESTASLIST")
            goto_EncuestasList.Attributes.Add("class", "menu-option-selected");
        else
            goto_EncuestasList.Attributes.Add("class", "menu-option");

        if (nameSelectedOption.Trim().ToUpper() == "GOTO_ALIMENTOS_POR_ENCUESTAS")
            GOTO_ALIMENTOS_POR_ENCUESTAS.Attributes.Add("class", "menu-option-selected");
        else
            GOTO_ALIMENTOS_POR_ENCUESTAS.Attributes.Add("class", "menu-option");



        //-- GOTO_CHANGE_PASSWORD
        //-----------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_CHANGE_PASSWORD")
            goto_Change_Password.Attributes.Add("class", "menu-option-selected");
        else
            goto_Change_Password.Attributes.Add("class", "menu-option");



    }


}
