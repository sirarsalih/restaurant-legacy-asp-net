<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingBasket.aspx.cs" Inherits="User_ShoppingBasket" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Handlevogn</h1>
    <p>
        <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
        <asp:CommandField ShowDeleteButton="true" DeleteText="Slett" ButtonType="Button"/>
        </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="ShoppingBasketLabel" runat="server" ForeColor="Red" 
            Text="Handlevognen din er tom."></asp:Label>
</p>
<p>
        <asp:Label ID="TotalSumLabelText" runat="server" Text="Total sum:"></asp:Label>
        <asp:Label ID="TotalSumLabel" runat="server" Text="Price"></asp:Label>
    </p>
    <p>
        <asp:Button ID="OrderButton" runat="server" Text="Bestill n&aring;!" 
            onclick="OrderNow_Click" />
    </p>
    
</asp:Content>

