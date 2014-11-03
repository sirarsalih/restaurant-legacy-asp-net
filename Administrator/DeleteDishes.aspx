<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="DeleteDishes.aspx.cs" Inherits="Administrator_DeleteDishes" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Slett matretter</h1>
    <p>
        <asp:ListBox ID="DishesListBox" runat="server" DataSourceID="SqlDataSource1" 
            DataTextField="Dish" DataValueField="DishID"></asp:ListBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="DishesListBox" ErrorMessage="Du m&aring; velge matrett."></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="DeleteDish" runat="server" onclick="DeleteDish_Click" 
            Text="Slett matrett" />
        <asp:Label ID="Warning" runat="server" ForeColor="Red" 
            Text="(NB! Alt innhold i matretten vil bli slettet.)"></asp:Label>
    </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [DishID], [Dish] FROM [Dishes]"></asp:SqlDataSource>
    </p>
</asp:Content>

