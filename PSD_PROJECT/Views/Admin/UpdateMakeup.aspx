<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateMakeup.aspx.cs" Inherits="PSD_PROJECT.Views.Admin.UpdateMakeup" %>

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
            <asp:Label ID="MakeupName" runat="server" Text="Makeup Name: "></asp:Label>
            <asp:TextBox ID="MakeupNameTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupPrice" runat="server" Text="Makeup Price: "></asp:Label>
            <asp:TextBox ID="MakeupPriceTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupWeight" runat="server" Text="Makeup Weight: "></asp:Label>
            <asp:TextBox ID="MakeupWeightTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupTypeID" runat="server" Text="Makeup Type ID: "></asp:Label>
            <asp:TextBox ID="MakeupTypeIDTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupBrandID" runat="server" Text="Makeup Brand ID: "></asp:Label>
            <asp:TextBox ID="MakeupBrandIDTxt" runat="server"></asp:TextBox>
        </div>
        <div style="color:red">
            <asp:Label ID="error" runat="server" Text=""></asp:Label>
        </div>
        <asp:Button ID="UpdateMakeupBtn" runat="server" Text="Update" OnClick="UpdateMakeupBtn_Click" />
    </form>
</body>
</html>
