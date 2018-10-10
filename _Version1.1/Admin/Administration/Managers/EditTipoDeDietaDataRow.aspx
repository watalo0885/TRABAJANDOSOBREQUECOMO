<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditTipoDeDietaDataRow.aspx.cs"
    Inherits="EditTipoDeDietaDataRow" %>

<%@ Register src="UserControls/EditTipoDeDietaDataRow.ascx" tagname="EditTipoDeDietaDataRow" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Interfood</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <uc1:EditTipoDeDietaDataRow ID="EditTipoDeDietaDataRow1" runat="server" />
    </div>
    </form>
</body>
</html>
