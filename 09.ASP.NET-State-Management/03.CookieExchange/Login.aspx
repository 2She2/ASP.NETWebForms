<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_03.CookieExchange.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LabelLogedin" Text="" runat="server"></asp:Label>
        <br />
        <asp:Button ID="ButtonLogin" runat="server" 
            OnClick="ButtonLogin_Click" 
            Text="Login"
            Visible="true" />
        <br />
        <br />
        <asp:Button ID="ButtonGoToPrivateInfo" runat="server" 
            OnClick="ButtonGoToPrivateInfo_Click"
            Text="Go to Private Info" />
    </div>
    </form>
</body>
</html>
