<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobileBg.aspx.cs" Inherits="_01_MobileBg.MobileBg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formMain" runat="server">
    <div>
        <asp:Label ID="LabelProducer" AssociatedControlID="DropDownListProducers" Text="Producer" runat="server"></asp:Label>
        <asp:DropDownList ID="DropDownListProducers" AutoPostBack="true"
            DataTextField="Name" DataValueField="Name"
            OnSelectedIndexChanged="DropDownListProducers_SelectedIndexChanged"
             runat="server"></asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelModel" AssociatedControlID="DropDownListModels" Text="Model" runat="server"></asp:Label>
        <asp:DropDownList ID="DropDownListModels" AutoPostBack="true"
            OnSelectedIndexChanged="DropDownListModels_SelectedIndexChanged"
            runat="server"></asp:DropDownList>
        <br />
        <asp:CheckBoxList ID="CheckBoxListExtras" runat="server"
            ItemType="_01_MobileBg.Extra"
            DataSource="<%# this.extras %>"
            DataTextField="Name">
        </asp:CheckBoxList>
        <br />
        <asp:RadioButtonList ID="RadioButtonListEngines" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
        <asp:Button ID="ButtonSubmit" runat="server" OnClick="ButtonSubmit_Click" Text="Submit"/>
        <br />
        <br />
        <asp:Literal ID="LiteralSubmitedInfo" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
