<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMasterSinMenu.master"
    AutoEventWireup="true" CodeFile="EncuestasAdd.aspx.cs" Inherits="Clientes_Encuestas_EncuestasAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/UserData.ascx" TagName="UserData" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH_Body" runat="Server">

    <script language="javascript" type="text/javascript">

        var txtPeso = '<%= txtPeso.ClientID %>';
        var txtTalla = '<%= txtTalla.ClientID %>';
        var txtIMC = '<%= txtIMC.ClientID %>';
        
        function blurText(source, tiempo) {
            //---------------------------------------
            //--- Row del check seleccionado
            //---------------------------------------
            var row = source.parentNode.parentNode;

            var check = row.getElementsByTagName("td")[2].getElementsByTagName("input")[0];
            var vxm = row.getElementsByTagName("td")[3].getElementsByTagName("input")[0];
            var vxs = row.getElementsByTagName("td")[4].getElementsByTagName("input")[0];
            var vxd = row.getElementsByTagName("td")[5].getElementsByTagName("input")[0];

            if (source.value != '') {
                if (tiempo == 'M') vxs.value = "";
                if (tiempo == 'S') vxm.value = "";
            }

            if (tiempo == 'D' && (vxd.value == NaN || vxd.value == '')) vxd.value = "1";
        }

        function clickRadio(source, porcion) {
            //---------------------------------------
            //--- Row del check seleccionado
            //---------------------------------------
            var row = source.parentNode.parentNode;

            var check = row.getElementsByTagName("td")[2].getElementsByTagName("input")[0];
            var peq = row.getElementsByTagName("td")[6].getElementsByTagName("input")[0];
            var med = row.getElementsByTagName("td")[7].getElementsByTagName("input")[0];
            var gra = row.getElementsByTagName("td")[8].getElementsByTagName("input")[0];

            if (check.checked == false) {
                if (porcion == 'P') {
                    med.checked = false;
                    gra.checked = false;
                }
                if (porcion == 'M') {
                    peq.checked = false;
                    gra.checked = false;
                }
                if (porcion == 'G') {
                    peq.checked = false;
                    med.checked = false;
                }
            }
            else {
                peq.checked = false;
                med.checked = false;
                gra.checked = false;
            }
        }

        function clickCheck(source) {
            //---------------------------------------
            //--- Row del check seleccionado
            //---------------------------------------
            var row = source.parentNode.parentNode;

            var vxm = row.getElementsByTagName("td")[3].getElementsByTagName("input")[0];
            var vxs = row.getElementsByTagName("td")[4].getElementsByTagName("input")[0];
            var vxd = row.getElementsByTagName("td")[5].getElementsByTagName("input")[0];
            var peq = row.getElementsByTagName("td")[6].getElementsByTagName("input")[0];
            var med = row.getElementsByTagName("td")[7].getElementsByTagName("input")[0];
            var gra = row.getElementsByTagName("td")[8].getElementsByTagName("input")[0];

            if (source.checked == true) {
                //----------------------------------
                //-- Marco el check
                //----------------------------------
                vxm.disabled = true;
                vxs.disabled = true;
                vxd.disabled = true;
                peq.disabled = true;
                med.disabled = true;
                gra.disabled = true;
                vxm.value = "";
                vxs.value = "";
                vxd.value = "";
                peq.checked = false;
                med.checked = false;
                gra.checked = false;
            }
            else {
                //----------------------------------
                //-- Desmarco el check
                //----------------------------------
                vxm.value = "";
                vxs.value = "";
                vxd.value = "1";
                peq.checked = true;
                med.checked = false;
                gra.checked = false;
                //------------------------- disabled
                vxm.disabled = false;
                vxs.disabled = false;
                vxd.disabled = false;
                peq.disabled = false;
                med.disabled = false;
                gra.disabled = false;
            }
        }


        function CalcularIMC() {
            try {
                var talla2 = document.getElementById(txtTalla).value * document.getElementById(txtTalla).value;
                var imc = document.getElementById(txtPeso).value / talla2;
                document.getElementById(txtIMC).value = imc.toFixed(2);
            }
            catch (err) {
                document.getElementById(txtIMC).value = "0.00";
            }
        }
    </script>

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
                <asp:HyperLink runat="server" ID="link" Text="Ir a Lista de Encuestas" NavigateUrl="~/Clientes/Encuestas/EncuestasList.aspx" style="color:Blue;background-color:Transparent;"></asp:HyperLink>
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
                                <asp:TextBox ID="txtEncuestador" runat="server" MaxLength="50" Width="200" CssClass="textbox"></asp:TextBox>
                            </td>
                            <td style="width: 100px; padding-left: 10px;">
                                Apellido y Nombre
                            </td>
                            <td>
                                <asp:TextBox ID="txtApeNom" runat="server" MaxLength="100" Width="200" CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" runat="server" ErrorMessage="*" ControlToValidate="txtApeNom"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 80px; padding-left: 10px;">
                                Tipo de dieta
                            </td>
                            <td>
                                <asp:DropDownList ID="cboTipoDeDieta" runat="server" DataSourceID="odsTipoDeDieta"
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
                                <asp:TextBox ID="txtDireccion" runat="server" MaxLength="100" Width="200" CssClass="textbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError="true" runat="server" ErrorMessage="*" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                            </td>
                            <td style="padding-left: 10px;">
                                Teléfono
                            </td>
                            <td>
                                <asp:TextBox ID="txtTelefono" runat="server" MaxLength="100" Width="200" CssClass="textbox"></asp:TextBox>
                            </td>
                            <td style="padding-left: 10px;">
                                Sexo
                            </td>
                            <td>
                                <asp:DropDownList ID="cboSexo" runat="server" CssClass="textbox" Width="120" Style="text-align: left;">
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
                                <asp:TextBox ID="txtEdad" runat="server" MaxLength="2" Width="30" CssClass="textbox" ></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars"
                                    FilterType="Custom" TargetControlID="txtEdad" ValidChars="0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td style="padding-left: 10px;">
                                Peso
                            </td>
                            <td>
                                <asp:TextBox ID="txtPeso" runat="server" MaxLength="3" Width="50" CssClass="textbox-nros" onblur="CalcularIMC();"></asp:TextBox>&nbsp;Kgs
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="true" runat="server" ErrorMessage="*" ControlToValidate="txtPeso"></asp:RequiredFieldValidator>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars"
                                    FilterType="Custom" TargetControlID="txtPeso" ValidChars=".0123456789">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td style="padding-left: 10px;">
                                Talla 
                            </td>
                            <td>
                                <asp:TextBox ID="txtTalla" runat="server" MaxLength="5" Width="50" CssClass="textbox-nros" onblur="CalcularIMC();"></asp:TextBox>
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
                                <asp:Button ID="btnSaveCabecera" runat="server" Text="Grabar Cabecera de Encuesta" 
                                    onclick="btnSaveCabecera_Click"  />
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
                                        <div style="padding: 10px;">
                                            <asp:Button ID="Button1" runat="server" Text="Grabar Alimentos" OnClick="Save" CausesValidation="true" />
                                            <asp:Literal runat="server" ID="ltrMensaje"></asp:Literal>
                                        </div>
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
                                                <asp:CheckBox ID="chkNunca" runat="server" Checked='<%# Eval("Nunca")%>' AutoPostBack="false"
                                                    onclick="clickCheck(this);" />
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtVM" runat="server" Text='<%# Eval("VecesPorMes")%>' MaxLength="4"
                                                    CssClass="textbox" Style="text-align: right;" onblur="blurText(this,'M');"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                                    TargetControlID="txtVM" FilterMode="ValidChars" ValidChars="0123456789">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtVS" runat="server" Text='<%# Eval("VecesPorSemana")%>' MaxLength="4"
                                                    CssClass="textbox" Style="text-align: right;" onblur="blurText(this,'S');"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom"
                                                    TargetControlID="txtVS" FilterMode="ValidChars" ValidChars="0123456789">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtVD" runat="server" Text='<%# Eval("VecesPorDia")%>' MaxLength="4"
                                                    CssClass="textbox" Style="text-align: right;" onblur="blurText(this,'D');"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Custom"
                                                    TargetControlID="txtVD" FilterMode="ValidChars" ValidChars="0123456789">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="center">
                                                <asp:RadioButton ID="radioP" Checked='<%# Eval("PorcionPequeña")%>' runat="server"
                                                    AutoPostBack="false" onclick="clickRadio(this,'P');" />
                                            </td>
                                            <td align="center">
                                                <asp:RadioButton ID="radioM" Checked='<%# Eval("PorcionMediana")%>' runat="server"
                                                    AutoPostBack="false" onclick="clickRadio(this,'M');" />
                                            </td>
                                            <td align="center">
                                                <asp:RadioButton ID="radioG" Checked='<%# Eval("PorcionGrande")%>' runat="server"
                                                    AutoPostBack="false" onclick="clickRadio(this,'G');" />
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
