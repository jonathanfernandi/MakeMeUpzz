<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="PSD_PROJECT.Views.Admin.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="TransactionHandleTxt" runat="server" Text="Transaction Handle"></asp:Label>
    <div>
        <asp:GridView ID="TransactionHandleGridView" AutoGenerateColumns="False" runat="server" OnRowEditing="HandleTransactionRow" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:CommandField ButtonType="Button" EditText="Handle" HeaderText="Handle" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <asp:Label ID="TransactionHandledTxt" runat="server" Text="Transaction Handled"></asp:Label>
    <div>
        <asp:GridView ID="AllTransactionGridView" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanging="DetailTransactionRow" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                <asp:CommandField ButtonType="Button" HeaderText="Detail" SelectText="Detail" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
