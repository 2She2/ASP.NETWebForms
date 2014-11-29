<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="Sumator.Sumator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sumator</title>
</head>
<body>
    <form id="SumatorForm" runat="server">
        <h1>Sumator</h1>
        First Number
        <asp:TextBox id="TextFirstNumber" runat="server"></asp:TextBox>
        <br />
        Second Number
        <asp:TextBox ID="TextSecondNumber" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonSum" runat="server" OnClick="ButtonCalculateSum_Click" Text="Calculate sum" />
        <br />
        <asp:Label ID="LabelSum" Text="Sum" runat="server"></asp:Label>
        <asp:TextBox ID="TextSum" runat="server"></asp:TextBox>
    </form>
</body>
</html>
