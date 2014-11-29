<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02_Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                AllowPaging="true" OnPageIndexChanging="GridViewEmployees_PageIndexChanging">
                <Columns>
                    <asp:HyperLinkField DataTextField="FullName" HeaderText="Name"
                        DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EmpDetail.aspx?id={0}" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
