<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="ManageMakeup.aspx.cs" Inherits="PSD_PROJECT.Views.ManageMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div>
        <asp:Button ID="InsertMakeup" runat="server" Text="Insert Makeup" OnClick="InsertMakeup_Click" />
        <asp:Button ID="InsertMakeupType" runat="server" Text="Insert Makeup Type" OnClick="InsertMakeupType_Click" />
        <asp:Button ID="InsertMakeupbrand" runat="server" Text="Insert Makeup Brand" OnClick="InsertMakeupbrand_Click" />
    </div>
    <br />
    <div>
        <asp:GridView ID="MakeupGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="UpdateMakeupRow" OnRowDeleting="DeleteMakeupRow" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID" />
                <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupTypeID" HeaderText="Makeup Type ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupBrandID" HeaderText="Makeup Brand ID" SortExpression="MakeupBrandID" />
                
                
                <asp:CommandField ButtonType="Button" EditText="Update" HeaderText="Update" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
                <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div>
        <asp:GridView ID="MakeupTypeGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="UpdateMakeupTypeRow" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="MakeupTypeID" HeaderText="ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Makeup Type Name" SortExpression="MakeupTypeName" />
                <asp:CommandField ButtonType="Button" EditText="Update" HeaderText="Update" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div>
        <asp:GridView ID="MakeupBrandGridView" runat="server" AutoGenerateColumns="False" OnRowEditing="UpdateMakeupBrandRow" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="MakeupBrandID" HeaderText="ID" SortExpression="MakeupBrandID" />
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Makeup Brand Name" SortExpression="MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrandRating" HeaderText="Makeup Brand Rating" SortExpression="MakeupBrandRating" />
                <asp:CommandField ButtonType="Button" EditText="Update" HeaderText="Update" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
