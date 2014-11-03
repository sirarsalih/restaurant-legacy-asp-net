<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PersonalInformation.aspx.cs" Inherits="Main_Account" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <h1>Rediger personlig informasjon</h1>
                 
    <asp:LoginView ID="LoginView2" runat="server">        
        
    <LoggedInTemplate> 
    </LoggedInTemplate>
    
    <RoleGroups>          
       
       <asp:RoleGroup Roles="User">
           
           <ContentTemplate>
              
              <table border="0">
                           <tr>
                                <td>
                                    <asp:Label ID="Addresslabel" runat="server" Text="Adresse:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="AddressTextBox" runat="server"></asp:TextBox>
                                    
                                </td>
                                <td>
                                    <asp:Label ID="Hidden_Address" runat="server" Text="Label"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="AddressTextBox" 
                                        ErrorMessage="Du m&aring; fylle inn adresse."></asp:RequiredFieldValidator>
                                </td>
                           </tr>
                           
                           <tr>
                                 <td>
                                     <asp:Label ID="ZipCodelabel" runat="server" Text="Postnummer:"></asp:Label>
                                     
                                 </td>
                                 <td>
                                     <asp:TextBox ID="ZipCodeTextBox" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:Label ID="Hidden_ZipCode" runat="server" Text="Label"></asp:Label>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                         ControlToValidate="ZipCodeTextBox" ErrorMessage="M&aring; v&aelig;re et gyldig postnummer." 
                                         ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                 </td>
                           </tr>
                           
                           <tr>
                                 <td>
                                     <asp:Label ID="Citylabel" runat="server" Text="By:"></asp:Label>
                                 </td>
                                 <td>
                                     <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
                                 </td>
                                 <td>
                                     <asp:Label ID="Hidden_City" runat="server" Text="Label"></asp:Label>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                         ErrorMessage="Du m&aring; fylle inn by." 
                                         ControlToValidate="CityTextBox"></asp:RequiredFieldValidator>
                                 </td>
                           </tr>
                           
                           <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Button ID="Submit" runat="server" onclick="Submit_Click" 
                                        Text="Bekreft" />
                                </td>
                           </tr>
                            
                            
                        </table>
           
           </ContentTemplate>
       
       </asp:RoleGroup>
   </RoleGroups>
   
        
    </asp:LoginView>
    
</asp:Content>

