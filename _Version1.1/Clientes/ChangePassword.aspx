<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_Administration_ChangePassword" %>

<%@ Register Src="UserControls/UserData.ascx" TagName="UserData" TagPrefix="uc1" %>
<%@ Register Src="UserControls/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
<%@ Register src="UserControls/ChangePassword.ascx" tagname="ChangePassword" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_Menu" runat="Server">
    <div>
        <uc1:UserData ID="UserData1" runat="server" />
        <uc2:Menu ID="Menu1" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH_Body" runat="Server">
    <div class="admin-cnt-body">
        <div class="admin-header-body">
            Cambio de Contraseña</div>
        <div style="padding: 10px;">
            <div>
                <uc3:ChangePassword ID="ChangePassword1" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
