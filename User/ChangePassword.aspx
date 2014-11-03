<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="User_ChangePassword" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Rediger passord</h1>
    <asp:LoginView ID="LoginView3" runat="server">        
        
    <LoggedInTemplate> 
    </LoggedInTemplate>
    
    <RoleGroups>          
       
       <asp:RoleGroup Roles="User">


    <ContentTemplate>                            

        <asp:ChangePassword ID="ChangePassword1" runat="server" 
            CancelButtonText="Avbryt" ChangePasswordButtonText="Bekreft" 
            ChangePasswordFailureText="Passord eller nytt passord er galt. Nytt passord lengde minimum: {0}. Spesial tegn: {1}." 
            ChangePasswordTitleText="" ConfirmNewPasswordLabelText="Bekreft nytt passord:" 
            ConfirmPasswordCompareErrorMessage="Bekreft nytt passord feltet m&aring; v&aelig;re likt nytt passord feltet." 
            ConfirmPasswordRequiredErrorMessage="Bekreft nytt passord mangler." 
            ContinueButtonText="Fortsett" NewPasswordLabelText="Nytt passord:"  ContinueDestinationPageUrl="~/User/MyPage.aspx"
            NewPasswordRegularExpressionErrorMessage="Vennligst skriv et annet nytt passord." 
            NewPasswordRequiredErrorMessage="Nytt passord mangler." 
            PasswordLabelText="N&aring;v&aelig;rende passord:" 
            PasswordRequiredErrorMessage="N&aring;v&aelig;rende passord mangler." 
            SuccessText="Passordet ditt har blitt endret!" SuccessTitleText="" 
            UserNameLabelText="Brukernavn:" 
            UserNameRequiredErrorMessage="Brukernavn mangler.">
        </asp:ChangePassword>

    </ContentTemplate>
    
   </asp:RoleGroup>
   </RoleGroups>
   
        
    </asp:LoginView>


</asp:Content>

