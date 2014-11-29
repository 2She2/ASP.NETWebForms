<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HtmlEscaping.aspx.cs" Inherits="_03_HtmlEscaping.HtmlEscaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formHtmlEscaping" runat="server">
    <div>
        <asp:TextBox ID="TextBoxInputText" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonShowEscapedText" OnClick="ShowEscapedText_Click" Text="Show text" runat="server" />
        <br />
        Escaped text:
        <asp:TextBox ID="TextBoxEscapedText" runat="server"></asp:TextBox>
        <br />
        Escaped text:
        <asp:Label ID="LabelEscapedText" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
