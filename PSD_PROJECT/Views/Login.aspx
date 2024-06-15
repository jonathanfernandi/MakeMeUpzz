<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PSD_PROJECT.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Login Page"></asp:Label>
            <div>
                <asp:Label ID="UsernameLabel" runat="server" Text="Username: "></asp:Label>
                <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="PasswordLabel" runat="server" Text="Password: "></asp:Label>
                <asp:TextBox ID="PasswordTxt" runat="server" TextMode="Password" ></asp:TextBox>
            </div>
            <div style="color:red">
                <asp:Label ID="error" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:CheckBox ID="RememberMeCheckBox" runat="server" Text="Remember Me" />
            </div>
            <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
            <div>
                <asp:HyperLink ID="RegisterPageBtn" runat="server" NavigateUrl="~/Views/Register.aspx">Dont have an Account?</asp:HyperLink>
            </div>

        </div>
    </form>
</body>
</html>
