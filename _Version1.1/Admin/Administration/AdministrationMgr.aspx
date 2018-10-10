<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="AdministrationMgr.aspx.cs" Inherits="Admin_Administration_AdministrationMgr" %>

<%@ Register Src="../UserControls/UserData.ascx" TagName="UserData" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_Menu" runat="Server">
    <div>
        <uc1:UserData ID="UserData1" runat="server" />
        <uc2:Menu ID="Menu1" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH_Body" runat="Server">
    <div class="admin-cnt-general-body">
        <div class="admin-header-body">
            Resumen General</div>
        <div style="padding-left: 30px; padding-top: 20px;">
            <div style="color: Black; font-size: 0.9em; height: 30px;">
                <asp:Literal runat="server" ID="ltrDate"></asp:Literal>
            </div>
            <div id="cnt-resume">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="color: #696969;
                    font-weight: bold; line-height: 25px; font-size: 13px;">
                    <tr>
                        <td>
                            Usuarios
                        </td>
                        <td style="width: 40px;">
                            <asp:Literal runat="server" ID="ltrUsuarios">0</asp:Literal>
                        </td>
                        <td width="15%">
                        </td>
                        <td>
                            Usuarios Administradores
                        </td>
                        <td style="width: 40px;">
                            <asp:Literal runat="server" ID="ltrUsuariosAdministradores">0</asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Usuarios inactivos
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ltrUsuariosInactivos">0</asp:Literal>
                        </td>
                        <td width="15%">
                        </td>
                        <td>
                            Clientes
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ltrClientes">0</asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Usuarios bloqueados
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ltrUsuariosBloqueados">0</asp:Literal>
                        </td>
                        <td width="15%">
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Usuarios logueados hoy
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="ltrLogueadosHoy">0</asp:Literal>
                        </td>
                        <td width="15%">
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
