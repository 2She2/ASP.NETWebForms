<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetail.aspx.cs" Inherits="_02_Employees.EmpDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DetailsView ID="DetailsViewEmployee" runat="server"
            AutoGenerateRows="true"></asp:DetailsView>
        <br />
        <asp:Button ID="ButtonBack" OnClick="ButtonBack_Click" runat="server" Text="Back"/>
    </div>
    </form>
</body>
</html>
