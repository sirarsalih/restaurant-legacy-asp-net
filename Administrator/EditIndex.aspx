<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="EditIndex.aspx.cs" Inherits="Administrator_EditIndex" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Rediger forsiden</h1>
    <p>[Skriv nytt innhold i feltet under]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
    <p>
        <asp:TextBox ID="IndexTextBox" runat="server" Height="211px" Width="442px" 
            TextMode="MultiLine" Wrap="True"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Submit" runat="server" onclick="Submit_Click" 
            Text="Bekreft" />
        <asp:Label ID="IndexTextLabel" runat="server" ForeColor="Red" 
            Text="Tekst feltet er tomt." Visible="False"></asp:Label>
        </p>
</asp:Content>

