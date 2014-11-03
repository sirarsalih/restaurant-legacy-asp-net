<%@ Page Language="C#" MasterPageFile="../MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Meny" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Meny</h1>   
       

    <asp:Panel ID="MenuPanel" runat="server">
    </asp:Panel>    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>"></asp:SqlDataSource>
    </asp:Content>

