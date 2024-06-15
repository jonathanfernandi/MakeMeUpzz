<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertMakeupBrand.aspx.cs" Inherits="PSD_PROJECT.Views.Admin.InsertMakeupBrand" %>

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
            <asp:Label ID="MakeupBrandNameLbl" runat="server" Text="Makeup Brand Name: "></asp:Label>
            <asp:TextBox ID="MakeupBrandNameTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupBrandRatingLbl" runat="server" Text="Makeup Brand Rating: "></asp:Label>
            <asp:TextBox ID="MakeupBrandRatingTxt" runat="server"></asp:TextBox>
        </div>

        <div style="color:red">
            <asp:Label ID="error" runat="server" Text=""></asp:Label>
        </div>
        <asp:Button ID="InsertMakeupBrandBtn" runat="server" Text="Insert" OnClick="InsertMakeupBrandBtn_Click" />
    </form>
</body>
</html>
