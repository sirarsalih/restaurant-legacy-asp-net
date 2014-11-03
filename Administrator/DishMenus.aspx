<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="DishMenus.aspx.cs" Inherits="Administrator_Dishes" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Legg til/slett matrett menyer</h1>
    <p>Matrett Menyer</p>
    <p>
        <asp:ListBox ID="DishMenuListBox" runat="server" DataSourceID="DishMenus" 
            DataTextField="DishMenu" DataValueField="DishMenuID">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
        </asp:ListBox>
    </p>
    <p>
        
        <asp:Button ID="DeleteDishMenu" runat="server" Text="Slett matrett meny" 
            Width="123px" onclick="DeleteDishMenu_Click" />
        
        <asp:Label ID="Warning" runat="server" ForeColor="Red" 
            Text="(NB! Alt innhold i matrett menyen vil bli slettet.)"></asp:Label>
        
    </p>
                <p>
        
        <asp:TextBox ID="DishMenuTextBox" runat="server" Width="88px"></asp:TextBox>
        <asp:Button ID="AddDishMenu" runat="server" Text="Legg til ny matrett meny" 
            Width="153px" onclick="AddDishMenu_Click" />
        
    </p>
    <p>
        
        &nbsp;</p>
    <p>
        
        &nbsp;</p>
    <p>
        
        <asp:SqlDataSource ID="DishMenus" runat="server" 
            ConnectionString="<%$ ConnectionStrings:InsertExtraInfo %>" 
            SelectCommand="SELECT [DishMenu], [DishMenuID] FROM [DishMenus]"></asp:SqlDataSource>
        
    </p>



</asp:Content>

