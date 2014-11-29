<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumbers.aspx.cs" Inherits="_02_RandomNumbersWebCtrls.RandomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formRandomNumbers" runat="server">
        <div>
            <asp:Label ID="LabelMinNumber" AssociatedControlID="TextBoxMinNumber" runat="server">Min number</asp:Label>
            <asp:TextBox ID="TextBoxMinNumber" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelMaxNumber" AssociatedControlID="TextBoxMaxNumber" runat="server">Max number</asp:Label>
            <asp:TextBox ID="TextBoxMaxNumber" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonRandomNumber" OnClick="GetRandomNumber_Click" Text="Get number" runat="server" />
            <br />
            <asp:Label ID="LabelRandomNumber" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
