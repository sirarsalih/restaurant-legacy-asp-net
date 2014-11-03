<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PasswordRecovery.aspx.cs" Inherits="Main_PasswordRecovery" Title="Untitled Page" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Glemt passord</h1>
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" 
        AnswerLabelText="Svar:" AnswerRequiredErrorMessage="Hemmelig svar mangler." 
        GeneralFailureText="Det oppstod en feil med sendingen av passordet ditt. Vennligst pr&oslash;v p&aring; nytt." 
        QuestionFailureText="Svaret du oppgav kunne ikke godkjennes. Vennligst pr&oslash;v p&aring; nytt." 
        QuestionInstructionText="Svar p&aring; f&oslash;lgende sp&oslash;rsm&aring;l for &aring; motta det nye passordet." 
        QuestionLabelText="Sp&oslash;rsm&aring;l:" QuestionTitleText="" SubmitButtonText="Bekreft" 
        SuccessText="Nytt passord har blitt tilsendt deg." 
        UserNameFailureText="Det oppstod en feil med brukernavnet ditt. Vennligst pr&oslash;v p&aring; nytt." 
        UserNameInstructionText="Skriv brukernavnet ditt i feltet under for &aring; f&aring; et nytt passord tilsendt deg." 
        UserNameLabelText="Brukernavn:" 
        UserNameRequiredErrorMessage="Brukernavn mangler." UserNameTitleText="">
        
          
        <MailDefinition From="post@1001-natt.no" Subject="Test e-mail">
                
        
        </MailDefinition>       
       
               
        
    </asp:PasswordRecovery>
</asp:Content>

