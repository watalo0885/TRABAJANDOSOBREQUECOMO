<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EditAlimentoDataRow.ascx.cs"
    Inherits="Admin_Administration_UserManager_UserControls_EditAlimentoDataRow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style type="text/css">
    .auto-style1 {
        height: 27px;
    }
</style>
<div style="padding: 1px;">
    <asp:TextBox runat="server" ID="Mode" Text="" Style="display: none;"></asp:TextBox>
    <asp:TextBox runat="server" ID="EntityId" Text="" Style="display: none;"></asp:TextBox>
    <div class="hdr-thickbox" runat="server" id="DEMO">
        <div runat="server" id="TitleInsert" visible="false">
            Definir un Nuevo Alimento
        </div>
        <div runat="server" id="TitleUpdate" visible="false">
            Editar Alimento
        </div>
        <div runat="server" id="TitleDelete" visible="false">
            Eliminar Alimento
        </div>
    </div>
    <table cellpadding="0" cellpadding="0" border="0" width="100%" class="tbl-abm">
        <tr>
            <td class="td-label">
                Codigo Interno <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtCodigo" Width="300" MaxLength="50" Style="display: block;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCodigo"
                    ErrorMessage="El Código es un requerido1" Display="Dynamic" CssClass="display-error"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="El código elegido ya existe!"
                    ControlToValidate="txtCodigo" CssClass="display-error" EnableClientScript="false"
                    Display="Dynamic" SetFocusOnError="true" OnServerValidate="ValidarCodigo"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="td-label">
                Nombre <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtNombre" Width="400" MaxLength="200" Style="display: block;"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre"
                    ErrorMessage="El Nombre es requerido!" Display="Dynamic" CssClass="display-error"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="El Nombre del Alimento ya existe!"
                    ControlToValidate="txtNombre" CssClass="display-error" EnableClientScript="false"
                    Display="Dynamic" SetFocusOnError="true" OnServerValidate="ValidarNombre"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="td-label">
                Tipo de Alimento
            </td>
            <td class="auto-style1">
                <asp:DropDownList ID="cboTipoDeAlimento" runat="server" Style="font-size: 12px;"
                    DataSourceID="odsTipoDeAlimentos" DataTextField="TipoDeAlimento" DataValueField="TipoDeAlimentoId">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cboTipoDeAlimento"
                    ErrorMessage="El Tipo de Alimento es requerido!" Display="Dynamic" CssClass="display-error"
                    SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
           <td class="td-label">
                Es estacional <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:DropDownList ID="cboEstacional" runat="server" Style="font-size: 12px;">
                    <asp:ListItem Selected="false" Text="NO" Value="NO"></asp:ListItem>
                    <asp:ListItem Text="SI" Value="SI"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="td-label">
                Porción Pequeña <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPequeña" MaxLength="7" Width="50" Style="display: block;
                    text-align: right;"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                    TargetControlID="txtPequeña" FilterMode="ValidChars" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPequeña"
                    ErrorMessage="El valor para la porción Pequeña es requerido!" Display="Dynamic"
                    CssClass="display-error" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="td-label">
                Porción Mediana <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtMediana" MaxLength="7" Width="50" Style="display: block;
                    text-align: right;"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom"
                    TargetControlID="txtMediana" FilterMode="ValidChars" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMediana"
                    ErrorMessage="El valor para la porción Mediana es requerido!" Display="Dynamic"
                    CssClass="display-error" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="td-label">
                Porción Grande <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtGrande" MaxLength="7" Width="50" Style="display: block;
                    text-align: right;"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom"
                    TargetControlID="txtGrande" FilterMode="ValidChars" ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtGrande"
                    ErrorMessage="El valor para la porción Grande es requerido!" Display="Dynamic"
                    CssClass="display-error" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="td-label">
                Estado <span style="color: Red;">*</span>
            </td>
            <td>
                <asp:DropDownList ID="cboEstado" runat="server" Style="font-size: 12px;">
                    <asp:ListItem Selected="True" Text="Activo" Value="ACT"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="INACT"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="td-label">
                Orden de Visualizacion <span style="color: Red;">*</span>
            </td>
            <td>
               <asp:TextBox runat="server" ID="txtOrdenDeVisualizacion" MaxLength="4" Width="50" Style="display: block;
                    text-align: right;"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                    TargetControlID="txtOrdenDeVisualizacion" FilterMode="ValidChars" ValidChars="0123456789">
                </cc1:FilteredTextBoxExtender>
            </td>
        </tr>
    </table>
    <!-- BOTONES -->
    <div id="cnt-buttons">
        <!-- BOTON GRABAR NUEVO USUARIO -->
        <div class="btnCrearUsuario" runat="server" id="btnSaveNewRecord" visible="false">
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="true" OnClick="GrabarAlimento">
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
<asp:ObjectDataSource ID="odsTipoDeAlimentos" runat="server" OldValuesParameterFormatString="original_{0}"
    OnSelecting="odsTipoDeAlimentos_Selecting" SelectMethod="Search" TypeName="Interfood.Business.TipoDeAlimentosBus">
    <SelectParameters>
        <asp:Parameter Name="EntityFilter" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
