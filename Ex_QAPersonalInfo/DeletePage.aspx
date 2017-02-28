<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="Ex_QAPersonalInfo.DeletePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelName" runat="server" Text="Name:"></asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server" style="margin-left: 57px" Width="318px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LabelAddress" runat="server" Text="Address:"></asp:Label>
        <asp:TextBox ID="TextBoxAddress" runat="server" style="margin-left: 42px" Width="322px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="LabelDeleteQuest" runat="server" Text="Are you sure you want to delete?"></asp:Label>
        <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" style="margin-left: 38px" Text="Delete" />
    
        <asp:Button ID="ButtonNoDel" runat="server" OnClick="ButtonNoDel_Click" style="margin-left: 49px" Text="No" Width="55px" />
    
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" Width="98px" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
