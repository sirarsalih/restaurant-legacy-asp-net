<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="NewDish.aspx.cs" Inherits="Administrator_NewDish" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Legg til ny matrett</h1>
    <p>Ny matrett</p>
    <p>
        <asp:TextBox ID="DishTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="DishTextBox" 
            ErrorMessage="Du m&aring; oppgi navn p&aring; matretten."></asp:RequiredFieldValidator>
    </p>
    <p>Velg matrett meny</p>
    <p>
        <asp:ListBox ID="DishMenuListBox" runat="server" DataSourceID="DishMenus" 
            DataTextField="DishMenu" DataValueField="DishMenuID">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
        </asp:ListBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="DishMenuListBox" 
            ErrorMessage="Du m&aring; velge en matrett meny."></asp:RequiredFieldValidator>
                </p>
    <p>Matrett informasjon</p>
    <p>
        <asp:TextBox ID="DishMenuInformationTextBox" runat="server" Height="106px" 
            Width="180px" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="DishMenuInformationTextBox" 
            ErrorMessage="Du m&aring; fylle inn informasjon om matretten."></asp:RequiredFieldValidator>
    </p>
    <p>Matrett pris</p>
    <p><asp:TextBox ID="DishPriceTextBox" runat="server" Width="31px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="kr"></asp:Label>
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
            ControlToValidate="DishPriceTextBox" ErrorMessage="*" MaximumValue="10000" 
            MinimumValue="5" Type="Integer"></asp:RangeValidator>
        </p>
    <p>
        <asp:Button ID="AddDish" runat="server" Text="Legg til matrett" 
            onclick="AddDish_Click" />
    </p>
        
        <asp:SqlDataSource ID="DishMenus" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT [DishMenu], [DishMenuID] FROM [DishMenus]">
            </asp:SqlDataSource>
        
    </asp:Content>

