<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.master"
    AutoEventWireup="true" CodeFile="EncuestasList.aspx.cs" Inherits="Clientes_Encuestas_EncuestasList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../UserControls/UserData.ascx" TagName="UserData" TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/Menu.ascx" TagName="Menu" TagPrefix="uc2" %>
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
                        <!-- BOTON REFRESH -->
                        <asp:TextBox runat="server" ID="txtFiltro" Text="" Style="display: none;"></asp:TextBox>
                        <asp:Button runat="server" ID="btnRefresh" Style="display: none;" />
                        <!-- LISTVIEW  -->
                        <asp:ListView ID="lvGeneric" runat="server" DataSourceID="odsEncuestas" OnItemDataBound="ItemDataBound_lvGeneric">
                            <LayoutTemplate>
                                <div style="clear: both;">
                                    <!-- LAYOUT TEMPLATE -->
                                    <table id="tbGeneric" runat="server" class="datatable" cellpadding="0" cellspacing="0"
                                        border="0">
                                        <tr>
                                            <th style="text-align: center; font-size: 10px; font-weight: normal;">
                                                Exportar <b>Alimentos</b>
                                            </th>
                                            <th style="text-align: center; font-size: 10px; font-weight: normal;">
                                                Exportar <b>Nutrientes</b>
                                            </th>
                                            <th style="text-align: center; font-size: 10px; font-weight: normal;">
                                                Exportar <b>Nutrientes por Alimento</b>
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton1" runat="server" Text="#" CommandName="Sort" CommandArgument="EncuestaNro" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton3" runat="server" Text="Fecha" CommandName="Sort" CommandArgument="Fecha" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton4" runat="server" Text="Apellido y Nombre" CommandName="Sort"
                                                    CommandArgument="Apellido" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton5" runat="server" Text="Empresa" CommandName="Sort"
                                                    CommandArgument="Empresa" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton6" runat="server" Text="TelefonoFijo1" CommandName="Sort"
                                                    CommandArgument="Telefono" />
                                            </th>
                                            <th>
                                                <asp:LinkButton ID="LinkButton7" runat="server" Text="Email" CommandName="Sort" CommandArgument="Email" />
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
                                    <td align="center" style="text-align: center; width: 60px;">
                                        <img src="../../../Images/excel.png" id="ImgXlsAlimentos" runat="server" alt="" title="Exportar Alimentos de Encuesta a Excel"
                                            style="border: 0px; cursor: hand; cursor: pointer;" />
                                    </td>
                                    <td align="center" style="text-align: center; width: 60px;">
                                        <img src="../../../Images/excel.png" id="ImgXlsNutrientes" runat="server" alt=""
                                            title="Exportar Alimentos de Encuesta a Excel" style="border: 0px; cursor: hand;
                                            cursor: pointer;" />
                                    </td>
                                    <td align="center" style="text-align: center; width: 60px;">
                                        <img src="../../../Images/excel.png" id="ImgXlsNutrientesPorAlimentos" runat="server"
                                            alt="" title="Exportar Alimentos de Encuesta a Excel" style="border: 0px; cursor: hand;
                                            cursor: pointer;" />
                                    </td>
                                    <td style="width: 40px; text-align: center;">
                                        <%# Eval("EncuestaNro")%>
                                    </td>
                                    <td style="width: 80px;">
                                        <%# Eval("Fecha") == DBNull.Value ? "&nbsp;" : ((DateTime)Eval("Fecha")).ToString("dd/MM/yyyy")%>
                                    </td>
                                    <td style="width: 200px;">
                                        <%# Eval("Apellido").ToString() + " " + Eval("Nombres").ToString() %>
                                    </td>
                                    <td style="width: 200px;">
                                        <%# Eval("Empresa").ToString() %>
                                    </td>
                                    <td style="width: 100px;">
                                        <%# Eval("TelefonoFijo1") == DBNull.Value ? "&nbsp;" : Eval("TelefonoFijo1")%>
                                    </td>
                                    <td style="width: 200px;">
                                        <%# Eval("Email") == DBNull.Value ? "&nbsp;" : Eval("Email")%>
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
                <div style="padding: 20px;" id="AllExport" runat="server">
                    <div style="padding: 5px 10px;">
                        <asp:LinkButton ID="LinkButton10" runat="server" OnClientClick="window.open('../../../GenerarXls.aspx?EncuestaNro=0&Listado=1');return false;"
                            ToolTip="Exportar todas las Encuesta de Alimentos a Excel">
                            <div style="width: 500px;">
                                <img src="../../../Images/excel.png" id="ImgAllAlimentos" runat="server" alt="" style="border: 0px;
                                    cursor: hand; cursor: pointer;" />
                                &nbsp; <span class="lbl-btnCrearUsuario">Exportar <b>ALIMENTOS</b> de TODAS las Encuestas</span>
                            </div>
                        </asp:LinkButton>
                    </div>
                    <div style="padding: 5px 10px;">
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="window.open('../../../GenerarXls.aspx?EncuestaNro=0&Listado=2');return false;"
                            ToolTip="Exportar todas las Encuesta de Nutrientes a Excel">
                            <div style="width: 500px;">
                                <img src="../../../Images/excel.png" id="ImgAllNutrientes" runat="server" alt=""
                                    style="border: 0px; cursor: hand; cursor: pointer;" />
                                &nbsp; <span class="lbl-btnCrearUsuario">Exportar <b>NUTRIENTES</b> de TODAS las Encuestas</span>
                            </div>
                        </asp:LinkButton>
                    </div>
                    <div style="padding: 5px 10px;">
                        <asp:LinkButton ID="LinkButton11" runat="server" OnClientClick="window.open('../../../GenerarXls.aspx?EncuestaNro=0&Listado=3');return false;"
                            ToolTip="Exportar todas las Encuesta de Nutrientes por Alimentos a Excel">
                            <div style="width: 500px;">
                                <img src="../../../Images/excel.png" id="ImgAllAlimentosNutrientes" runat="server"
                                    alt="" style="border: 0px; cursor: hand; cursor: pointer;" />
                                &nbsp; <span class="lbl-btnCrearUsuario">Exportar <b>Alimentos</b> de TODAS las Encuestas</span>
                            </div>
                        </asp:LinkButton>
                    </div>

                </div>
                <div style="padding: 20px;" id="Div1" runat="server">
                    <div style="padding: 5px 10px;">
                        <asp:LinkButton ID="LinkButton8" runat="server" OnClientClick="window.open('../../../GenerarXls.aspx?EncuestaNro=0&Listado=1');return false;"
                            ToolTip="Exportar todas las Encuesta de Alimentos a Excel con nueva disposición">
                            <div style="width: 500px;">
                                <img src="../../../Images/excel.png" id="Img1" runat="server" alt="" style="border: 0px;
                                    cursor: hand; cursor: pointer;" />
                                &nbsp; <span class="lbl-btnCrearUsuario">Exportar <b>Nueva disposicion de ALIMENTOS</b> de TODAS las Encuestas</span>
                            </div>
                        </asp:LinkButton>
                    </div>
                    <div style="padding: 5px 10px;">
                        <asp:LinkButton ID="LinkButton9" runat="server" OnClientClick="window.open('../../../GenerarXls.aspx?EncuestaNro=0&Listado=2');return false;"
                            ToolTip="Exportar todas las Encuesta de Nutrientes a Excel con nueva disposición">
                            <div style="width: 500px;">
                                <img src="../../../Images/excel.png" id="Img2" runat="server" alt=""
                                    style="border: 0px; cursor: hand; cursor: pointer;" />
                                &nbsp; <span class="lbl-btnCrearUsuario">Exportar <b>Nueva disposicion de NUTRIENTES</b> de TODAS las Encuestas</span>
                            </div>
                        </asp:LinkButton>
                    </div>
                    <div style="padding: 5px 10px;">
                        <asp:LinkButton ID="LinkButton12" runat="server" OnClientClick="window.open('../../../GenerarXls.aspx?EncuestaNro=0&Listado=3');return false;"
                            ToolTip="Exportar todas las Encuesta de Nutrientes por Alimentos a Excel con nueva disposición">
                            <div style="width: 500px;">
                                <img src="../../../Images/excel.png" id="Img3" runat="server"
                                    alt="" style="border: 0px; cursor: hand; cursor: pointer;" />
                                &nbsp; <span class="lbl-btnCrearUsuario">Exportar <b>Nueva disposicion de Alimentos</b> de TODAS las Encuestas</span>
                            </div>
                        </asp:LinkButton>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="odsEncuestas" runat="server" OldValuesParameterFormatString="original_{0}"
        OnSelecting="odsEncuestas_Selecting" SelectMethod="Search" TypeName="Interfood.Business.vEncuestaHeaderBus"
        OnSelected="odsEncuestas_Selected">
        <SelectParameters>
            <asp:Parameter Name="EntityFilter" Type="Object" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
