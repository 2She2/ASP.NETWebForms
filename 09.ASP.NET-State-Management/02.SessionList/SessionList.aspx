<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionList.aspx.cs" Inherits="_02.SessionList.SessionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonAppendText" runat="server" OnClick="ButtonAppendText_Click" Text="Append" />
            <br />
            <br />
            Messages:
            <br />
            <asp:Label ID="LabelSessionText" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
