<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ActiveReservation.aspx.cs" Inherits="User_ActiveReservation" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Reserveringer</h1>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Brukernavn" HeaderText="Brukernavn" 
                    SortExpression="Brukernavn" />
                <asp:BoundField DataField="Bordnummer" HeaderText="Bordnummer" 
                    SortExpression="Bordnummer" />
                <asp:BoundField DataField="Seter" HeaderText="Seter" SortExpression="Seter" />
                <asp:BoundField DataField="Fra" HeaderText="Fra" SortExpression="Fra" />
                <asp:BoundField DataField="Til" HeaderText="Til" SortExpression="Til" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="NoReservationLabel" runat="server" ForeColor="Red" 
            Text="Ingen reserveringer."></asp:Label>
            </p>
    <p>
        <asp:Label ID="ContactLabel" runat="server" 
            Text="(&Oslash;nsker du &aring; avbestille dine reserveringer m&aring; du kontakte oss via kontakt siden.)"></asp:Label>
    </p>
    <p>
            <asp:Label ID="Middleman" runat="server" Visible="False"></asp:Label>
    </p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT aspnet_Users.UserName AS Brukernavn, Restaurant_Tables.TableNumber AS Bordnummer, Restaurant_Tables.Seats AS Seter, Reservation.TimeFromID AS Fra, Reservation.TimeToID AS Til
            FROM aspnet_Users, Restaurant_Tables, Reservation
            WHERE aspnet_Users.UserId = Reservation.UserId
            AND Reservation.TableID = Restaurant_Tables.TableID
            AND  (aspnet_Users.UserId = @UserID);">
            <SelectParameters>
                <asp:ControlParameter ControlID="Middleman" Name="UserID" PropertyName="Text" Type="String"/>
            </SelectParameters>
        </asp:SqlDataSource>
    <p>
        &nbsp;</p>
</asp:Content>

