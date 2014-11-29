<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrowserTypeAndIp.aspx.cs" Inherits="_01.BrowserTypeAndIp.BrowserTypeAndIp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label AssociatedControlID="LiteralBrowserType" runat="server"></asp:Label>
            <asp:Literal ID="LiteralBrowserType" runat="server"></asp:Literal>
            <br />
            <asp:Label AssociatedControlID="LiteralIp" runat="server"></asp:Label>
            <asp:Literal ID="LiteralIp" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
