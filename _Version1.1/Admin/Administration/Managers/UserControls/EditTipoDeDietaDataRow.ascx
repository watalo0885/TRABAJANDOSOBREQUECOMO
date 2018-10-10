<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditTipoDeDietaDataRow.ascx.cs"
    Inherits="EditTipoDeDietaDataRow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div style="padding: 1px;">
    <asp:TextBox runat="server" ID="Mode" Text="" Style="display: none;"></asp:TextBox>
    <asp:TextBox runat="server" ID="EntityId" Text="" Style="display: none;"></asp:TextBox>
    <div class="hdr-thickbox" runat="server" id="DEMO">
        <div runat="server" id="TitleInsert" visible="false">
            Definir un Nuevo Tipo de Dieta
        </div>
        <div runat="server" id="TitleUpdate" visible="false">
            Editar Tipo de Dieta
        </div>
        <div runat="server" id="TitleDelete" visible="false">
            Eliminar Tipo de Dieta
        </div>
    </div>
    <table cellpadding="0" cellpadding="0" border="0" width="100%" class="tbl-abm">
        <tr>
            <td class="td-label">
                Descripción <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTipoDeDieta" Width="300" MaxLength="100" Style="display: block;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTipoDeDieta"
                    ErrorMessage="La descripción para el tipo de dieta es requerido!" Display="Dynamic"
                    CssClass="display-error" SetFocusOnError="true"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="El Tipo de Dieta elegido ya existe!"
                    ControlToValidate="txtTipoDeDieta" CssClass="display-error" EnableClientScript="false"
                    Display="Dynamic" SetFocusOnError="true" OnServerValidate="ValidarNombre"></asp:CustomValidator>
            </td>
        </tr>
    </table>
    <!-- BOTONES -->
    <div id="cnt-buttons">
        <!-- BOTON GRABAR NUEVO USUARIO -->
        <div class="btnCrearUsuario" runat="server" id="btnSaveNewRecord" visible="false">
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="true" OnClick="GrabarTipoDeDieta">
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
