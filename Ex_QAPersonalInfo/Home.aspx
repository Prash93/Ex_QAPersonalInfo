<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Ex_QAPersonalInfo.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%
        
         %>
        <asp:Button ID="ButtonAddPerson" runat="server" Text="New Entry Server" OnClick="ButtonAddPerson_Click" Width="143px" />
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" style="margin-left: 835px" Text="Logout" Width="94px" />
    </div>
    </form>
</body>
</html>
