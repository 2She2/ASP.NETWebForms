<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="_05_Employees_ListView.ListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListViewEmployees" runat="server"
                ItemType="Northwind.Employee">
                <LayoutTemplate>
                    <h3>Employees</h3>
                    <table border="1">
                        <tr>
                            <th>ID</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Title</th>
                            <th>Country</th>
                            <th>City</th>
                            <th>Address</th>
                        </tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%#: Item.EmployeeID %></td>
                        <td><%#: Item.FirstName %></td>
                        <td><%#: Item.LastName %></td>
                        <td><%#: Item.Title %></td>
                        <td><%#: Item.Country %></td>
                        <td><%#: Item.City %></td>
                        <td><%#: Item.Address %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
