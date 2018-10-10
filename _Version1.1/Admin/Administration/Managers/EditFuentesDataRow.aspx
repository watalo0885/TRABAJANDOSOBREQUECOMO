<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditFuentesDataRow.aspx.cs" 
    Inherits="EditFuentesDattaRow" %>

<%@ Register Src="UserControls/EditFuentesDataRow.ascx"  TagName="EditFuentesDataRow" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Que-Como</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
    
        <uc1:EditFuentesDataRow ID="EditFuentesDataRow1" runat="server" />    

    </div>
    </form>
</body>
</html>
