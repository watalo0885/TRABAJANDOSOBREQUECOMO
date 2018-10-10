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

        //-- GOTO_LISTADOS
        //----------------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_LISTADOS")
            goto_listados.Attributes.Add("class", "menu-option-selected");
        else
            goto_listados.Attributes.Add("class", "menu-option");

        //-- GOTO_ENCUESTAS_LIST
        //----------------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_ENCUESTAS_LIST")
            goto_Encuestas_List.Attributes.Add("class", "menu-option-selected");
        else
            goto_Encuestas_List.Attributes.Add("class", "menu-option");

        //-- GOTO_CHANGE_PASSWORD
        //-----------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_CHANGE_PASSWORD")
            goto_Change_Password.Attributes.Add("class", "menu-option-selected");
        else
            goto_Change_Password.Attributes.Add("class", "menu-option");

        //-- GOTO_USER_MANAGER
        //-----------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_USER_MANAGER")
            goto_User_Manager.Attributes.Add("class", "menu-option-selected");
        else
            goto_User_Manager.Attributes.Add("class", "menu-option");

        //-- GOTO_ALIMENTO_LIST
        //----------------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_ALIMENTO_LIST")
            goto_Alimento_List.Attributes.Add("class", "menu-option-selected");
        else
            goto_Alimento_List.Attributes.Add("class", "menu-option");

        //-- GOTO_NUTRIENTE_LIST
        //----------------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_NUTRIENTE_LIST")
            goto_Nutriente_List.Attributes.Add("class", "menu-option-selected");
        else
            goto_Nutriente_List.Attributes.Add("class", "menu-option");

        //-- GOTO_NUTRIENTES_POR_ALIMENTOS_LIST
        //----------------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_NUTRIENTES_POR_ALIMENTOS_LIST")
            goto_NutrientesPorAlimentoList.Attributes.Add("class", "menu-option-selected");
        else
            goto_NutrientesPorAlimentoList.Attributes.Add("class", "menu-option");


        //-- GOTO_TIPODEALIMENTOS_LIST
        //----------------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_TIPODEALIMENTOS_LIST")
            goto_TipoDeAlimentosList.Attributes.Add("class", "menu-option-selected");
        else
            goto_TipoDeAlimentosList.Attributes.Add("class", "menu-option");

        //-- GOTO_TIPODEDIETAS_LIST
        //----------------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_TIPODEDIETAS_LIST")
            goto_TipoDeDietasList.Attributes.Add("class", "menu-option-selected");
        else
            goto_TipoDeDietasList.Attributes.Add("class", "menu-option");

        //-- GOTO_UNIDADDEMEDIDAS_LIST
        //----------------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_UNIDADDEMEDIDAS_LIST")
            goto_UnidadDeMedidaList.Attributes.Add("class", "menu-option-selected");
        else
            goto_UnidadDeMedidaList.Attributes.Add("class", "menu-option");

        //-- GOTO_FUENTENUTALI
        //----------------------------------------
        if (nameSelectedOption.Trim().ToUpper() == "GOTO_FUENTENUTALI")
            goto_FuenteNutAli.Attributes.Add("class", "menu-option-selected");
        else
            goto_FuenteNutAli.Attributes.Add("class", "menu-option");
        

    }


}
