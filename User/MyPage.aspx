<%@ Page Language="C#" MasterPageFile="../MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="MyPage.aspx.cs" Inherits="MyPage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Min side</h1>
    <asp:LoginView ID="LoginView1" runat="server">        
        
    <LoggedInTemplate> 
    </LoggedInTemplate>
    
    <RoleGroups>    
       
       <asp:RoleGroup Roles="User">
           
           <ContentTemplate>
               <a href="ActiveOrder.aspx">Aktive bestillinger</a> 
               <br />
               <a href="ActiveReservation.aspx">Reserveringer</a> 
               <br />
               <a href="ShoppingBasket.aspx">Handlevogn</a>  
               <br />
               <a href="History.aspx">Historikk</a>  
               <br />
               <a href="PersonalInformation.aspx">Rediger personlig informasjon</a>
               <br />
               <a href="ChangePassword.aspx">Rediger passord</a>
               <br />
               <a href="ChangeEmail.aspx">Rediger e-post</a> 
           </ContentTemplate>
       
       </asp:RoleGroup>
   </RoleGroups>
   
        
    </asp:LoginView>
    
<p>
</p>
</asp:Content>

