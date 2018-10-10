<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Admin_UserControls_menu" %>
<div>
    <div style="clear: both; border-top: solid 1px #c0c0c0;">
    </div>
    <div style="clear: both; border-top: solid 1px #c0c0c0;">
    </div>
    <div id="internal-menu">
        <ul>
            <li runat="server" id="goto_My_Resume_Page" class="menu-option-selected">
                <asp:HyperLink ID="HyperLink3" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/AdministrationMgr.aspx">Resumen</asp:HyperLink>
            </li>
            
             
            
            <li runat="server" id="goto_User_Manager" class="menu-option">
                <asp:HyperLink ID="HyperLink4" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/UserManager/UserManager.aspx">Usuarios</asp:HyperLink>
            </li>
            
            <li runat="server" id="goto_Encuestas_List" class="menu-option">
                <asp:HyperLink ID="HyperLink10" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/Managers/EncuestasList.aspx">Encuestas</asp:HyperLink>
            </li>
            
            <li runat="server" id="goto_listados" class="menu-option">
                <asp:HyperLink ID="HyperLink11" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/Listados/EncuestasList.aspx">Exportar encuestas</asp:HyperLink>
            </li>

            <li runat="server" id="goto_FuenteNutAli" class="menu-option">
                <asp:HyperLink ID="HyperLink13" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/Managers/FuentesNutXal.aspx">Fuente</asp:HyperLink>
            </li>
            
            <li runat="server" id="goto_Alimento_List" class="menu-option">
                <asp:HyperLink ID="HyperLink5" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/Managers/AlimentoList.aspx">Alimentos</asp:HyperLink>
            </li>
            
            <li runat="server" id="goto_Nutriente_List" class="menu-option">
                <asp:HyperLink ID="HyperLink7" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/Managers/NutrienteList.aspx">Nutrientes</asp:HyperLink>
            </li>
            
            <li runat="server" id="goto_NutrientesPorAlimentoList" class="menu-option">
                <asp:HyperLink ID="HyperLink6" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/Managers/NutrientesPorAlimentoList.aspx">Nutrientes por Alimento</asp:HyperLink>
            </li>
            
            <li runat="server" id="goto_TipoDeAlimentosList" class="menu-option">
                <asp:HyperLink ID="HyperLink2" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/Managers/TipoDeAlimentoList.aspx">Tipos de Alimentos</asp:HyperLink>
            </li>
            
            <li runat="server" id="goto_TipoDeDietasList" class="menu-option">
                <asp:HyperLink ID="HyperLink8" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/Managers/TipoDeDietaList.aspx">Tipos de Dietas</asp:HyperLink>
            </li>

            <li runat="server" id="goto_UnidadDeMedidaList" class="menu-option">
                <asp:HyperLink ID="HyperLink9" runat="server" Width="100%" NavigateUrl="~/Admin/Administration/Managers/UnidadDeMedidaList.aspx">Unidades de Medida</asp:HyperLink>
            </li>

            <li runat="server" id="goto_Change_Password" class="menu-option">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Administration/ChangePassword.aspx"
                    Width="100%">Cambiar mi Contraseña</asp:HyperLink>
            </li>
            <li runat="server" id="goto_Cerrar_Sesion" class="menu-option">
<%--                <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="#"  
                    Width="100%">Cerrar Sesion</asp:HyperLink>                --%> 
                <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Cerrar sesion" />   
            </li>
           
           
        </ul>
    </div>
</div>
