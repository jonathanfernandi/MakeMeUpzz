<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="PSD_PROJECT.Views.TransactionDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
        <br />
        <br />
        <div>
            <asp:Label ID="TransactionIDLbl" runat="server" Text="Transaction ID: "></asp:Label>
            <asp:Label ID="TransactionIDTxt" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="TransactionDateLbl" runat="server" Text="Transaction Date: "></asp:Label>
            <asp:Label ID="TransactionDateTxt" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="StatusLbl" runat="server" Text="Status: "></asp:Label>
            <asp:Label ID="StatusTxt" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="UsernameLbl" runat="server" Text="Username: "></asp:Label>
            <asp:Label ID="UsernameTxt" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="EmailLbl" runat="server" Text="Email: "></asp:Label>
            <asp:Label ID="EmailTxt" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="MakeupNameLbl" runat="server" Text="Makeup Name: "></asp:Label>
            <asp:Label ID="MakeupNameTxt" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="MakeupPriceLbl" runat="server" Text="Makeup Price: "></asp:Label>
            <asp:Label ID="MakeupPriceTxt" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="MakeupWeightLbl" runat="server" Text="Makeup Weight: "></asp:Label>
            <asp:Label ID="MakeupWeightTxt" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="MakeupTypeNameLbl" runat="server" Text="Makeup Type Name: "></asp:Label>
            <asp:Label ID="MakeupTypeNameTxt" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="MakeupBrandNameLbl" runat="server" Text="Makeup Brand Name: "></asp:Label>
            <asp:Label ID="MakeupBrandNameTxt" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="MakeupBrandRatingLbl" runat="server" Text="Makeup Brand Rating: "></asp:Label>
            <asp:Label ID="MakeupBrandRatingTxt" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="QuantityLbl" runat="server" Text="Quantity: "></asp:Label>
            <asp:Label ID="QuantityTxt" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
