<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="Ex_QAPersonalInfo.EditPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            width: 361px;
            margin-left: 226px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelName" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="TextBoxName" runat="server" Width="418px"></asp:TextBox>
        <br />
        <asp:Label ID="LabelAddress" runat="server" Text="Address: "></asp:Label>
        <asp:TextBox ID="TextBoxAddress" runat="server" Width="428px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" Width="134px" />
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBoxNewQuali" runat="server" Width="245px"></asp:TextBox>
        <asp:Button ID="ButtonAddQuali" runat="server" OnClick="ButtonAddQuali_Click" style="margin-left: 28px" Text="Add Qualification" Width="146px" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBoxNewEmail" runat="server" Width="239px"></asp:TextBox>
        <asp:Button ID="ButtonAddEmail" runat="server" OnClick="ButtonAddEmail_Click" style="margin-left: 35px" Text="Add Email" Width="141px" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" Width="130px" />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
