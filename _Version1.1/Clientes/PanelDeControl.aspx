<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="PanelDeControl.aspx.cs" Inherits="PanelDeControl" %>

<%@ Register Src="UserControls/UserData.ascx" TagName="UserData" TagPrefix="uc1" %>
<%@ Register Src="UserControls/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
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
            Resumen de Actividad</div>
        <div style="padding-left: 30px; padding-top: 20px;">
            <div style="color: Black; font-size: 0.9em; height: 30px;">
                <asp:Literal runat="server" ID="ltrDate"></asp:Literal>
            </div>
            <div id="cnt-resume">
                <div style="padding-left: 20px;">
                    <table border="0" cellpadding="0" cellspacing="0" width="50%" style="color: #696969;
                        font-weight: bold; line-height: 25px; font-size: 13px;">
                        <tr>
                            <td style="width:300px;">
                                Límite de Encuestas definidas
                            </td>
                            <td style="width: 40px;">
                                <asp:Literal runat="server" ID="ltrLimite">0</asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:300px;">
                                Encuestas definidas hasta el momento
                            </td>
                            <td style="width: 40px;">
                                <asp:Literal runat="server" ID="ltrEncuestasDefinidas">0</asp:Literal>
                            </td>
                        </tr>
                        
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
