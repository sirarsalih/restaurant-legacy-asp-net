<%@ Page Language="C#" MasterPageFile="../MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Registrer deg</h1>
    <p>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
            ContinueDestinationPageUrl="~/Main/Index.aspx" CancelButtonText="Avbryt" 
            CreateUserButtonText="Registrer deg n&aring;" 
            DuplicateEmailErrorMessage="E-posten er allerede i bruk. Vennligst skriv en ny e-post." 
            DuplicateUserNameErrorMessage="Brukernavn allerede i bruk. Vennligst skriv et annet brukernavn." 
            FinishCompleteButtonText="Fullf&oslash;rt" FinishPreviousButtonText="Forrige" 
            InvalidAnswerErrorMessage="Vennligst skriv et annet hemmelig svar." 
            InvalidEmailErrorMessage="Vennligst skriv en lovlig e-post adresse." 
            InvalidPasswordErrorMessage="Passord lengde minimum: {0}. Spesial tegn trengs: {1}." 
            InvalidQuestionErrorMessage="Vennligst skriv et annet hemmelig sp&oslash;rsm&aring;l." 
            StartNextButtonText="Neste" StepNextButtonText="Neste" 
            StepPreviousButtonText="Forrige" 
            
            
            UnknownErrorMessage="Din konto ble ikke opprettet. Vennligst pr&oslash;v p&aring; nytt." 
            oncreateduser="CreateUserWizard1_CreatedUser" 
            Width="312px">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep" runat="server">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Brukernavn:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="Brukernavn mangler." 
                                        ToolTip="Brukernavn mangler." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Passord:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Passord mangler." 
                                        ToolTip="Passord mangler." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                        AssociatedControlID="ConfirmPassword">Bekreft passord:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                        ControlToValidate="ConfirmPassword" 
                                        ErrorMessage="Du m&aring; bekrefte passord." 
                                        ToolTip="Du m&aring; bekrefte passord." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-post:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                        ControlToValidate="Email" ErrorMessage="E-post mangler." 
                                        ToolTip="E-post mangler." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                 <td align="right">
                                    <asp:Label ID="Addresslabel" runat="server" AssociatedControlID="Address">Adresse:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Address" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="Address" ErrorMessage="Adresse mangler." 
                                        ToolTip="Adresse manger." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                 <td align="right">
                                    <asp:Label ID="ZipCodelabel" runat="server" AssociatedControlID="ZipCode">Post 
                                     nummer:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ZipCode" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="ZipCode" ErrorMessage="Post nummer mangler." 
                                        ToolTip="Post nummer mangler." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                                                        <tr>
                                 <td align="right">
                                    <asp:Label ID="Citylabel" runat="server" AssociatedControlID="City">By:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="City" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="City" ErrorMessage="By mangler." 
                                        ToolTip="By mangler." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Hemmelig 
                                    sp&oslash;rsm&aring;l:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                        ControlToValidate="Question" ErrorMessage="Hemmelig sp&oslash;rsm&aring;l mangler." 
                                        ToolTip="Hemmelig sp&oslash;rsm&aring;l mangler." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Hemmelig 
                                    svar:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                        ControlToValidate="Answer" ErrorMessage="Hemmelig svar mangler." 
                                        ToolTip="Hemmelig svar mangler." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                        ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                        Display="Dynamic" 
                                        ErrorMessage="Passord og bekreftelse av passord m&aring; v&aelig;re like." 
                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                </td>
                            </tr>                            
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                        ControlToValidate="ZipCode" Display="Dynamic" 
                                        ErrorMessage="Post nummer er galt." MaximumValue="9999" MinimumValue="1111" 
                                        Type="Integer" ValidationGroup="CreateUserWizard1"></asp:RangeValidator>
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                        
                       
                       <asp:SqlDataSource ID="InsertExtraInfo" runat="server" ConnectionString="<%$ ConnectionStrings:InsertExtraInfo %>"
                        InsertCommand="INSERT INTO [UserAddress] ([UserId], [Address], [ZipCode], [City]) VALUES (@UserId, @Address, @ZipCode, @City)"
                        ProviderName="<%$ ConnectionStrings:InsertExtraInfo.ProviderName %>">
                         <InsertParameters>
                             <asp:ControlParameter Name="Address" Type="String" ControlID="Address" PropertyName="Text" />
                             <asp:ControlParameter Name="ZipCode" Type="String" ControlID="ZipCode" PropertyName="Text" />
                             <asp:ControlParameter Name="City" Type="String" ControlID="City" PropertyName="Text" />
                         </InsertParameters>
                        </asp:SqlDataSource>
                        
                    </ContentTemplate> 
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Fullf&oslash;rt</td>
                            </tr>
                            <tr>
                                <td>
                                    Din konto er blitt opprettet. Du blir n&aring; logget inn.</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    &nbsp;<asp:Button ID="ContinueButton" runat="server" CausesValidation="False" 
                                        CommandName="Continue" Text="Tilbake til hovedsiden." 
                                        ValidationGroup="CreateUserWizard1" onclick="ContinueButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
        <br />
    </p>
    <p>
    </p>

    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>

</asp:Content>

