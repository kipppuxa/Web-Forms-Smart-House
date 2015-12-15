<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouse.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Smart House</title>
    <link href="CSS/bootstrap.css"" rel="stylesheet" />
    <link href="CSS/style.css" rel="stylesheet" />
</head>

<body>
    <div class="logo"></div>
    <form id="form1" runat="server">
        <div class="btn-group-vertical">
            <asp:Button class="btn btn-primary btn-lg" ID="addLampButton" runat="server" OnClick="addLampButton_Click" Text="Add Lamp" />
            <asp:Button class="btn btn-primary btn-lg" ID="addHeaterButton" runat="server" Text="Add Heater" OnClick="addHeaterButton_Click" />
            <asp:Button class="btn btn-primary btn-lg" ID="addTVButton" runat="server" Text="Add TV" OnClick="addTVButton_Click" />
            <asp:Button class="btn btn-primary btn-lg" ID="addWiFiButton" runat="server" Text="Add Wi-Fi" OnClick="addWiFiButton_Click" />
        </div>
        <div class="wrapper">
            <asp:Panel ID="ItemPlace" runat="server" EnableViewState="false"></asp:Panel>
        </div>
    </form>
</body>
</html>
