<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.ascx.cs"
    Inherits="UserControls_Membership_ChangePassword" %>
<div>
    <!-- CHANGE PASSWORD -->
    <asp:ChangePassword ID="ChangePassword1" runat="server">
        <ChangePasswordTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="width: 180px;">
                        <asp:Label ID="CurrentPasswordLabel" CssClass="formLabel" runat="server" AssociatedControlID="CurrentPassword">Contraseña:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" Width="210"
                            MaxLength="25"></asp:TextBox>
                        <span class="required">&nbsp;</span>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                            ErrorMessage="Ingrese una contraseña!" Display="None" ToolTip="Ingrese una contraseña!"
                            ValidationGroup="ctl00$ChangePassword1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="NewPasswordLabel" CssClass="formLabel" runat="server" AssociatedControlID="NewPassword">Nueva Contraseña:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" Width="210" MaxLength="25"></asp:TextBox>
                        <span class="required">&nbsp;</span>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                            ErrorMessage="Ingrese la contraseña nueva!" Display="None" ToolTip="Ingrese la contraseña nueva!"
                            ValidationGroup="ctl00$ChangePassword1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="ConfirmNewPasswordLabel" CssClass="formLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirme la Nueva Contraseña:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" Width="210"
                            MaxLength="25"></asp:TextBox>
                        <span class="required">&nbsp;</span>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                            ErrorMessage="Ingrese la confirmación de la nueva contraseña!" Display="None" ToolTip="Ingrese la confirmación de la nueva contraseña!"
                            ValidationGroup="ctl00$ChangePassword1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                            ControlToValidate="ConfirmNewPassword" Display="None" ErrorMessage="La nueva contraseña y su confirmación no son iguales!"
                            ValidationGroup="ctl00$ChangePassword1"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left">
                        <div id="cnt-buttons">
                            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                Text="Grabar" ValidationGroup="ctl00$ChangePassword1" CssClass="button" OnClick="ChangePasswordPushButton_Click" />
                            <%-- <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Cancel" CssClass="button" />--%>
                        </div>
                    </td>
                </tr>
            </table>
        </ChangePasswordTemplate>
        <SuccessTemplate>
            <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                <tr>
                    <td>
                        <table border="0" cellpadding="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Change Password Complete
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Your password has been changed!
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" CommandName="Continue"
                                        Text="Continue" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </SuccessTemplate>
    </asp:ChangePassword>
    <div class="containerErrors">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="summaryErrors"
            ValidationGroup="ctl00$ChangePassword1" />
    </div>
    <div>
        <asp:Literal runat="server" ID="ltrMessages"></asp:Literal>
    </div>
</div>
