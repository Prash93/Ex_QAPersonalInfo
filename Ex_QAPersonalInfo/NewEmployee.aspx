<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewEmployee.aspx.cs" Inherits="Ex_QAPersonalInfo.NewEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelNewName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="TextBoxNewName" runat="server" style="margin-left: 67px" Width="215px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="LabelNewAddress" runat="server" Text="Address: "></asp:Label>
        <asp:TextBox ID="TextBoxNewAddress" runat="server" style="margin-left: 50px" Width="241px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonAddEmployee" runat="server" OnClick="ButtonAddEmployee_Click" Text="Add New Employee" />
    
    </div>
    </form>
</body>
</html>
