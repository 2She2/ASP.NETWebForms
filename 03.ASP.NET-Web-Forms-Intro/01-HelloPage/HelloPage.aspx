<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloPage.aspx.cs" Inherits="_01_HelloPage.HelloPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="HelloPage" runat="server">
        <div>
            <asp:Label ID="LabelName" Text="Enter name" runat="server"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonShowName" onclick="ButtonShowName_Click" Text="Show name" runat="server" />
            <br />
            <asp:Panel ID="PaneName" runat="server"></asp:Panel>
        </div>
    </form>
</body>
</html>
