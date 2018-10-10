<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditTipoDeAlimentoDataRow.ascx.cs"
    Inherits="EditNutrienteDataRow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div style="padding: 1px;">
    <asp:TextBox runat="server" ID="Mode" Text="" Style="display: none;"></asp:TextBox>
    <asp:TextBox runat="server" ID="EntityId" Text="" Style="display: none;"></asp:TextBox>
    <div class="hdr-thickbox" runat="server" id="DEMO">
        <div runat="server" id="TitleInsert" visible="false">
            Definir un Nuevo Tipo de Alimento
        </div>
        <div runat="server" id="TitleUpdate" visible="false">
            Editar Tipo de Alimento
        </div>
        <div runat="server" id="TitleDelete" visible="false">
            Eliminar Tipo de Alimento
        </div>
    </div>
    <table cellpadding="0" cellpadding="0" border="0" width="100%" class="tbl-abm">
        <tr>
            <td class="td-label">
                Descripción <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTipoDeAlimento" Width="400" MaxLength="200" Style="display: block;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTipoDeAlimento"
                    ErrorMessage="El Nombre es requerido!" Display="Dynamic" CssClass="display-error"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="El Tipo de Alimento elegido ya existe!"
                    ControlToValidate="txtTipoDeAlimento" CssClass="display-error" EnableClientScript="false"
                    Display="Dynamic" SetFocusOnError="true" OnServerValidate="ValidarNombre"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="td-label">
                Orden de visualización
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtOrdenDeVisualizacion" Width="50" MaxLength="3" 
                    Style="display: block;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOrdenDeVisualizacion"
                    ErrorMessage="El valor par el Orden de Visualización es requerido!" Display="Dynamic"
                    CssClass="display-error" SetFocusOnError="true"></asp:RequiredFieldValidator>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars"
                    FilterType="Custom" TargetControlID="txtOrdenDeVisualizacion" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="td-label">
                Estado <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:DropDownList ID="cboEstado" runat="server" Style="font-size: 12px;" Width="100">
                    <asp:ListItem Selected="True" Text="Activo" Value="ACT"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="INACT"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <!-- BOTONES -->
    <div id="cnt-buttons">
        <!-- BOTON GRABAR NUEVO USUARIO -->
        <div class="btnCrearUsuario" runat="server" id="btnSaveNewRecord" visible="false">
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="true" OnClick="GrabarTipoDeAlimento">
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
    <div style="text-align: left; padding-top: 10px; padding-left: 10px; font-size: 0.9em;">
        <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
    </div>
</div>
