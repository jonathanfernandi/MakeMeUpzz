<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PSD_PROJECT.Views.Customer.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div>
        <div>
            <asp:Label ID="UsernameLbl" runat="server" Text="Username: "></asp:Label>
            <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
        </div>
         <div>
             <asp:Label ID="EmailLbl" runat="server" Text="Email: "></asp:Label>
             <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
         </div>
         <div>
             <asp:Label ID="GenderLbl" runat="server" Text="Gender: "></asp:Label>
             <div>
                 <asp:RadioButton id="MaleBtn" GroupName="Gender" runat="server" Text="Male"/>
                 <asp:RadioButton ID="FemaleBtn" GroupName="Gender" runat="server" Text="Female"/>
             </div>
         </div>
         <div>
             <asp:Label ID="DOBLbl" runat="server" Text="Date of Birth:"></asp:Label>
             <asp:Calendar ID="DOBCalendar" runat="server"></asp:Calendar>
         </div>
        <asp:Button ID="UpdateProfileBtn" runat="server" Text="Update Profile" OnClick="UpdateProfileBtn_Click" />
        <div style="color:red">
             <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
        </div>
           <br />

        <div>
            <asp:Label ID="ChangePasswordLbl" runat="server" Text="Change Password"></asp:Label>
            <div>
                <asp:Label ID="OldPasswordLbl" runat="server" Text="Old Password: "></asp:Label>
                <asp:TextBox ID="OldPasswordTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="NewPasswordLbl" runat="server" Text="New Password: "></asp:Label>
                <asp:TextBox ID="NewPasswordTxt" runat="server"></asp:TextBox>
            </div>
            <asp:RegularExpressionValidator ID="PasswordRegex" runat="server" ControlToValidate="NewPasswordTxt" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$" ErrorMessage="Password must be alphanumeric!"></asp:RegularExpressionValidator>
            <div>
                <asp:Button ID="ChangePasswordBtn" runat="server" Text="Change" OnClick="ChangePasswordBtn_Click" />
            </div>
            <div style="color:red">
                <asp:Label ID="errorPasswordLbl" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
