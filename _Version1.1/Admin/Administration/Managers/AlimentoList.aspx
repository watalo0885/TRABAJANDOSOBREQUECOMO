<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="AlimentoList.aspx.cs" Inherits="Admin_Administration_Managers_AlimentoList" %>

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
            <b>Alimentos</b></div>
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
                            <!-- NUEVO ALIMENTO -->
                            <div class="btnCrearUsuario" style="width: 99.3%;">
                                <div style="float: left;">
                                    <a id="callThickbox1" name="callThickbox1" class="thickbox" runat="server" title="&nbsp;"
                                        href="EditAlimentoDataRow.aspx?Mode=Insert&TB_iframe=true&MODAL=true&height=400&width=600">
                                        <div style="width: 140px;">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/Default/Images/add_16.png"
                                                Style="float: left;" />
                                            <span class="lbl-btnCrearUsuario">Agregar Alimento</span>
                                        </div>
                                    </a>
                                </div>
                                <div style="float: right; width: 450px; padding:5px 2px;">
                                    <span style="color: #696969; font-size: 12px;">Buscar Alimento:</span>&nbsp;<asp:TextBox
                                        ID="txtSearchAlimento" runat="server" Text="" MaxLength="100" Width="200" Style="font-size: 11px;
                                        padding: 2px; color: #696969;"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" Text="Buscar" Style="border: solid 1px #696969;
                                        color: Black; font-size: 11px; width: 51px;" OnClick="Filtrar_Click" CommandName="BUSCAR" Height="20px" Width="52px" />
                                    <asp:Button ID="Button2" runat="server" Text="Ver Todos" Style="border: solid 1px #696969;
                                        color: Black; font-size: 11px;" OnClick="Filtrar_Click" CommandName="TODOS" Height="20px" Width="75px" />
                                </div>
                                <div style="clear: both;">
                                </div>
                            </div>
                            <!-- BOTON REFRESH -->
                            <asp:Button runat="server" ID="btnRefresh" OnClick="btnRefresh_Click" Style="display: none;" />
                            <!-- LISTVIEW  -->
                            <asp:ListView ID="lvGeneric" runat="server" DataSourceID="odsAlimentos" OnItemDataBound="ItemDataBound_lvGeneric"
                                OnItemCommand="ItemCommand_lvGeneric" 
                                onpagepropertieschanged="lvGeneric_PagePropertiesChanged" EnableModelValidation="True">
                                <LayoutTemplate>
                                    <div style="clear: both;">
                                        <!-- LAYOUT TEMPLATE -->
                                        <table id="tbGeneric" runat="server" class="datatable" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <th style="width: 40px;">
                                                    &nbsp;
                                                </th>
                                                <th>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Sort" CommandArgument="Codigo"
                                                        Text="Código" />
                                                </th>
                                                <th>
                                                    <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Sort" CommandArgument="Nombre"
                                                        Text="Nombre" />
                                                </th>
                                                <th>
                                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Sort" CommandArgument="TipoDeAlimento"
                                                        Text="Tipo de Alimento" />
                                                </th>
                                                <th>
                                                    <asp:LinkButton ID="LinkButton10" runat="server" CommandName="Sort" CommandArgument="Estacional" 
                                                        Text="Es Estacional" />
                                                </th>
                                                <th style="width: 70px;">
                                                    <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Sort" CommandArgument="Pequeña"
                                                        Text="Pequeña" />
                                                </th>
                                                <th>
                                                    <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Sort" CommandArgument="Mediana"
                                                        Text="Mediana" />
                                                </th>
                                                <th>
                                                    <asp:LinkButton ID="LinkButton7" runat="server" CommandName="Sort" CommandArgument="Grande"
                                                        Text="Grande" />
                                                </th>
                                                <th>
                                                    <asp:LinkButton ID="LinkButton9" runat="server" CommandName="Sort" CommandArgument="OrdenDeVisualizacion"
                                                        Text="Orden" />
                                                </th>
                                                <th>
                                                    <asp:LinkButton ID="LinkButton8" runat="server" CommandName="Sort" CommandArgument="Estado"
                                                        Text="Estado" />
                                                </th>
                                            </tr>
                                            <tr id="itemPlaceholder" runat="server" />
                                        </table>
                                        <div id="lv-pager">
                                            <div>
                                                <asp:DataPager ID="pagerBottom" runat="server" PageSize="10">
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
                                        <td align="center">
                                            <a id="callThickbox1" name="callThickbox1" class="thickbox" runat="server" title="&nbsp;"
                                                href='<%# Eval("AlimentoId","EditAlimentoDataRow.aspx?Mode=update&id={0}&TB_iframe=true&MODAL=true&height=400&width=600") %>'>
                                                <img src="../../../App_Themes/Default/Images/edit_16.png" style="float: left; padding: 3px;
                                                    border: solid 1px transparent;" title="Editar Alimento" alt="" />
                                            </a>
                                            <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/App_Themes/Default/Images/delete.png"
                                                CommandName="Eliminar" CommandArgument='<%# Eval("AlimentoId") + "|" + Eval("Nombre") %>'
                                                CausesValidation="false" ToolTip="Eliminar Alimento" Style="padding: 3px; border: solid 1px transparent;" />
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
                                                        <b>ELIMINAR ALIMENTO</b>
                                                    </div>
                                                    <div style="padding: 5px;">
                                                        <h4>
                                                            ¿Seguro que desea ELIMINAR el Alimento "<span style="color: Green;"><%# Eval("Codigo") + " - " + Eval("Nombre") %></span>" ?
                                                        </h4>
                                                    </div>
                                                    <div style="padding: 5px; float: right;">
                                                        <asp:Button ID="ButtonOk" CausesValidation="false" runat="server" Text=" Si " />
                                                        <asp:Button ID="ButtonCancel" CausesValidation="false" runat="server" Text=" No " />
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="close" CausesValidation="false" />
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                        </td>
                                        <td style="width: 60px; text-align: center;">
                                            <%# Eval("Codigo") %>
                                        </td>
                                        <td>
                                            <%# Eval("Nombre") %>
                                        </td>
                                        <td>
                                            <%# Eval("TipoDeAlimento") == DBNull.Value ? "&nbsp;" : Eval("TipoDeAlimento")%>
                                        </td>
                                        <td>
                                            <%# Eval("Estacional") %>
                                        </td>
                                        <td style="width: 70px; text-align: right; padding-right: 4px;">
                                            <%# Eval("Pequeña") %>
                                        </td>
                                        <td style="width: 70px; text-align: right; padding-right: 4px;">
                                            <%# Eval("Mediana")%>
                                        </td>
                                        <td style="width: 70px; text-align: right; padding-right: 4px;">
                                            <%# Eval("Grande")%>
                                        </td>
                                        <td style="width: 70px; text-align: right; padding-right: 4px;">
                                            <%# Eval("OrdendeVisualizacion")%>
                                        </td>
                                        <td style="width: 50px; text-align: center;">
                                            <img src="../../../App_Themes/Default/Images/flags/flag_green.png" visible="false"
                                                runat="server" id="imgActivo" title="Alimento Activo" />
                                            <img src="../../../App_Themes/Default/Images/flags/flag_red.png" visible="false"
                                                runat="server" id="imgInactivo" title="Alimento Inactivo" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyItemTemplate>
                                    <div style="padding: 4px; border: solid 1px #86a6ca;">
                                        No hay Alimentos definidos!
                                    </div>
                                </EmptyItemTemplate>
                            </asp:ListView>
                            <div style="padding: 5px 10px;">
                                <asp:Literal ID="ltrMessage" runat="server"></asp:Literal>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <asp:ObjectDataSource ID="odsAlimentos" runat="server" OldValuesParameterFormatString="original_{0}"
            OnSelecting="odsAlimentos_Selecting" SelectMethod="Search" TypeName="Interfood.Business.vAlimentosBus">
            <SelectParameters>
                <asp:Parameter Name="EntityFilter" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
