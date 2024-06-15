<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateMakeupType.aspx.cs" Inherits="PSD_PROJECT.Views.Admin.UpdateMakeupType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BackManageMakeup" runat="server" Text="Back" OnClick="BackManageMakeup_Click" />
        </div>
        <br />
        <div>
            <asp:Label ID="MakeupTypeName" runat="server" Text="Makeup Type Name: "></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="MakeupTypeNameTxt" runat="server"></asp:TextBox>
        </div>
        <div style="color:red">
            <asp:Label ID="error" runat="server" Text=""></asp:Label>
        </div>
        <asp:Button ID="UpdateMakeupTypeBtn" runat="server" Text="Update" OnClick="UpdateMakeupTypeBtn_Click" />
    </form>
</body>
</html>
