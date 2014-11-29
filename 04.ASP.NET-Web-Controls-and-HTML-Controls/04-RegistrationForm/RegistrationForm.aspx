<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="_04_RegistrationForm.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelFirstName" runat="server">First name</asp:Label>
            <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelLastName" runat="server">Last name</asp:Label>
            <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelFacultyNumber" runat="server">Faculty number</asp:Label>
            <asp:TextBox ID="TextBoxFacultyNumber" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelUniversity" runat="server">Choose university:</asp:Label>
            <asp:DropDownList ID="DropDownListUniversity" AutoPostBack="true"
                OnSelectedIndexChanged="DropDownListUniversity_SelectedIndexChanged" runat="server">
                <asp:ListItem Value=""></asp:ListItem>
                <asp:ListItem Value="Sofiiski">Sofiiski</asp:ListItem>
                <asp:ListItem Value="Tehnicheski">Tehnicheski</asp:ListItem>
                <asp:ListItem Value="UNSS">UNSS</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelSpecialty" runat="server">Choose specialty</asp:Label>
            <asp:DropDownList ID="DropDownListSpecialty" AutoPostBack="true"
                OnSelectedIndexChanged="DropDownListSpecialty_SelectedIndexChanged" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="LabelCourses" runat="server">Choose courses</asp:Label>
            <asp:ListBox ID="ListBoxCourses" runat="server" SelectionMode="Multiple">
            </asp:ListBox>
            <br />
            <asp:Button ID="ButtonSubmit" Text="Submit" OnClick="DisplayUserInfo_Click" runat="server" />
            <br />
            <br />
            <asp:Panel ID="PanelUserInfo" runat="server"></asp:Panel>
        </div>
    </form>
</body>
</html>
