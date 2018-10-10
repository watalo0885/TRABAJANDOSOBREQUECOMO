<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="EncuestasList.aspx.cs" Inherits="Clientes_Encuestas_EncuestasList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControls/UserData.ascx" TagName="UserData" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_Menu" runat="Server">
    <div>
        <uc1:UserData ID="UserData1" runat="server" />
        <uc2:Menu ID="Menu1" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CPH_Body" runat="Server">
    <style type="text/css">
        .btnLetra
        {
            border: solid 1px #c0c0c0;
            background-color: #cfe1f4;
            color: #6689ae;
            padding: 2px;
            cursor: pointer;
            cursor: hand;
        }
    </style>
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <div class="admin-cnt-body.">
        <div class="admin-header-body">
            <h4>
                <b>Lista de Encuestas</b></h4>
        </div>
        <div style="padding: 2px;">
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
                <!-- UPDATE PANEL -->
                <asp:UpdatePanel ID="updPanelMain" runat="server">
                    <ContentTemplate>
                        <!-- NUEVO ALIMENTO -->
                        <div class="btnCrearUsuario">
                            <asp:LinkButton ID="lnkNuevaDieta" runat="server" OnClick="lnkNuevaDieta_Click">
                                <div style="width: 130px;">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/Default/Images/add_16.png"
                                        Style="float: left;" />
                                    <span class="lbl-btnCrearUsuario">Nueva Encuesta</span>
                                </div>
                            </asp:LinkButton>
                        </div>
                        <!-- BOTON REFRESH -->
                        <asp:TextBox runat="server" ID="txtFiltro" Text="" Style="display: none;"></asp:TextBox>
                        <asp:Button runat="server" ID="btnRefresh" Style="display: none;" />
                        <div>
                            <!-- AGREGAR NUTRIENTE -->
                            <div class="btnCrearUsuario" runat="server" id="btnAgregarNutrientes">
                            </div>
                            <!-- MENSAJES -->
                            <div style="float: left; padding: 15px;">
                                <asp:Literal runat="server" ID="ltrMessage"></asp:Literal>
                            </div>
                        </div>
                        <!-- LISTVIEW  -->
                        <asp:ListView ID="lvGeneric" runat="server" DataSourceID="odsEncuestas" OnItemDataBound="ItemDataBound_lvGeneric"
                            OnItemCommand="ItemCommand_lvGeneric">
                            <LayoutTemplate>
                                <div style="clear: both;">
                                    <!-- LAYOUT TEMPLATE -->
                                    <table id="tbGeneric" runat="server" class="datatable" cellpadding="0" cellspacing="0"
                                        border="0">
                                        <tr>
                                            <th>
                                                &nbsp;
                                            </th>
                                            <th>
                                                &nbsp;
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton1" runat="server" Text="#" CommandName="Sort" CommandArgument="EncuestaNro" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton3" runat="server" Text="Fecha" CommandName="Sort" CommandArgument="Fecha" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton4" runat="server" Text="Apellido y Nombre" CommandName="Sort"
                                                    CommandArgument="ApeNom" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton5" runat="server" Text="Telefono" CommandName="Sort"
                                                    CommandArgument="Telefono" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton6" runat="server" Text="Sexo" CommandName="Sort" CommandArgument="Sexo" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton7" runat="server" Text="Edad" CommandName="Sort" CommandArgument="Edad" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton8" runat="server" Text="Peso" CommandName="Sort" CommandArgument="Peso" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton9" runat="server" Text="Dieta" CommandName="Sort" CommandArgument="TipoDeDieta" />
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
                                                                    (<%# Container.TotalRowCount %>
                                                                    items found) </b>
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
                                    <td align="center" style="width: 25px;">
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Default/Images/edit_16.png"
                                            PostBackUrl='<%# Eval("EncuestaNro","~/Clientes/Encuestas/EncuestasAdd.aspx?EncuestaNro={0}") %>'
                                            CausesValidation="false" ToolTip="Modificar Encuesta" Style="padding: 3px; border: solid 1px transparent;" />
                                    </td>
                                    <td align="center" style="width: 20px;">
                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/App_Themes/Default/Images/delete.png"
                                            CommandName="Eliminar" CommandArgument='<%# Eval("EncuestaNro") %>' CausesValidation="false"
                                            ToolTip="Eliminar Encuesta" Style="padding: 3px; border: solid 1px transparent;" />
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
                                                    <b>ELIMINAR ENCUESTA</b>
                                                </div>
                                                <div style="padding: 5px; font-size: 12px;">
                                                    <h4>
                                                        Seguro que desea ELIMINAR la Encuesta NRO <span style="color: Green;">
                                                            <%# Eval("EncuestaNro")%>
                                                        </span>?
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
                                    <td style="width: 40px;">
                                        <%# Eval("EncuestaNro")%>
                                    </td>
                                    <td style="width: 80px;">
                                        <%# Eval("Fecha") == DBNull.Value ? "&nbsp;" : ((DateTime)Eval("Fecha")).ToString("dd/MM/yyyy")%>
                                    </td>
                                    <td style="width: 200px;">
                                        <%# Eval("ApeNom") == DBNull.Value ? "&nbsp;" : Eval("ApeNom")%>
                                    </td>
                                    <td style="width: 200px;">
                                        <%# Eval("Telefono") == DBNull.Value ? "&nbsp;" : Eval("Telefono")%>
                                    </td>
                                    <td style="width: 60px;">
                                        <%# Eval("Sexo") == DBNull.Value ? "&nbsp;" : Eval("Sexo")%>
                                    </td>
                                    <td style="width: 60px;">
                                        <%# Eval("Edad") == DBNull.Value ? "&nbsp;" : Eval("Edad")%>
                                    </td>
                                    <td style="width: 60px;">
                                        <%# Eval("Peso") == DBNull.Value ? "&nbsp;" : Eval("Peso")%>
                                    </td>
                                    <td>
                                        <%# Eval("TipoDeDieta") == DBNull.Value ? "&nbsp;" : Eval("TipoDeDieta")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <div class="lv-empty" style="clear: both;">
                                    No hemos encontrado Encuestas definidas!
                                </div>
                            </EmptyDataTemplate>
                        </asp:ListView>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="odsEncuestas" runat="server" OldValuesParameterFormatString="original_{0}"
        OnSelecting="odsEncuestas_Selecting" SelectMethod="Search" TypeName="Interfood.Business.vEncuestaHeaderBus">
        <SelectParameters>
            <asp:Parameter Name="EntityFilter" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
