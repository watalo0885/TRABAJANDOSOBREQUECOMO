<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserData.ascx.cs" Inherits="Admin_UserControls_UserData" %>
<div>
    <div class="admin-header-menu-option">
        <b>Usuario logueado</b>
    </div>
    <div style="padding-left: 10px; padding-top: 5px;">
        <div class="btnUserLogued"></div>
        <span style="float: left; padding-top: 20px; padding-left: 5px; font-weight: bold;
            font-size: 11px;">
            <asp:Literal ID="ltrUserName" runat="server"></asp:Literal>
        </span>
        <div style="clear: both;">
        </div>
    </div>
    <div style="height: 20px; float: right; padding: 5px;">
        <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutText="Cerrar sesion" Visible="false" />
    </div>
</div>
