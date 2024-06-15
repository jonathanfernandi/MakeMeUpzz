<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PSD_PROJECT.Views.AdminHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div id="CustomerHome" runat="server">
        <div>
            <asp:Label ID="UsernameLabel" runat="server" Text="Username: "></asp:Label>
            <asp:Label ID="UsernameTxt" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="RoleLabel" runat="server" Text="Role: "></asp:Label>
            <asp:Label ID="RoleTxt" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div id="AdminHome" runat="server">
        <div>
              <asp:GridView ID="ListCustomerGridView" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
                  <Columns>
                      <asp:BoundField DataField="UserID" HeaderText="ID" SortExpression="UserID" />
                      <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                      <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                      <asp:BoundField DataField="UserDOB" HeaderText="Date of Birth" SortExpression="UserDOB" />
                      <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                      <asp:BoundField DataField="UserRole" HeaderText="Role" SortExpression="UserRole" />
                      <asp:BoundField DataField="UserPassword" HeaderText="Password" SortExpression="UserPassword" />
                  </Columns>
              </asp:GridView>
        </div>
    </div>

</asp:Content>
