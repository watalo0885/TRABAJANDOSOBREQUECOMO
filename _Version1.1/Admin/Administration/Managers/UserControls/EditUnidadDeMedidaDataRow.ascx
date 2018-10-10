<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditUnidadDeMedidaDataRow.ascx.cs"
    Inherits="EditTipoDeDietaDataRow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div style="padding: 1px;">
    <asp:TextBox runat="server" ID="Mode" Text="" Style="display: none;"></asp:TextBox>
    <asp:TextBox runat="server" ID="EntityId" Text="" Style="display: none;"></asp:TextBox>
    <div class="hdr-thickbox" runat="server" id="DEMO">
        <div runat="server" id="TitleInsert" visible="false">
            Definir un Nueva Unidad de Medida
        </div>
        <div runat="server" id="TitleUpdate" visible="false">
            Editar Unidad de Medida
        </div>
        <div runat="server" id="TitleDelete" visible="false">
            Eliminar Unidad de Medida
        </div>
    </div>
    <table cellpadding="0" cellpadding="0" border="0" width="100%" class="tbl-abm">
        <tr>
            <td class="td-label">
                Código <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCodigo" Width="50" MaxLength="20" Style="display: block;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodigo"
                    ErrorMessage="El código para la Unidad de Medida es requerido!" Display="Dynamic"
                    CssClass="display-error" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="El código para la Unidad de Medida ya existe!"
                    ControlToValidate="txtCodigo" CssClass="display-error" EnableClientScript="false"
                    Display="Dynamic" SetFocusOnError="true" OnServerValidate="ValidarCodigo" ></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="td-label">
                Descripción <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtUnidadDeMedida" Width="300" MaxLength="100" Style="display: block;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUnidadDeMedida"
                    ErrorMessage="La descripción para la Unidad de Medida es requerida!" Display="Dynamic"
                    CssClass="display-error" SetFocusOnError="true"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="La descripción para la Unidad de Medida ya existe!"
                    ControlToValidate="txtUnidadDeMedida" CssClass="display-error" EnableClientScript="false"
                    Display="Dynamic" SetFocusOnError="true" OnServerValidate="ValidarNombre"></asp:CustomValidator>
            </td>
        </tr>
    </table>
    <!-- BOTONES -->
    <div id="cnt-buttons">
        <!-- BOTON GRABAR  -->
        <div class="btnCrearUsuario" runat="server" id="btnSaveNewRecord" visible="false">
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="true" OnClick="GrabarUnidadDeMedida">
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
