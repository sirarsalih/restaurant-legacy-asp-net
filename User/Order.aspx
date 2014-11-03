<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="User_Order" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Bestilling</h1>
    
    <p>Matrett:
        <asp:Label ID="DishOrderLabel" runat="server" Text="Label"></asp:Label>
                </p>
                <p>Pris:
                    <asp:Label ID="DishOrderPriceLabel" runat="server" Text="Label"></asp:Label>
                    kr.</p>
                <p>Antall:
                    <asp:Label ID="DishAmountLabel" runat="server"
                                Text="1" Width="21px" style="text-align:center" Height="16px"/>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Design/Images/Down.jpg"
                                AlternateText="Down" Width="15" Height="9" 
                        onclick="ImageButton1_Click"/>
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../Design/Images/Up.jpg"
                                AlternateText="Up" Width="15" Height="9" 
                        onclick="ImageButton2_Click"/>
    </p>
    <p>Tidspunkt:
        <asp:TextBox ID="OrderTimeTexbox" runat="server" Width="18px"></asp:TextBox>
        :<b>
        <asp:TextBox ID="OrderTimeTexbox2" runat="server" Width="18px"></asp:TextBox>
        (00:00)<asp:RangeValidator ID="RangeValidator2" runat="server" 
            ControlToValidate="OrderTimeTexbox2" ErrorMessage="*" Font-Bold="False" 
            MaximumValue="59" MinimumValue="00"></asp:RangeValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" 
            ControlToValidate="OrderTimeTexbox" 
            ErrorMessage="Ugyldig tidspunkt. Sjekk &aring;pningstider." Font-Bold="False" 
            MaximumValue="24" MinimumValue="14"></asp:RangeValidator>
        </b></p>
    <p>
        <asp:Button ID="Save" runat="server" onclick="Save_Click"
            Text="Legg i handlevogn" />
    </p>
    
    <tr>
                        
                        <td>
                        </td>
                    </tr>

</asp:Content>

