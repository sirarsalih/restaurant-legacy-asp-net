<%@ Page Language="C#" MasterPageFile="../MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Logg inn</h1> 
    <p>
                         <asp:Login ID="Login1" runat="server" 
                             FailureText="Det skjedde en feil med innloggingen. Vennligst pr&oslash;v p&aring; nytt." 
                             LoginButtonText="Logg inn" PasswordLabelText="Passord:" 
                             RememberMeText="Husk meg neste gang." TitleText="Logg inn" 
                             UserNameLabelText="Brukernavn:" 
                             PasswordRequiredErrorMessage="Passord mangler." 
                             UserNameRequiredErrorMessage="Brukernavn mangler." 
                             onloggedin="Login1_LoggedIn" 
                             DestinationPageUrl="~/AuthenticatedUsers/RedirectAuthenticated.aspx">
                        </asp:Login>
    </p>
    <p>
        Glemt passordet ditt? Trykk <a href="PasswordRecovery.aspx">her</a>.
    </p>
</asp:Content>

