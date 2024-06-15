<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/NavBar.Master" AutoEventWireup="true" CodeBehind="OrderMakeup.aspx.cs" Inherits="PSD_PROJECT.Views.Customer.OrderMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:Label ID="MakeupProductLBL" runat="server" Text="MAKEUP PRODUCTS: "></asp:Label>
    <div>
        <asp:GridView ID="MakeupGridView" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanging="OrderMakeupRow" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Makeup Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Makeup Weight in Grams" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Makeup Type Name" SortExpression="MakeupType.MakeupTypeName" />
                

                <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Makeup Brand Name" SortExpression="MakeupBrand.MakeupBrandName" />
            
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="MakeupQuantityOrder" runat="server"></asp:TextBox>
                        <div id="QuantityValidatiorVisible">
                            <asp:RangeValidator ID="QuantityValidator" runat="server" ErrorMessage="Must be Bigger than 0" ControlToValidate="MakeupQuantityOrder" MinimumValue="1" MaximumValue="100" Type="Integer" Visible="True"></asp:RangeValidator>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
             
                <asp:CommandField ButtonType="Button" HeaderText="Order" ShowHeader="True" ShowSelectButton="True" SelectText="ORDER" />
                
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <asp:Label ID="CartLBL" runat="server" Text="CART: "></asp:Label>
    <div>
        <asp:GridView ID="CartGridView" AutoGenerateColumns="False" runat="server" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Makeup Name" SortExpression="Makeup.MakeupName" />
                <asp:BoundField DataField="Makeup.MakeupPrice" HeaderText="Makeup Price" SortExpression="Makeup.MakeupPrice" />
                <asp:BoundField DataField="Makeup.MakeupWeight" HeaderText="Makeup Weight" SortExpression="Makeup.MakeupWeight" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Makeup.MakeupType.MakeupTypeName" HeaderText="Makeup Type Name" SortExpression="Makeup.MakeupType.MakeupTypeName" />
                <asp:BoundField DataField="Makeup.MakeupBrand.MakeupBrandName" HeaderText="Makeup Brand Name" SortExpression="Makeup.MakeupBrand.MakeupBrandName" />
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" OnClick="ClearCartBtn_Click" />
    <asp:Button ID="CheckOutBtn" runat="server" Text="Check Out" OnClick="CheckOutBtn_Click" />
    <br />
 

</asp:Content>
