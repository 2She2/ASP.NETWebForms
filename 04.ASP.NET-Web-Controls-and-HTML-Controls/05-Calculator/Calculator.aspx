<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="_05_Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <link href="styles/style.css" rel="stylesheet" />
</head>
<body>
    <form id="formCalculator" runat="server">
        <div id="calculatorContaianer">
            <asp:TextBox ID="TextBoxDisplay" runat="server"></asp:TextBox>
            <div id="buttons-container">
            <asp:Button ID="Button1" OnClick="SubmitDigit_Click" runat="server" Text="1" class="button" />
            <asp:Button ID="Button2" OnClick="SubmitDigit_Click" runat="server" Text="2" class="button" />
            <asp:Button ID="Button3" OnClick="SubmitDigit_Click" runat="server" Text="3" class="button" />
            <asp:Button ID="ButtonPlus" OnClick="SubmitOperator_Click" runat="server" Text="+" class="button" />
            <br />
            <asp:Button ID="Button4" OnClick="SubmitDigit_Click" runat="server" Text="4" class="button" />
            <asp:Button ID="Button5" OnClick="SubmitDigit_Click" runat="server" Text="5" class="button" />
            <asp:Button ID="Button6" OnClick="SubmitDigit_Click" runat="server" Text="6" class="button" />
            <asp:Button ID="ButtonMinus" OnClick="SubmitOperator_Click" runat="server" Text="-" class="button" />
            <br />
            <asp:Button ID="Button7" OnClick="SubmitDigit_Click" runat="server" Text="7" class="button" />
            <asp:Button ID="Button8" OnClick="SubmitDigit_Click" runat="server" Text="8" class="button" />
            <asp:Button ID="Button9" OnClick="SubmitDigit_Click" runat="server" Text="9" class="button" />
            <asp:Button ID="ButtonMiltiply" OnClick="SubmitOperator_Click" runat="server" Text="x" class="button" />
            <br />
            <asp:Button ID="ButtonClear" OnClick="SubmitClear_Click" runat="server" Text="Clear" class="button" />
            <asp:Button ID="Button0" OnClick="SubmitDigit_Click" runat="server" Text="0" class="button" />
            <asp:Button ID="ButtonDivision" OnClick="SubmitOperator_Click" runat="server" Text="/" class="button" />
            <asp:Button ID="ButtonSqrt" OnClick="SubmitOperator_Click" runat="server" Text="&radic;" class="button" />
            </div>
                <div id="resolve-container">
                <asp:Button ID="ButtonResolve" OnClick="Resolve_Click" runat="server" Text="=" class="button resolve" />
            </div>
        </div>
    </form>
</body>
</html>
