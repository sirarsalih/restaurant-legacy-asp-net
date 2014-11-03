<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ActiveWatch.aspx.cs" Inherits="SuperModerator_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Active Watch</h1>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <p>Innkommende matrett bestillinger</p>        
	<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="UserId,DishID,TimeID" DataSourceID="SqlDataSource1">
                <Columns>
                    
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" DeleteText="Slett" EditText="Rediger" UpdateText="Oppdater" />
                    
                    <asp:BoundField DataField="Brukernavn" HeaderText="Brukernavn" ReadOnly="True"
                        SortExpression="Brukernavn" />
                    <asp:BoundField DataField="Matrett" HeaderText="Matrett" ReadOnly="True"
                        SortExpression="Matrett" />
                    <asp:BoundField DataField="Antall" HeaderText="Antall" ReadOnly="True"
                        SortExpression="Antall" />
                    <asp:BoundField DataField="TimeID" HeaderText="Tidspunkt" ReadOnly="True"
                        SortExpression="Tidspunkt" />
                    <asp:BoundField DataField="Status" HeaderText="Status" 
                        SortExpression="Status" />
                    <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" 
                        SortExpression="UserId" Visible="False"/>
                    <asp:BoundField DataField="DishID" HeaderText="DishID" ReadOnly="True" 
                        SortExpression="DishID" Visible="False"/>
                    <asp:BoundField DataField="TimeID" HeaderText="TimeID" ReadOnly="True" 
                        SortExpression="TimeID" Visible="False"/>
                    <asp:BoundField DataField="Payed" HeaderText="Betalt"
                        SortExpression="TimeID"/>
                        
                </Columns>
            </asp:GridView>
            <asp:Label ID="NotConfirmedLabel" runat="server" ForeColor="Red" 
                Text="Noen av status feltene er ikke bekreftet (vent p&aring; refresh)."></asp:Label>
            <br />
            <asp:Label ID="NoIncomingOrdersLabel" runat="server" ForeColor="Red" 
                Text="Ingen bestillinger."></asp:Label>
            <br />
            <br />
            <p>Innkommende bord reserveringer</p>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="UserId,TableID,TimeFromID,TimeToID" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Slett" ButtonType="Button" />
                    <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" 
                        SortExpression="UserId" Visible="False"/>
                    <asp:BoundField DataField="UserName" HeaderText="Brukernavn" 
                        SortExpression="UserName" />
                    <asp:BoundField DataField="TableID" HeaderText="Bordnummer" ReadOnly="True" 
                        SortExpression="TableID" />
                    <asp:BoundField DataField="Seats" HeaderText="Seter" SortExpression="Seats" />
                    <asp:BoundField DataField="TimeFromID" HeaderText="Fra" ReadOnly="True" 
                        SortExpression="TimeFromID" />
                    <asp:BoundField DataField="TimeToID" HeaderText="Til" ReadOnly="True" 
                        SortExpression="TimeToID" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="NoIncomingReservationsLabel" runat="server" ForeColor="Red" 
                Text="Ingen reserveringer."></asp:Label>
            <br />
            <asp:ScriptManager ID="AJAX" runat="server" />
            
            <asp:Timer ID="UpdateTimer" runat="server" interval="10000" 
                OnTick="UpdateTimer_Tick" />
            
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="UpdateTimer" eventname="Tick"/>
        </Triggers>
    </asp:UpdatePanel>        
        
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        
        
        SelectCommand="SELECT aspnet_Users.UserName AS Brukernavn, Dishes.Dish AS Matrett, Orders.Antall, Orders.TimeID, Orders.Status, Orders.UserId, Orders.DishID, Orders.Payed FROM aspnet_Users INNER JOIN Orders ON aspnet_Users.UserId = Orders.UserId INNER JOIN Dishes ON Orders.DishID = Dishes.DishID WHERE (Orders.Payed = 'Ikke Betalt')" ConflictDetection="CompareAllValues" 
        DeleteCommand="DELETE FROM Orders WHERE (UserId = @original_UserId) AND (TimeID = @original_TimeID) AND (DishID = @original_DishID) AND (Antall = @original_Antall) AND (Status = @original_Status)" 
        OldValuesParameterFormatString="original_{0}" 
        
        UpdateCommand="UPDATE Orders SET Status = @Status, Payed = @Payed WHERE (UserId = @original_UserId) AND (TimeID = @original_TimeID) AND (DishID = @original_DishID)">
    
    <DeleteParameters>
        <asp:Parameter Name="original_UserId" />
        <asp:Parameter Name="original_TimeID" />
        <asp:Parameter Name="original_DishID" />
        <asp:Parameter Name="original_Antall" />
        <asp:Parameter Name="original_Status" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="Status" />
        <asp:Parameter Name="Payed" />
        <asp:Parameter Name="original_UserId" />
        <asp:Parameter Name="original_TimeID" />
        <asp:Parameter Name="original_DishID" />
    </UpdateParameters>    
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        DeleteCommand="DELETE FROM [Reservation] WHERE [UserId] = @UserId AND [TableID] = @TableID AND [TimeFromID] = @TimeFromID AND [TimeToID] = @TimeToID" 
        InsertCommand="INSERT INTO [Reservation] ([UserId], [TableID], [TimeFromID], [TimeToID]) VALUES (@UserId, @TableID, @TimeFromID, @TimeToID)" 
        SelectCommand="SELECT Reservation.UserId, aspnet_Users.UserName, Reservation.TableID, Restaurant_Tables.Seats, Reservation.TimeFromID, Reservation.TimeToID 
FROM aspnet_Users, Reservation, Restaurant_Tables
WHERE aspnet_Users.UserId = Reservation.UserId
AND Reservation.TableID = Restaurant_Tables.TableID;">
        <DeleteParameters>
            <asp:Parameter Name="UserId" Type="Object" />
            <asp:Parameter Name="TableID" Type="Int32" />
            <asp:Parameter Name="TimeFromID" Type="DateTime" />
            <asp:Parameter Name="TimeToID" Type="DateTime" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="UserId" Type="Object" />
            <asp:Parameter Name="TableID" Type="Int32" />
            <asp:Parameter Name="TimeFromID" Type="DateTime" />
            <asp:Parameter Name="TimeToID" Type="DateTime" />
        </InsertParameters>
    </asp:SqlDataSource>
    
    </asp:Content>