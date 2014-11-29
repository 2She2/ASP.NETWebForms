<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpRepeater.aspx.cs" Inherits="_04_EmployeesRepeater.EmpRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="RepeaterEmployees" runat="server">
                <HeaderTemplate>
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
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#: Eval("EmployeeID") %></td>
                        <td><%#: Eval("FirstName") %></td>
                        <td><%#: Eval("LastName") %></td>
                        <td><%#: Eval("Title") %></td>
                        <td><%#: Eval("Country") %></td>
                        <td><%#: Eval("City") %></td>
                        <td><%#: Eval("Address") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
