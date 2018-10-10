<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleManager.aspx.cs" Inherits="Admin_RoleManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="grid">
            <div class="mid">
                <!-- 
                    UPDATE PROGRESS 
                -->
                <asp:UpdateProgress ID="progress1" runat="server" AssociatedUpdatePanelID="updPanelMain">
                    <ProgressTemplate>
                        <div id="Div1" class="inprogress" runat="server">
                            Wait a moment please...
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="updPanelMain" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <!-- TITULO -->
                        <div class="gridtitle">
                            Roles List
                        </div>
                        <asp:ListView ID="lvRoleManager" runat="server" DataSourceID="odsRoles" OnItemCommand="lvRoleManager_ItemCommand">
                            <LayoutTemplate>
                                <div style="clear: both;">
                                    <!-- LAYOUT TEMPLATE -->
                                    <table id="tbUsers" runat="server" class="datatable" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <th>
                                                &nbsp;
                                            </th>
                                            <th>
                                                Roles
                                            </th>
                                            <th>
                                                Description
                                            </th>
                                           <%-- <th>
                                                Category
                                            </th>--%>
                                            <th>
                                                Default For New User
                                            </th>
                                        </tr>
                                        <tr id="itemPlaceholder" runat="server" />
                                    </table>
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr id="item" runat="server" class='<%# Container.DataItemIndex % 2 == 0 ? "row" : "altrow" %>'>
                                    <td align="center">
                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../Images/delete.png" CommandName="Eliminar"
                                            CommandArgument='<%# Eval("RoleName") %>' CausesValidation="false" ToolTip="Delete Role" />
                                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnDelete"
                                            DisplayModalPopupID="ModalPopupExtender1">
                                        </cc1:ConfirmButtonExtender>
                                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnDelete"
                                            PopupControlID="PNL" PopupDragHandleControlID="headerConfirm" OkControlID="ButtonOk"
                                            CancelControlID="ButtonCancel" BackgroundCssClass="modalBackground" />
                                        <asp:Panel ID="PNL" runat="server" CssClass="confirm-dialog" Style="display: none;">
                                            <div class="inner" runat="server" id="headerConfirm">
                                                <h2>
                                                    Are you sure you want delete the Role [
                                                    <%# Eval("RoleName")%>
                                                    ] ?
                                                </h2>
                                                <div class="base">
                                                    <asp:Button ID="ButtonOk" CausesValidation="false" runat="server" Text=" Yes " />
                                                    <asp:Button ID="ButtonCancel" CausesValidation="false" runat="server" Text=" No " />
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="close" CausesValidation="false" />
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        </span>
                                    </td>
                                    <td>
                                        <%# Eval("RoleName") %>
                                    </td>
                                    <td>
                                        <%# Eval("Description") %>
                                    </td>
                                   <%-- <td>
                                        <%# Eval("Category") %>
                                    </td>--%>
                                    <td>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Eval("DefaultForNewUser")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                        <div style="margin-top: 20px; padding: 5px;">
                            <table>
                                <tr>
                                    <td style="width: 120px;">
                                        Create New Role
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRoleName" runat="server" Width="300" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRoleName"
                                            Display="None" SetFocusOnError="true" ErrorMessage="Enter a Role Name!!"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Role Description
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRoleDescription" runat="server" Width="300" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRoleDescription"
                                            Display="None" SetFocusOnError="true" ErrorMessage="Enter a Role Description!!"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td>
                                        Category
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboCategory" runat="server" DataSourceID="odsCategory" DataTextField="category"
                                            DataValueField="category">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cboCategory"
                                            Display="None" SetFocusOnError="true" ErrorMessage="Enter a Category!!"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>--%>
                            </table>
                            <div style="padding-top: 10px;">
                                <asp:Button ID="btnCreateNewRole" runat="server" Text="Create Role" OnClick="btnCreateNewRole_Click" />
                            </div>
                            <!-- ERRORES -->
                            <div class="containerErrors">
                                <asp:ValidationSummary ID="vsNewReferred" runat="server" CssClass="summaryErrors" />
                                <div style="color: Red;">
                                    <asp:Literal ID="ltrError" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <asp:ObjectDataSource ID="odsRoles" runat="server" OldValuesParameterFormatString="original_{0}"
            OnSelecting="odsRoles_Selecting" SelectMethod="Search" TypeName="Chenso.Business.aspnet_RolesBus">
            <SelectParameters>
                <asp:Parameter Name="EntityFilter" Type="Object" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
