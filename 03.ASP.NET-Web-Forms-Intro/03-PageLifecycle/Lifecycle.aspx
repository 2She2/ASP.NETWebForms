<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lifecycle.aspx.cs" Inherits="_03_PageLifecycle.Lifecycle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page Lifecycle</title>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:Button ID="ButtonTest" Text="Test" runat="server"
            OnInit="ButtonTest_Init" OnLoad="ButtonTest_Load" OnClick="ButtonTest_Click"
            OnPreRender="ButtonTest_PreRender" OnUnload="ButtonTest_Unload" />
    </form>
</body>
</html>
