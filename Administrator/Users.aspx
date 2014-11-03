<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="Administrator_Users" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Brukere</h1>
    <p>
        <asp:TextBox ID="UsersTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="Search" runat="server" Text="S&oslash;k"/>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="UsersTextBox" ErrorMessage="*"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" DeleteText="Slett" ButtonType="Button"/>
                <asp:BoundField DataField="UserId" HeaderText="UserId" 
                    SortExpression="UserId" />
                <asp:BoundField DataField="Brukernavn" HeaderText="Brukernavn" 
                    SortExpression="Brukernavn" />
                <asp:BoundField DataField="Adresse" HeaderText="Adresse" 
                    SortExpression="Adresse" />
                <asp:BoundField DataField="Postnummer" HeaderText="Postnummer" 
                    SortExpression="Postnummer" />
                <asp:BoundField DataField="Sted" HeaderText="Sted" SortExpression="Sted" />
                <asp:BoundField DataField="Epost" HeaderText="Epost" SortExpression="Epost" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT aspnet_Users.UserId, aspnet_Users.UserName AS Brukernavn, UserAddress.Address AS Adresse, UserAddress.ZipCode AS Postnummer, UserAddress.City AS Sted, aspnet_Membership.Email AS Epost FROM aspnet_Users, UserAddress, aspnet_Membership 
            WHERE ([UserName] LIKE + @UserName + '%')
            AND aspnet_Users.UserId = aspnet_Membership.UserId
            AND aspnet_Users.UserId = UserAddress.UserId;" ConflictDetection="CompareAllValues"

        DeleteCommand="DELETE FROM aspnet_Users WHERE (UserId = @original_UserId)"
        OldValuesParameterFormatString="original_{0}" 
        
        UpdateCommand="UPDATE UserAddress SET Address = @Address, ZipCode = @ZipCode, City = @City WHERE (UserId = @original_UserId)">
    
      <SelectParameters>
          <asp:ControlParameter ControlID="UsersTextBox" DefaultValue="" Name="UserName" 
              PropertyName="Text" Type="String" />
      </SelectParameters>
    
     <DeleteParameters>
         <asp:Parameter Name="original_UserId" Type="Object" />
     </DeleteParameters>
     
     <UpdateParameters>
         <asp:Parameter Name="Address" Type="String"/>
         <asp:Parameter Name="ZipCode" Type="Int32" />
         <asp:Parameter Name="City" Type="String" />
         <asp:Parameter Name="original_UserId" Type="Object"/>
     </UpdateParameters>
    
    </asp:SqlDataSource>
    </p>

</asp:Content>

