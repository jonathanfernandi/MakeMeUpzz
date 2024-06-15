<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PSD_PROJECT.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="REGISTER PAGE"></asp:Label>
            <div>
                <asp:Label ID="UsernameLabel" runat="server" Text="Username: "></asp:Label>
                <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="EmailLabel" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="GenderLabel" runat="server" Text="Gender:"></asp:Label>
                <div>
                    <asp:RadioButton id="MaleBtn" GroupName="Gender" runat="server" Text="Male" />
                    <asp:RadioButton id="FemaleBtn" GroupName="Gender" runat="server" Text="Female" />
                </div>
            </div>
            <div>
                <asp:Label ID="PasswordLabel" runat="server" Text="Password: "></asp:Label>
                <asp:TextBox ID="PasswordTxt" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="PasswordRegex" runat="server" ControlToValidate="PasswordTxt" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$" ErrorMessage="Password must be alphanumeric!"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="ConfirmationPasswordLabel" runat="server" Text="Confirmation Password: "></asp:Label>
                <asp:TextBox ID="ConfirmationPasswordTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="DOBLabel" runat="server" Text="Date of Birth: "></asp:Label>
                <asp:Calendar ID="DOBcalendar" runat="server"></asp:Calendar>
            </div>
            <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />
            <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
