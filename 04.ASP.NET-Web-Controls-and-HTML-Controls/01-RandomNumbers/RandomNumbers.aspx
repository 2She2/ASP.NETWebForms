<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumbers.aspx.cs" Inherits="_01_RandomNumbers.RandomNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formRandomNumbers" runat="server">
    <div>
        <label for="TextMinNumber">Min number</label>
        <input id="TextMinNumber" runat="server" />
        <br />
        <label for="TextMaxNumber">Max number</label>
        <input id="TextMaxNumber" runat="server" />
        <br />
        <input type="button" id="getRandomNumber" onserverclick="GetRandomNumber_Click" value="Get number" runat="server"/>
        <br />
        <label id="LabelRandomNumber" runat="server"></label>
    </div>
    </form>
</body>
</html>
