<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditUserDataRow.ascx.cs"
    Inherits="Admin_Administration_UserManager_UserControls_EditUserDataRow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div style="padding: 1px;">
    <asp:TextBox runat="server" ID="Mode" Text="" Style="display: none;"></asp:TextBox>
    <asp:TextBox runat="server" ID="EntityId" Text="" Style="display: none;"></asp:TextBox>
    <div class="hdr-thickbox" runat="server" id="DEMO">
        <div runat="server" id="TitleInsert" visible="false">
            Datos Personales
        </div>
        <div runat="server" id="TitleUpdate" visible="false">
            Editar Usuario
        </div>
        <div runat="server" id="TitleDelete" visible="false">
            Eliminar Usuario
        </div>
    </div>
    <table>
        <tr>
            <td>
                <table cellpadding="0" cellpadding="0" border="0" width="100%" class="tbl-abm">
                    <tr runat="server" id="trUsuario">
                        <td class="td-label">
                            Usuario
                        </td>
                        <td style="padding: 4px;">
                            <asp:Label runat="server" ID="lblUsuario" Style="color: #202931; font-weight: bold;
                                letter-spacing: 1px;"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-label">
                            Apellido <span style="color: Red;">*</span>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtApellido" Width="300" MaxLength="50" Style="display: block;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtApellido"
                                ErrorMessage="El Apellido es obligatorio." Display="Dynamic" CssClass="display-error"
                                SetFocusOnError="true" ValidationGroup="Personales"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-label">
                            Nombres <span style="color: Red;">*</span>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNombres" Width="300" MaxLength="50" Style="display: block;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombres"
                                ErrorMessage="El Nombre es obligatorio." Display="Dynamic" CssClass="display-error"
                                SetFocusOnError="true" ValidationGroup="Personales"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-label">
                            Empresa <span style="color: Red;">*</span>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEmpresa" Width="300" MaxLength="100" Style="display: block;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmpresa"
                                ErrorMessage="Falta ingresar el Nombre de la Empresa del usuario!" Display="Dynamic"
                                CssClass="display-error" SetFocusOnError="true" ValidationGroup="Personales"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-label">
                            Límite de Encuestas <span style="color: Red;">*</span>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtLimiteDeEncuestas" MaxLength="4" Width="50" Style="display: block;"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                TargetControlID="txtLimiteDeEncuestas">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLimiteDeEncuestas"
                                ErrorMessage="Falta ingresar el número máximo de encuestas posibles de gestionar."
                                Display="Dynamic" CssClass="display-error" SetFocusOnError="true" ValidationGroup="Personales"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-label">
                            Telefono Fijo #1
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTelefonoFijo1" MaxLength="30" Width="150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-label">
                            Telefono Fijo #2
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTelefonoFijo2" MaxLength="30" Width="150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-label">
                            Fax
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFax" MaxLength="30" Width="150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-label">
                            Celular
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtCelular" MaxLength="30" Width="150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="td-label">
                            Email <span style="color: Red;">*</span>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEmail" MaxLength="50" Width="300" Style="display: block;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="El Email es obligatorio." Display="Dynamic" CssClass="display-error"
                                SetFocusOnError="true" ValidationGroup="Personales"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtEmail"
                                runat="server" ErrorMessage="Formato no válido para el Email." Display="Dynamic"
                                SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                CssClass="display-error"></asp:RegularExpressionValidator>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Email incorrecto, por favor elija otro!"
                                ControlToValidate="txtEmail" CssClass="display-error" EnableClientScript="false"
                                Display="Dynamic" SetFocusOnError="true" ValidationGroup="Personales" OnServerValidate="ValidarEmail"></asp:CustomValidator>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="border-left:solid 1px #c0c0c0;" valign="top">
                <!-- TIPO DE USUARIO -->
                <div style="clear: both;">
                    <div class="hdr-thickbox" runat="server" id="Div1" style="height: 13px; padding-top: 1px;">
                        Tipo de Usuario
                    </div>
                    <div style="clear: both; padding: 10px 20px; color: #3f3f3f;">
                        <asp:RadioButtonList ID="radioRoles" runat="server">
                            <asp:ListItem Value="Administrador" Text="&nbsp;&nbsp;Administrador de Interfood"></asp:ListItem>
                            <asp:ListItem Value="Cliente" Text="&nbsp;&nbsp;Cliente de Interfood"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="radioRoles"
                            ErrorMessage="Debe asignar el Tipo de Usuario." Display="Dynamic" CssClass="display-error"
                            SetFocusOnError="true" ValidationGroup="Roles"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <!-- DATOS DE LOGIN -->
    <div style="clear: both; padding-top: 10px;" runat="server" id="datosLogin">
        <div class="hdr-thickbox" runat="server" id="Div2" style="height: 13px; padding-top: 1px;">
            Datos de Login
        </div>
        <div style="clear: both;">
            <table cellpadding="0" cellpadding="0" border="0" width="100%" class="tbl-abm">
                <tr>
                    <td class="td-label">
                        Usuario <span style="color: Red;">*</span>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUsuario" Width="150" MaxLength="30" Style="display: block;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUsuario"
                            ErrorMessage="El Usuario es obligatorio." Display="Dynamic" CssClass="display-error"
                            SetFocusOnError="true" ValidationGroup="Login"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td-label">
                        Clave <span style="color: Red;">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="150" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtClave"
                            ErrorMessage="La Clave es obligatoria." Display="Dynamic" CssClass="display-error"
                            SetFocusOnError="true" ValidationGroup="Login"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="td-label">
                        Confirmar Clave <span style="color: Red;">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmarClave" runat="server" TextMode="Password" Width="150"
                            MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtConfirmarClave"
                            ErrorMessage="La Clave es obligatoria." Display="Dynamic" CssClass="display-error"
                            SetFocusOnError="true" ValidationGroup="Login"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtClave"
                            CssClass="display-error" Display="Dynamic" ControlToValidate="txtConfirmarClave"
                            ErrorMessage="Las claves NO coinciden. Por favor ingréselas nuevamente."></asp:CompareValidator>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!-- DATOS DE BLOQUEOS -->
    <div style="clear: both; padding-top: 10px;" runat="server" id="datosBloqueos" visible="false">
        <div class="hdr-thickbox" runat="server" id="Div4" style="height: 13px; padding-top: 1px;">
            Datos Extras
        </div>
        <div style="clear: both;" class="tbl-abm">
            <table cellpadding="0" cellpadding="0" border="0" width="100%" class="tbl-abm">
                <tr>
                    <td class="td-label">
                        Fecha de Alta
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblFechaAlta" Style="font-size: 12px; font-family: Verdana;
                            color: #3f3f3f;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="td-label">
                        Usuario Habilitado
                    </td>
                    <td>
                        <asp:CheckBox ID="chkHabilitado" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="td-label">
                        Usuario Bloqueado
                    </td>
                    <td>
                        <img src="../../../../App_Themes/Default/Images/lock.png" style="float: left; padding: 3px;
                            border: solid 1px transparent;" title="El Usuario esta Bloqueado" runat="server"
                            id="imgBloqueado" visible="false" />
                        <img src="../../../../App_Themes/Default/Images/lock_open.png" style="float: left;
                            padding: 3px; border: solid 1px transparent;" title="El Usuario NO esta Bloqueado"
                            runat="server" id="imgNoBloqueado" visible="false" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!-- BOTONES -->
    <div id="cnt-buttons">
        <!-- BOTON DESBLOQUEAR USUARIO -->
        <div class="btnCrearUsuario" runat="server" id="btnDesbloquearUsuario" visible="false">
            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="true" OnClick="DesbloquearUsuario">
                <div style="width:160px;">
                    <img src="../../../App_Themes/Default/Images/lock_open.png" style="float: left;" />
                    <span class="lbl-btnCrearUsuario">Desbloquear Usuario</span>
                </div>
            </asp:LinkButton>
        </div>
        <!-- BOTON GRABAR NUEVO USUARIO -->
        <div class="btnCrearUsuario" runat="server" id="btnSaveNewRecord" visible="false">
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="true" OnClick="GrabarUsuario">
                <div style="width:80px;">
                    <img src="../../../App_Themes/Default/Images/BtnSave.png" style="float: left;" />
                    <span class="lbl-btnCrearUsuario">Grabar</span>
                </div>
            </asp:LinkButton>
        </div>
        <!-- BOTON CANCELAR -->
        <div class="btnCrearUsuario" runat="server" id="btnCancel" visible="false">
            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" OnClientClick="self.parent.tb_remove();self.parent.Refresh();">
                <div style="width:80px;">
                    <img src="../../../App_Themes/Default/Images/UNDO_16.PNG" style="float: left;" alt=""/>
                    <span class="lbl-btnCrearUsuario">Cancelar</span>
                </div>
            </asp:LinkButton>
        </div>
    </div>
    <div style="text-align: left; padding-left: 10px; font-size: 0.9em;">
        <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
    </div>
</div>
