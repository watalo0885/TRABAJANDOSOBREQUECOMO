<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Que-Como Login</title>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #2ECC71;">
    <table id="login-container">
        <tr>
            <td>
                <asp:Login ID="Login1" runat="server" FailureText="El Usuario o la Clave ingresada no son correctos. &lt;br /&gt; Inténtelo nuevamente!"
                    OnLoggedIn="Login1_LoggedIn">
                    <LayoutTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;
                            border: solid 2px #dedede;">
                            <tr> 
                                <td align="center">
                                    <table border="0" cellpadding="0" class="login-table">
                                        <tr>
                                            <td align="center" class="login-td-header" style="background-color:#49FF5F">
                                                <b>Que-Como</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 8px 5px 5px 5px; text-align: left;">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Ingrese su nombre de Usuario</asp:Label>
                                                <asp:TextBox ID="UserName" runat="server" Style="display: block;" Width="290" Text=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    Style="font-size: 10px;" ErrorMessage="El Usuario es requerido." ToolTip="El Usuario es requerido."
                                                    ValidationGroup="Login1" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 5px; text-align: left;">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Style="display: block;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    Style="font-size: 10px;" ErrorMessage="La Contraseña es requerida." ToolTip="La Contraseña es requerida."
                                                    ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <!--
                                        <tr>
                                            <td style="padding-left: 5px; text-align: left;">
                                                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                            </td>
                                        </tr>
                                        -->
                                        <tr>
                                            <td align="center" style="color: Red; text-align: left; font-size: 11px; padding-left: 10px;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="padding: 4px;">
                                                <div style="float: left; cursor: pointer; cursor: hand;">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Olvidé
                                                        mi Contraseña</asp:LinkButton>
                                                </div>
                                                <div style="float: right;">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Ingresar" ValidationGroup="Login1"
                                                        Style="color: Black; background-color: #cfe1f4; border: solid 1px #dedede; font-size: 11px;"
                                                        UseSubmitBehavior="true" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trEmailSendPassword">
                                            <td align="left">
                                                <div style="border-top: solid 2px #dedede; padding: 4px;" runat="server" id="divSendPassword"
                                                    visible="false">
                                                    <div>
                                                        Ingrese su cuenta de Email</div>
                                                    <div>
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="300" ValidationGroup="SendPassword"></asp:TextBox><span
                                                            style="color: Red;">&nbsp;*</span>
                                                        <div>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Por favor ingrese su Email!"
                                                                ControlToValidate="txtEmail" ValidationGroup="SendPassword" Display="Dynamic"
                                                                SetFocusOnError="true" Style="font-size: 10px;"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="regEmail" ControlToValidate="txtEmail" Text="Formato no válido de Email! Por favor ingréselo nuevamente."
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="SendPassword"
                                                                SetFocusOnError="true" Display="Dynamic" runat="server" Style="font-size: 10px;" />
                                                        </div>
                                                        <div>
                                                            <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
                                                        </div>
                                                    </div>
                                                    <div style="float: right; padding: 4px 0px;">
                                                        <asp:Button ID="btnSendPassword" runat="server" Text="Enviar Contraseña" Style="color: Black;
                                                            background-color: #cfe1f4; border: solid 1px #dedede; font-size: 11px;" OnClick="SendPasword"
                                                            ValidationGroup="SendPassword" />
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                </asp:Login>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
