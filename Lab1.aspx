<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab1.aspx.cs" Inherits="Lab1.Lab1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Žodžių paieška</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Vykdyti" CssClass="wrapper__button" />
            <br />
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <asp:Table ID="Table1" runat="server" GridLines="Both">
             </asp:Table>
             <br />
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <asp:Label ID="Label7" runat="server"></asp:Label>
            <asp:Label ID="Label8" runat="server"></asp:Label>
            <asp:Label ID="Label9" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
