<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteViewState.aspx.cs" Inherits="_04.DeleteViewState.DeleteViewState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function deleteViewState() {
            var viewState = document.getElementById("__VIEWSTATE");
            viewState.parentNode.removeChild(viewState);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBoxText" runat="server"></asp:TextBox>
            <br />
            <br />
            <button id="button-delete-viewstate" onclick="deleteViewState()">Delete ViewState</button>
            <br />
            <br />
            <asp:Button ID="ButtonShowText" runat="server" OnClick="ButtonShowText_Click" Text="Show Text" />
            <br />
            <br />
            <asp:Label ID="LabelShowText" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
