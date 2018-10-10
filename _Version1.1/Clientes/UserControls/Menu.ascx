<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="Admin_UserControls_menu" %>
<div>
    <div style="clear: both; border-top: solid 1px #c0c0c0;">
    </div>
    <div style="clear: both; border-top: solid 1px #c0c0c0;">
    </div>
    <div id="internal-menu">
        <ul>
            <li runat="server" id="goto_My_Resume_Page" class="menu-option-selected">
                <asp:HyperLink ID="HyperLink3" runat="server" Width="100%" NavigateUrl="~/Clientes/PanelDeControl.aspx">Resumen</asp:HyperLink>
            </li>
                 
            <li runat="server" id="goto_EncuestasList" class="menu-option-selected">
                <asp:HyperLink ID="HyperLink2" runat="server" Width="100%" NavigateUrl="~/Clientes/Encuestas/EncuestasList.aspx">Encuestas</asp:HyperLink>
            </li>
            
            <li runat="server" id="GOTO_ALIMENTOS_POR_ENCUESTAS" class="menu-option-selected">
                <asp:HyperLink ID="HyperLink4" runat="server" Width="100%" NavigateUrl="~/Clientes/Listados/EncuestasList.aspx">Exportaciones</asp:HyperLink>
            </li>
                  
            <li runat="server" id="goto_Change_Password" class="menu-option">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Clientes/ChangePassword.aspx"
                    Width="100%">Cambiar mi Contraseña</asp:HyperLink>
            </li>
             <li runat="server" id="goto_Cerrar_Sesion" class="menu-option">
<%--                <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="#"  
                    Width="100%">Cerrar Sesion</asp:HyperLink>                --%> 
                <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Cerrar Sesion" />   
            </li>
           
        </ul>
    </div>
</div>
