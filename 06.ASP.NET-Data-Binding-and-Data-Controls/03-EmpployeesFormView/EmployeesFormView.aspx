<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesFormView.aspx.cs" Inherits="_03_EmpployeesFormView.EmployeesFormView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false"
                OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged" DataKeyNames="Id"
                AllowPaging="true" PageSize="10" OnPageIndexChanging="GridViewEmployees_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="FullName" HeaderText="Name" />
                    <asp:CommandField ShowSelectButton="true" />
                </Columns>
            </asp:GridView>

            <asp:FormView ID="FormViewEmployees" runat="server" AllowPaging="true">
                <ItemTemplate>
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
                        <tr>
                            <td><%#: Eval("EmployeeID") %></td>
                            <td><%#: Eval("FirstName") %></td>
                            <td><%#: Eval("LastName") %></td>
                            <td><%#: Eval("Title") %></td>
                            <td><%#: Eval("Country") %></td>
                            <td><%#: Eval("City") %></td>
                            <td><%#: Eval("Address") %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:FormView>

            <asp:Button ID="ButtonBack" OnClick="ButtonBack_Click" runat="server" Text="Back" />
        </div>
    </form>
</body>
</html>
