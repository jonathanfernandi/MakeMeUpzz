<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertMakeupType.aspx.cs" Inherits="PSD_PROJECT.Views.Admin.InsertMakeupType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
             <asp:Button ID="InsertMakeupTypeBtn" runat="server" Text="Insert" OnClick="InsertMakeupTypeBtn_Click" />
        </div>
    </form>
</body>
</html>
