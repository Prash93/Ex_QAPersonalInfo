<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ex_QAPersonalInfo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelUser" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="TextBoxUsername" runat="server" style="margin-left: 54px" Width="167px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LabelPassword" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" style="margin-left: 54px" Width="170px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" style="margin-left: 63px" Text="Login" Width="71px" />
    
    </div>
    </form>
</body>
</html>
