<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeEmail.aspx.cs" Inherits="User_ChangeEmail" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h1>Rediger e-post</h1>

    <asp:LoginView ID="LoginView6" runat="server">        
        
    <LoggedInTemplate> 
    </LoggedInTemplate>
    
    <RoleGroups>          
       
       <asp:RoleGroup Roles="User">


    <ContentTemplate>                            

         <tr>
                                <td align="right">
                                    Skriv inn den nye e-posten din i feltet nedenfor og trykk p&aring; bekreft.<br />
                                    <asp:Label ID="EmailLabel" runat="server">E-post:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="EmailBox" runat="server" Height="20px" Width="124px"></asp:TextBox>
                                </td>
                            </tr>
                            
        <tr>
           <td align="center" colspan="2" style="color:Red;">
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                   ControlToValidate="EmailBox" 
                   ErrorMessage="Du m&aring; skrive inn en gyldig e-post adresse." 
                   ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
               <asp:Label ID="Hidden_Email" runat="server" Visible="False"></asp:Label>
               
               <br />
               
        </td>
        </tr>
        <tr>
         <td align="center" colspan="2" style="color:Red;">
                   &nbsp;</td>
        </tr>

         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Submit" runat="server" Text="Bekreft" onclick="Submit_Click"/>

    </ContentTemplate>
    
   </asp:RoleGroup>
   </RoleGroups>
   
        
    </asp:LoginView>

</asp:Content>

