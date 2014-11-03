<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ActiveOrder.aspx.cs" Inherits="User_ActiveOrder" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Aktive bestillinger</h1>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1">
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
            <asp:Label ID="NoActiveOrderLabel" runat="server" ForeColor="Red" 
                Text="Ingen aktive bestillinger." Visible="False"></asp:Label>
            <br />
            <asp:Label ID="ContactLabel" runat="server" 
                Text="(&Oslash;nsker du &aring; avbestille dine bestillinger m&aring; du kontakte oss via kontakt siden.)"></asp:Label>
            <br />
            <asp:Label ID="Middleman" runat="server" Visible="False"></asp:Label>
        <asp:ScriptManager ID="AJAX" runat="server" />
            
            <asp:Timer ID="UpdateTimer" runat="server" interval="10000" 
                OnTick="UpdateTimer_Tick" />
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConflictDetection="CompareAllValues" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                OldValuesParameterFormatString="original_{0}" 
                SelectCommand="SELECT aspnet_Users.UserName AS Brukernavn, Dishes.Dish AS Matrett, Orders.Antall, Orders.TimeID AS Tidspunkt, Orders.Status FROM aspnet_Users INNER JOIN Orders ON aspnet_Users.UserId = Orders.UserId INNER JOIN Dishes ON Orders.DishID = Dishes.DishID WHERE (Orders.UserId = @UserID) AND (Orders.Payed = 'Ikke Betalt')">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Middleman" Name="UserID" PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="UpdateTimer" eventname="Tick"/>
        </Triggers>
    </asp:UpdatePanel>
    
      
        
        
</asp:Content>

