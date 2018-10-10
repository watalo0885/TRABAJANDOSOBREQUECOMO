<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMasterSinMenu.master"
    AutoEventWireup="true" CodeFile="EncuestasView.aspx.cs" Inherits="Clientes_Encuestas_EncuestasView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../UserControls/UserData.ascx" TagName="UserData" TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH_Body" runat="Server">

    <style type="text/css">
        .textbox
        {
            border: solid 1px #abadb3;
            font-size: 12px;
            width: 50px;
            font-family: Arial;
            padding: 2px;
        }
        .textbox-nros
        {
            border: solid 1px #abadb3;
            font-size: 12px;
            width: 50px;
            text-align: right;
            font-family: Arial;
            padding: 2px;
        }
        #cnt-listview .datatable
        {
            width: 100%;
            border: solid 1px #f2f2f2;
        }
        #cnt-listview .datatable tr:hover
        {
        }
        .hd_detalle
        {
            background-color: #cfe1f4;
            color: Black;
            height: 34px;
            text-align: center;
            font-size: 12px;
            font-weight: bold;
        }
    </style>
    <div class="admin-cnt-body">
        <div class="admin-header-body">
            <div style="float:left;">
                <h4>
                    <b>Encuesta Nro <asp:Literal runat="server" ID="ltrNroEncuesta" ></asp:Literal></b></h4>
                    
            </div>
            <div style="float: right;font-size:11px;padding-right:10px;">
                <asp:HyperLink runat="server" ID="link" Text="Ir a Lista de Encuestas" NavigateUrl="EncuestasList.aspx" style="color:Blue;background-color:Transparent;"></asp:HyperLink>
            </div>
        </div>
    </div>
    <!-- 
        UPDATE PROGRESS 
     -->
    <asp:UpdateProgress ID="progress1" runat="server">
        <ProgressTemplate>
            <div id="espere" class="inprogress" runat="server">
                Espere un momento...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="updPanelMain" runat="server">
        <ContentTemplate>
            <div>
                <asp:Literal runat="server" ID="mensaje"></asp:Literal>
            </div>
            <div id="cnt_general" visible="false" runat="server">
                <div style="padding: 5px; padding-left: 10px; font-size: 11px; color: #406287;border-bottom:dashed 1px #696969;padding-bottom:5px;background-color:#edeff4;width:98.3%;">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 80px;">
                                Encuestador
                            </td>
                            <td>
                                <asp:TextBox ID="txtEncuestador" runat="server" MaxLength="50" Width="200" CssClass="textbox" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 100px; padding-left: 10px;">
                                Apellido y Nombre
                            </td>
                            <td>
                                <asp:TextBox ID="txtApeNom" runat="server" MaxLength="100" Width="200" CssClass="textbox" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" runat="server" ErrorMessage="*" ControlToValidate="txtApeNom"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 80px; padding-left: 10px;">
                                Tipo de dieta
                            </td>
                            <td>
                                <asp:DropDownList ID="cboTipoDeDieta" runat="server" DataSourceID="odsTipoDeDieta" Enabled="false"
                                    DataTextField="Tipodedieta" DataValueField="tipodedietaId" CssClass="textbox"
                                    Style="text-align: left;" Width="190">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Direccion
                            </td>
                            <td>
                                <asp:TextBox ID="txtDireccion" runat="server" MaxLength="100" Width="200" CssClass="textbox" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="true" runat="server" ErrorMessage="*" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                            </td>
                            <td style="padding-left: 10px;">
                                Teléfono
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelefono" runat="server" MaxLength="100" Width="200" CssClass="textbox" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="padding-left: 10px;">
                                Sexo
                            </td>
                            <td>
                                <asp:DropDownList ID="cboSexo" runat="server" CssClass="textbox" Width="120" Style="text-align: left;" Enabled="false">
                                    <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                                    <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Edad
                            </td>
                            <td>
                                <asp:TextBox ID="txtEdad" runat="server" MaxLength="2" Width="30" CssClass="textbox" Enabled="false"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars"
                                    FilterType="Custom" TargetControlID="txtEdad" ValidChars="0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td style="padding-left: 10px;">
                                Peso
                            </td>
                            <td>
                                <asp:TextBox ID="txtPeso" runat="server" MaxLength="3" Width="50" CssClass="textbox-nros" Enabled="false"></asp:TextBox>&nbsp;Kgs
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="true" runat="server" ErrorMessage="*" ControlToValidate="txtPeso"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars"
                                    FilterType="Custom" TargetControlID="txtPeso" ValidChars=".0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td style="padding-left: 10px;">
                                Talla
                            </td>
                            <td>
                                <asp:TextBox ID="txtTalla" runat="server" MaxLength="5" Width="50" CssClass="textbox-nros" Enabled="false"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars"
                                    FilterType="Custom" TargetControlID="txtTalla" ValidChars=".0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                IMC
                            </td>
                            <td>
                                <asp:TextBox ID="txtIMC" runat="server" MaxLength="5" Width="50" CssClass="textbox-nros" Enabled="false"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars"
                                    FilterType="Custom" TargetControlID="txtIMC" ValidChars=".0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td colspan="4" align="right">
                                <asp:Literal runat="server" ID="ltrMensajeHeader"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="admin-cnt-body" style="border-bottom: solid 1px #dedede;">
                    <table style="font-family: Arial; font-size: 11px; width: 100%;">
                        <tr>
                            <td style="vertical-align: top; width: 20%;padding:3px;">
                                <!-- LISTVIEW PARA COMPLETAR -->
                                <asp:ListView ID="lvEncuesta" runat="server" DataSourceID="odsTipoDeAlimentos" OnItemCommand="lvEncuesta_ItemCommand"
                                    OnDataBound="lvEncuesta_DataBound">
                                    <LayoutTemplate>
                                        <div style="clear: both;">
                                            <!-- LAYOUT TEMPLATE -->
                                            <table id="tbGeneric" runat="server" class="datatable" cellpadding="0" cellspacing="0"
                                                border="0" style="width: 100%;">
                                                <tr>
                                                    <td style="padding: 3px; font-size: 11px; background-color: #82a4c7; color: White;">
                                                        Seleccione la categoría que desea cargar
                                                    </td>
                                                </tr>
                                                <tr id="itemPlaceholder" runat="server" />
                                            </table>
                                        </div>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr id="row" style="line-height: 20px">
                                            <td style="background-color: #f6f6f6; color: Black; font-family: Arial,Tahoma; font-size: 11px;
                                                padding-left: 10px; height: 20px;" colspan="9">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Select" CommandArgument='<%# Eval("TipoDeAlimentoId") %>'
                                                    Style="color: Blue; background-color: Transparent;"><%# Eval("TipoDeAlimento") %></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <SelectedItemTemplate>
                                        <tr id="row" style="line-height: 20px">
                                            <td style="background-color: #696969; color: white; font-family: Arial,Tahoma; font-size: 12px;
                                                padding-left: 10px; height: 20px;" colspan="9">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="Select" CommandArgument='<%# Eval("TipoDeAlimentoId") %>'
                                                    Style="color: white; background-color: Transparent;"><%# Eval("TipoDeAlimento") %></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </SelectedItemTemplate>
                                    <EmptyDataTemplate>
                                        <div class="lv-empty" style="clear: both;">
                                            No hemos encontrado Encuestas definidas!
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:ListView>
                            </td>
                            <td style="padding:3px; vertical-align: top; width: 80%;border-left:dashed 1px #696969;">
                                <asp:ListView ID="lvDetail" runat="server" OnItemDataBound="lvDetail_DataBound">
                                    <LayoutTemplate>
                                        <table id="tbGeneric" runat="server" class="datatable" cellpadding="5" cellspacing="1"
                                            border="0" style="width: 100%;">
                                            <tr>
                                                <td class="hd_detalle">
                                                    Codigo
                                                </td>
                                                <td class="hd_detalle">
                                                    Alimento
                                                </td>
                                                <td class="hd_detalle">
                                                    Nunca
                                                </td>
                                                <td class="hd_detalle">
                                                    Veces x Mes
                                                </td>
                                                <td class="hd_detalle">
                                                    Veces x Semana
                                                </td>
                                                <td class="hd_detalle">
                                                    Veces x Día
                                                </td>
                                                <td class="hd_detalle">
                                                    Porción Pequeña
                                                </td>
                                                <td class="hd_detalle">
                                                    Porción Mediana
                                                </td>
                                                <td class="hd_detalle">
                                                    Porción Grande
                                                </td>
                                            </tr>
                                            <tr runat="server" id="itemPlaceholder" />
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr id="item" runat="server" style="display: ;">
                                            <td align="center" style="font-size: 12px;">
                                                <asp:Label runat="server" ID="AlimentoCodigo" Text='<%# Eval("Codigo")%>'></asp:Label>
                                                <asp:Label runat="server" ID="AlimentoId" Style="display: none;" Text='<%# Eval("AlimentoId")%>'></asp:Label>
                                                <asp:Label runat="server" ID="Pequeña" Style="display: none;" Text='<%# Eval("Pequeña")%>'></asp:Label>
                                                <asp:Label runat="server" ID="Mediana" Style="display: none;" Text='<%# Eval("Mediana")%>'></asp:Label>
                                                <asp:Label runat="server" ID="Grande" Style="display: none;" Text='<%# Eval("Grande")%>'></asp:Label>
                                            </td>
                                            <td style="font-size: 12px;">
                                                <%# Eval("Nombre")%>
                                            </td>
                                            <td align="center">
                                                <asp:CheckBox ID="chkNunca" runat="server" Checked='<%# Eval("Nunca")%>' AutoPostBack="false" Enabled="false"/>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtVM" runat="server" Text='<%# Eval("VecesPorMes")%>' MaxLength="4"
                                                    CssClass="textbox" Style="text-align: right;" Enabled="false" ></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                                    TargetControlID="txtVM" FilterMode="ValidChars" ValidChars="0123456789">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtVS" runat="server" Text='<%# Eval("VecesPorSemana")%>' MaxLength="4"
                                                    CssClass="textbox" Style="text-align: right;"  Enabled="false"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom"
                                                    TargetControlID="txtVS" FilterMode="ValidChars" ValidChars="0123456789">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtVD" runat="server" Text='<%# Eval("VecesPorDia")%>' MaxLength="4"
                                                    CssClass="textbox" Style="text-align: right;" Enabled="false"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Custom"
                                                    TargetControlID="txtVD" FilterMode="ValidChars" ValidChars="0123456789">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="center">
                                                <asp:RadioButton ID="radioP" Checked='<%# Eval("PorcionPequeña")%>' runat="server"
                                                    AutoPostBack="false" Enabled="false"/>
                                            </td>
                                            <td align="center">
                                                <asp:RadioButton ID="radioM" Checked='<%# Eval("PorcionMediana")%>' runat="server"
                                                    AutoPostBack="false" Enabled="false" />
                                            </td>
                                            <td align="center">
                                                <asp:RadioButton ID="radioG" Checked='<%# Eval("PorcionGrande")%>' runat="server"
                                                    AutoPostBack="false" Enabled="false" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsTipoDeDieta" runat="server" OldValuesParameterFormatString="original_{0}"
        OnSelecting="odsTipoDeDieta_Selecting" SelectMethod="Search" TypeName="Interfood.Business.TipoDeDietaBus">
        <SelectParameters>
            <asp:Parameter Name="EntityFilter" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTipoDeAlimentos" runat="server" OldValuesParameterFormatString="original_{0}"
        OnSelecting="odsTipoDeAlimentos_Selecting" SelectMethod="Search" TypeName="Interfood.Business.TipoDeAlimentosBus">
        <SelectParameters>
            <asp:Parameter Name="EntityFilter" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
