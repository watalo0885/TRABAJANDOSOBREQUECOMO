<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="NutrientesPorAlimentoList.aspx.cs" Inherits="Admin_Administration_Managers_AlimentoNutriente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../UserControls/UserData.ascx" TagName="UserData" TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_Menu" runat="Server">
    <uc1:UserData ID="UserData1" runat="server" />
    <uc2:Menu ID="Menu1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH_Body" runat="Server">
    <style>
        .btnLetra
        {
            border: solid 1px #c0c0c0;
            background-color: #cfe1f4;
            color: #6689ae;
            cursor: pointer;
            cursor: hand;
            font-size: 12px;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function Refresh() {
            document.getElementById('<%= btnRefresh.ClientID %>').click();
        }

        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                tb_init('a.thickbox');
            }
        }
        function updated() {
            tb_remove();
        }    
    </script>

    <div class="admin-cnt-body">
        <div class="admin-header-body">
            <b>Nutrientes por Alimento</b></div>
        <div style="padding: 10px;">
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
            <div id="cnt-listview">
                <div>
                    <!-- UPDATE PANEL -->
                    <asp:UpdatePanel ID="updPanelMain" runat="server">
                        <ContentTemplate>
                            <!-- BOTON REFRESH -->
                            <asp:TextBox runat="server" ID="txtFiltro" Text="" Style="display: none;"></asp:TextBox>
                            <asp:Button runat="server" ID="btnRefresh" OnClick="btnRefresh_Click" Style="display: none;" />
                            <!-- ALIMENTO -->
                            <div>
                                <div style="padding: 5px; padding-bottom: 20px; float: left;">
                                    Alimento
                                    <asp:DropDownList ID="cboAlimentos" runat="server" DataSourceID="odsAlimentos" DataTextField="Nombre"
                                        DataValueField="AlimentoId" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="cboAlimentos_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Text="-- Seleccione un Alimento --" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- NUTRIENTES DEL ALIMENTO -->
                                <div style="padding: 5px; padding-bottom: 20px; float: left;">
                                    Nutrientes
                                    <asp:DropDownList ID="cboNutrientes" runat="server" AutoPostBack="true" Width="200" AppendDataBoundItems="true" OnSelectedIndexChanged="cboNutrientes_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Text="-- Seleccione Nutriente --" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                 <!-- FUENTE DEL ALIMENTO -->
                                <div style="padding: 5px; padding-bottom: 20px; float: left;">
                                    Fuente
                                    <asp:DropDownList ID="cboFuentes" runat="server" AutoPostBack="true" Width="200" AppendDataBoundItems="true" OnSelectedIndexChanged="cboNutrientes_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Text="-- Seleccione Fuente --" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div style="clear:both;"></div>
                            </div>
                            <div>
                                <!-- AGREGAR NUTRIENTE -->
                                <div class="btnCrearUsuario" runat="server" id="btnAgregarNutrientes">
                                    <asp:LinkButton ID="lnkAddNutriente" runat="server" ToolTip="Agregar Nutrientes"
                                        CausesValidation="true" Style="float: left;" OnClick="lnkAddNutriente_Click">
                                        <div style="width: 150px;">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/Default/Images/add_16.png"
                                                Style="float: left;" />
                                            &nbsp;<span>Agregar Nutrientes</span>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <!-- GRABAR NUTRIENTE -->
                                <div class="btnCrearUsuario" runat="server" id="btnGrabar" visible="false">
                                    <asp:LinkButton ID="imgSaveAll" runat="server" ToolTip="Grabar todo" CausesValidation="true"
                                        OnClick="Grabar" Style="float: left;">
                                        <div style="width: 70px;">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Default/Images/BtnSave.png"
                                                Style="float: left;" />
                                            &nbsp;<span>Grabar</span>
                                        </div>
                                    </asp:LinkButton>
                                </div>
                                <!-- MENSAJES -->
                                <div style="float: left; padding: 15px;">
                                    <asp:Literal runat="server" ID="ltrMessage"></asp:Literal>
                                </div>
                            </div>
                            <!-- LISTVIEW  -->
                            <asp:ListView ID="lvGeneric" runat="server" OnItemDataBound="ItemDataBound_lvGeneric"
                                OnItemCommand="ItemCommand_lvGeneric" OnPagePropertiesChanged="lvGeneric_PagePropertiesChanged">
                                <LayoutTemplate>
                                    <div style="clear: both;">
                                        <!-- LAYOUT TEMPLATE -->
                                        <table id="tbGeneric" runat="server" class="datatable" cellpadding="0" cellspacing="0"
                                            border="0">
                                            <tr>
                                                <th align="center" style="padding-left: 10px;">
                                                    &nbsp;
                                                </th>
                                                <th>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" Text="Nutriente" />
                                                </th>
                                                <th>
                                                    <asp:LinkButton ID="LinkButton4" runat="server" Text="Cantidad" />
                                                </th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server" />
                                        </table>
                                        <div id="lv-pager">
                                            <div>
                                                <asp:DataPager ID="pagerBottom" runat="server" PageSize="20">
                                                    <Fields>
                                                        <asp:NextPreviousPagerField ButtonCssClass="command" FirstPageText="«" PreviousPageText="‹"
                                                            RenderDisabledButtonsAsLabels="true" ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                                            ShowLastPageButton="false" ShowNextPageButton="false" />
                                                        <asp:NumericPagerField ButtonCount="7" NumericButtonCssClass="command" CurrentPageLabelCssClass="current"
                                                            NextPreviousButtonCssClass="command" />
                                                        <asp:NextPreviousPagerField ButtonCssClass="command" LastPageText="»" NextPageText="›"
                                                            RenderDisabledButtonsAsLabels="true" ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                                            ShowLastPageButton="true" ShowNextPageButton="true" />
                                                        <asp:TemplatePagerField>
                                                            <PagerTemplate>
                                                                <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                                <div style="display: inline;">
                                                                    Page <b>
                                                                        <%# Container.TotalRowCount > 0 ? Math.Ceiling(((double)(Container.StartRowIndex + Container.MaximumRows) / Container.MaximumRows)) : 0 %>
                                                                    </b>of <b>
                                                                        <%# Math.Ceiling((double)Container.TotalRowCount / Container.MaximumRows)%>
                                                                        (<%# Container.TotalRowCount %>items found) </b>
                                                                </div>
                                                                <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                            </PagerTemplate>
                                                        </asp:TemplatePagerField>
                                                    </Fields>
                                                </asp:DataPager>
                                                <div style="display: inline;">
                                                    <asp:DropDownList ID="cboPageSize" runat="server" OnSelectedIndexChanged="ChangeCantRows"
                                                        AutoPostBack="true" Style="height: 20px; font-size: 10px;">
                                                        <asp:ListItem Text="View 10 rows" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="View 20 rows" Value="20"></asp:ListItem>
                                                        <asp:ListItem Text="View 50 rows" Value="50"></asp:ListItem>
                                                        <asp:ListItem Text="View 100 rows" Value="100"></asp:ListItem>
                                                        <asp:ListItem Text="View 200 rows" Value="200"></asp:ListItem>
                                                        <asp:ListItem Text="View 500 rows" Value="500"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr id="item" runat="server" class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                                        <td align="center" style="width: 20px;">
                                            <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/App_Themes/Default/Images/delete.png"
                                                CommandName="Eliminar" CommandArgument='<%# Eval("NutrienteId") %>' CausesValidation="false"
                                                ToolTip="Eliminar Nutriente" Style="padding: 3px; border: solid 1px transparent;" />
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnDelete"
                                                DisplayModalPopupID="ModalPopupExtender1">
                                            </cc1:ConfirmButtonExtender>
                                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnDelete"
                                                PopupControlID="PNL" PopupDragHandleControlID="headerConfirm" OkControlID="ButtonOk"
                                                CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" />
                                            <asp:Panel ID="PNL" runat="server" Style="display: none; border: solid 3px #6084a8;
                                                background-color: White; width: 400px; padding: 2px;">
                                                <div runat="server" id="headerConfirm">
                                                    <div style="background-color: #8aabcd; color: White; padding: 4px; font-size: 14px;
                                                        font-family: Century Gothic,Verdana,Arial;">
                                                        <b>ELIMINAR NUTRIENTE</b>
                                                    </div>
                                                    <div style="padding: 5px;">
                                                        <h4>
                                                            Seguro que desea ELIMINAR el Nutriente [ <span style="color: Green;">
                                                                <%# Eval("NutrienteNombre")%></span> ] ?
                                                        </h4>
                                                    </div>
                                                    <div style="padding: 5px; float: right;">
                                                        <asp:Button ID="ButtonOk" CausesValidation="false" runat="server" Text=" Yes " />
                                                        <asp:Button ID="ButtonCancel" CausesValidation="false" runat="server" Text=" No " />
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="close" CausesValidation="false" />
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                        </td>
                                        <td style="width: 300px;">
                                            <%# Eval("NutrienteNombre") %>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtCantidad" MaxLength="7" Text='<%# Eval("AlimentoNutrienteCantidad") %>'
                                                Width="80" Style="text-align: right; font-size: 12px; border: solid 1px #a9a9a9;
                                                padding: 2px;"></asp:TextBox>
                                            <asp:TextBox runat="server" ID="txtNutrienteId" Text='<%# Eval("NutrienteId") %>'
                                                Width="80" Style="display: none;"></asp:TextBox>
                                            &nbsp;<span style="font-size: 12px;"><%# Eval("NutrienteUDMId") %></span><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom"
                                                TargetControlID="txtCantidad" FilterMode="ValidChars" ValidChars=" .0123456789">
                                            </cc1:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCantidad"
                                                ErrorMessage="El valor ingresado para la Cantidad no es válido!" Display="Dynamic"
                                                CssClass="display-error" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <div class="lv-empty" style="clear: both;">
                                        No hemos encontrado Nutrientes para el Alimento seleccionado!
                                    </div>
                                </EmptyDataTemplate>
                            </asp:ListView>
                            <br />
                            <div runat="server" id="divAddNutrientes" visible="false" style="clear: both;">
                                <p>
                                    <h3 style="color: #555555;">
                                        Nutrientes para agregar al Alimento</h3>
                                    <p>
                                    </p>
                                    <!-- LISTVIEW NUTRIENTES PARA AGREGAR -->
                                    <div style="padding: 4px;">
                                        Filtrar
                                        <asp:Button ID="Button36" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="Ver todos" />
                                        <asp:Button ID="btnA" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="a" />
                                        <asp:Button ID="btnB" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="b" />
                                        <asp:Button ID="btnC" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="c" />
                                        <asp:Button ID="Button1" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="d" />
                                        <asp:Button ID="Button2" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="e" />
                                        <asp:Button ID="Button3" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="f" />
                                        <asp:Button ID="Button4" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="g" />
                                        <asp:Button ID="Button5" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="h" />
                                        <asp:Button ID="Button6" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="i" />
                                        <asp:Button ID="Button7" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="j" />
                                        <asp:Button ID="Button8" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="k" />
                                        <asp:Button ID="Button9" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="l" />
                                        <asp:Button ID="Button10" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="ll" />
                                        <asp:Button ID="Button11" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="m" />
                                        <asp:Button ID="Button12" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="n" />
                                        <asp:Button ID="Button13" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="ñ" />
                                        <asp:Button ID="Button14" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="o" />
                                        <asp:Button ID="Button15" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="p" />
                                        <asp:Button ID="Button16" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="q" />
                                        <asp:Button ID="Button17" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="r" />
                                        <asp:Button ID="Button18" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="s" />
                                        <asp:Button ID="Button19" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="t" />
                                        <asp:Button ID="Button20" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="u" />
                                        <asp:Button ID="Button21" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="v" />
                                        <asp:Button ID="Button22" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="w" />
                                        <asp:Button ID="Button23" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="x" />
                                        <asp:Button ID="Button24" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="y" />
                                        <asp:Button ID="Button25" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="z" />
                                        <asp:Button ID="Button26" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="1" />
                                        <asp:Button ID="Button27" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="2" />
                                        <asp:Button ID="Button28" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="3" />
                                        <asp:Button ID="Button29" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="4" />
                                        <asp:Button ID="Button30" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="5" />
                                        <asp:Button ID="Button31" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="6" />
                                        <asp:Button ID="Button32" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="7" />
                                        <asp:Button ID="Button33" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="8" />
                                        <asp:Button ID="Button34" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="9" />
                                        <asp:Button ID="Button35" runat="server" CssClass="btnLetra" OnClick="Filtrar" Text="0" />
                                    </div>
                                    <asp:ListView ID="lvAddNutrientes" runat="server" OnPagePropertiesChanged="lvAddNutrientes_PagePropertiesChanged">
                                        <LayoutTemplate>
                                            <div style="clear: both;">
                                                <!-- LAYOUT TEMPLATE -->
                                                <table id="tbGeneric" runat="server" border="0" cellpadding="0" cellspacing="0" class="datatable">
                                                    <tr>
                                                        <th>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Nutriente" />
                                                        </th>
                                                        <th>
                                                            <asp:LinkButton ID="LinkButton4" runat="server" Text="Cantidad" />
                                                        </th>
                                                    </tr>
                                                    <tr id="itemPlaceholder" runat="server" />
                                                </table>
                                                <div id="lv-pager">
                                                    <div>
                                                        <asp:DataPager ID="pagerBottom" runat="server" PageSize="10">
                                                            <Fields>
                                                                <asp:NextPreviousPagerField ButtonCssClass="command" FirstPageText="«" PreviousPageText="‹"
                                                                    RenderDisabledButtonsAsLabels="true" ShowFirstPageButton="true" ShowLastPageButton="false"
                                                                    ShowNextPageButton="false" ShowPreviousPageButton="true" />
                                                                <asp:NumericPagerField ButtonCount="7" CurrentPageLabelCssClass="current" NextPreviousButtonCssClass="command"
                                                                    NumericButtonCssClass="command" />
                                                                <asp:NextPreviousPagerField ButtonCssClass="command" LastPageText="»" NextPageText="›"
                                                                    RenderDisabledButtonsAsLabels="true" ShowFirstPageButton="false" ShowLastPageButton="true"
                                                                    ShowNextPageButton="true" ShowPreviousPageButton="false" />
                                                                <asp:TemplatePagerField>
                                                                    <PagerTemplate>
                                                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                                        <div style="display: inline;">
                                                                            Page <b>
                                                                                <%# Container.TotalRowCount > 0 ? Math.Ceiling(((double)(Container.StartRowIndex + Container.MaximumRows) / Container.MaximumRows)) : 0 %>
                                                                            </b>of <b>
                                                                                <%# Math.Ceiling((double)Container.TotalRowCount / Container.MaximumRows)%>
                                                                                (<%# Container.TotalRowCount %>items found) </b>
                                                                        </div>
                                                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                                    </PagerTemplate>
                                                                </asp:TemplatePagerField>
                                                            </Fields>
                                                        </asp:DataPager>
                                                        <div style="display: inline;">
                                                            <asp:DropDownList ID="cboPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ChangeCantRowsNutrientes"
                                                                Style="height: 20px; font-size: 10px;">
                                                                <asp:ListItem Text="View 10 rows" Value="10"></asp:ListItem>
                                                                <asp:ListItem Text="View 20 rows" Value="20"></asp:ListItem>
                                                                <asp:ListItem Text="View 50 rows" Value="50"></asp:ListItem>
                                                                <asp:ListItem Text="View 100 rows" Value="100"></asp:ListItem>
                                                                <asp:ListItem Text="View 200 rows" Value="200"></asp:ListItem>
                                                                <asp:ListItem Text="View 500 rows" Value="500"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr id="item" runat="server" class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                                                <td style="width: 300px;">
                                                    <%# Eval("NutrienteNombre") %>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCantidad" runat="server" MaxLength="7" Style="text-align: right;
                                                        font-size: 12px; border: solid 1px #a9a9a9; padding: 2px;" Text='<%# Eval("AlimentoNutrienteCantidad") %>'
                                                        ValidationGroup="AddNutriente" Width="80"></asp:TextBox>
                                                    <asp:TextBox ID="txtNutrienteId" runat="server" Style="display: none;" Text='<%# Eval("NutrienteId") %>'
                                                        Width="80"></asp:TextBox>
                                                    &nbsp;<span style="font-size: 12px;"><%# Eval("NutrienteUDMId") %></span><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars"
                                                        FilterType="Custom" TargetControlID="txtCantidad" ValidChars=" .0123456789">
                                                    </cc1:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCantidad"
                                                        CssClass="display-error" Display="Dynamic" ErrorMessage="El valor ingresado para la Cantidad no es válido!"
                                                        SetFocusOnError="true" ValidationGroup="AddNutriente"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <div class="lv-empty" style="clear: both;">
                                                No hemos encontrado Nutrientes para agregar al Alimento seleccionado!
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                </p>
                            </div>
                            <!-- AGREGAR NUTRIENTE -->
                            <div class="btnCrearUsuario" runat="server" id="divBtnAddNutrientes" visible="false">
                                <asp:LinkButton ID="lnkBtnAddNutrientes" runat="server" ToolTip="Agregar Nutrientes"
                                    CausesValidation="true" OnClick="AgregarNutrientes" Style="float: left;">
                                    <div style="width: 210px;">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/App_Themes/Default/Images/BtnSave.png"
                                            Style="float: left;" />
                                        &nbsp;<span>Grabar Nutrientes agregados</span>
                                    </div>
                                </asp:LinkButton>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <asp:ObjectDataSource ID="odsAlimentos" runat="server" OldValuesParameterFormatString="original_{0}"
            OnSelecting="odsAlimentos_Selecting" SelectMethod="Search" TypeName="Interfood.Business.AlimentoBus">
            <SelectParameters>
                <asp:Parameter Name="EntityFilter" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
