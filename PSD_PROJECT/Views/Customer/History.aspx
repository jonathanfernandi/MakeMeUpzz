<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="PSD_PROJECT.Views.Customer.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div>
        <asp:GridView ID="CustomerTransactionGridView" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanging="DetailCustomerTransactionRow" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
               
                <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Makeup Name" SortExpression="Makeup.MakeupName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="TransactionHeader.Status" HeaderText="Status" SortExpression="TransactionHeader.Status" />
                <asp:CommandField ButtonType="Button" HeaderText="Detail" SelectText="Detail" ShowHeader="True" ShowSelectButton="True" />
               
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
