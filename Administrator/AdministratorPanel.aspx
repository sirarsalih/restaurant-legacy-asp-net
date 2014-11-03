<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AdministratorPanel.aspx.cs" Inherits="Administrator_AdministratorPanel" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Administrator Panel</h1>
    
    <p><a href="EditIndex.aspx">Rediger forsiden</a></p>
    <p><a href="Users.aspx">Brukere</a></p>
    <p>
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1">
        </asp:TreeView>
    </p>
    <p>
        <a href="../SuperModerator/ActiveWatch.aspx">Active Watch</a></p>
    <p>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </p>
    </asp:Content>

