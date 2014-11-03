<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="User_History" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Historikk</h1>
    <p>Matrett bestillinger</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Brukernavn" HeaderText="Brukernavn" 
                    SortExpression="Brukernavn" />
                <asp:BoundField DataField="Matrett" HeaderText="Matrett" 
                    SortExpression="Matrett" />
                <asp:BoundField DataField="Antall" HeaderText="Antall" 
                    SortExpression="Antall" />
                <asp:BoundField DataField="Tidspunkt" HeaderText="Tidspunkt" 
                    SortExpression="Tidspunkt" />
                <asp:BoundField DataField="Status" HeaderText="Status" 
                    SortExpression="Status" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="OrdersLabel" runat="server" ForeColor="Red" 
            Text="Ingen bestillinger."></asp:Label>
                </p>
    <p>
            <asp:Label ID="Middleman" runat="server" Visible="False"></asp:Label>
            </p>
    
      
        
        
<asp:SqlDataSource ID="SqlDataSource1" runat="server"
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        
        
        SelectCommand="SELECT aspnet_Users.UserName AS Brukernavn, Dishes.Dish AS Matrett, Orders.Antall, Orders.TimeID AS Tidspunkt, Orders.Status FROM aspnet_Users INNER JOIN Orders ON aspnet_Users.UserId = Orders.UserId INNER JOIN Dishes ON Orders.DishID = Dishes.DishID WHERE (Orders.UserId = @UserID) AND (Orders.Payed &lt;&gt; 'Ikke Betalt')" ConflictDetection="CompareAllValues" 
        OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:ControlParameter ControlID="Middleman" Name="UserId" Type="String" 
            PropertyName="Text" />
    </SelectParameters>
    
    </asp:SqlDataSource>
        
    <br />
        
</asp:Content>

