<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="TableReservation.aspx.cs" Inherits="Main_TableReservation" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Bord reservering</h1>
    <p>
        <asp:Label ID="MustChooseDayLabel" runat="server" ForeColor="Red" 
            Text="Du m&aring; velge dag fra kalender." Visible="False"></asp:Label>
        <br />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" OnDayRender="MyCalendar_DayRender"
            BorderColor="Black" Font-Names="Times New Roman" Font-Size="10pt" 
            ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" Width="400px" 
            onselectionchanged="Calendar1_SelectionChanged" DayNameFormat="Shortest" 
            TitleFormat="Month">
            <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" 
                Font-Size="8pt" ForeColor="#333333" Width="1%" />
            <TodayDayStyle BackColor="#CCCCCC" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="Gray" 
                VerticalAlign="Bottom"/>
            <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" 
                ForeColor="#333333" Height="10pt" />
            <TitleStyle BackColor="Black" 
                Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
        </asp:Calendar>
    </p>
    <p>
        <asp:Label ID="TimeLabel" runat="server" Text="Ledige tidspunkter:"></asp:Label>
        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Height="20px" 
            Width="103px">
            <asp:ListItem>Velg dag</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="TableLabel" runat="server" Text="Velg bord:"></asp:Label>
        &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" Height="20px" 
            Width="69px" AutoPostBack="True">
            <asp:ListItem>Velg...</asp:ListItem>
            <asp:ListItem Value="1">Bord 1</asp:ListItem>
            <asp:ListItem Value="2">Bord 2</asp:ListItem>
            <asp:ListItem Value="3">Bord 3</asp:ListItem>
            <asp:ListItem Value="4">Bord 4</asp:ListItem>
            <asp:ListItem Value="5">Bord 5</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="SeatsAmountLabel" runat="server" Text="Antall seter:" 
            Visible="False"></asp:Label>
        &nbsp;<asp:Label ID="SeatsLabel" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="MustChooseTableLabel" runat="server" ForeColor="Red" 
            Text="Du m&aring; velge bord." Visible="False"></asp:Label>
    </p>
    <p>
        Tidspunkt:&nbsp; <asp:TextBox ID="FromTimeTexbox" runat="server" Width="18px"></asp:TextBox>
        :<b>
        <asp:TextBox ID="FromTimeTexbox2" runat="server" Width="18px"></asp:TextBox>
        (00:00) </b>Til<b>
        <asp:TextBox ID="ToTimeTextBox" runat="server" Width="18px"></asp:TextBox>
        </b>:<b>
        <asp:TextBox ID="ToTimeTextBox2" runat="server" Width="18px"></asp:TextBox>
        (00:00)<asp:RangeValidator ID="RangeValidator1" runat="server" 
            ControlToValidate="FromTimeTexbox" ErrorMessage="*" Font-Bold="False" 
            MaximumValue="24" MinimumValue="14"></asp:RangeValidator>
        <asp:RangeValidator ID="RangeValidator3" runat="server" 
            ControlToValidate="ToTimeTextBox" ErrorMessage="RangeValidator" 
            Font-Bold="False" MaximumValue="24" MinimumValue="14">*</asp:RangeValidator>
        <asp:RangeValidator ID="RangeValidator4" runat="server" 
            ControlToValidate="ToTimeTextBox2" ErrorMessage="RangeValidator" 
            Font-Bold="False" MaximumValue="59" MinimumValue="00">*</asp:RangeValidator>
        <asp:RangeValidator ID="RangeValidator2" runat="server" 
            ControlToValidate="FromTimeTexbox2" ErrorMessage="*" Font-Bold="False" 
            MaximumValue="59" MinimumValue="00">Ugyldig tidspunkt.</asp:RangeValidator>
        &nbsp;<asp:Label ID="EmptyTimeLabel" runat="server" Font-Bold="False" ForeColor="Red" 
            Text="Et eller flere tidsfelt er tomt." Visible="False"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
    <p>
        <asp:Button ID="ReserveButton" runat="server" onclick="Check_Click" 
            Text="Sjekk tidspunkt" />
        <asp:Label ID="Check1" runat="server" Text="NOT OK1" Visible="False" 
            Font-Bold="False" ForeColor="#33CC33"></asp:Label>
        <asp:Label ID="Check2" runat="server" Text="NOT OK2" Visible="False" 
            Font-Bold="False" ForeColor="#33CC33"></asp:Label>
        <asp:Label ID="Minimum" runat="server" Font-Bold="False" ForeColor="Red" 
            Text="Minimum 30 minutter reservering." Visible="False"></asp:Label>
        <b>
        <asp:Label ID="WrongTimeLabel" runat="server" Font-Bold="False" ForeColor="Red" 
            Text="Tidspunkt passer ikke. Sjekk kalender." Visible="False"></asp:Label>
        <asp:Label ID="NoReserveLabel" runat="server" Text="Tidspunktet passer ikke." 
            Font-Bold="False" ForeColor="Red" Visible="False"></asp:Label>
        </br>
        <asp:Button ID="Undo" runat="server" onclick="Undo_Click" Text="Angre" />
    </b>
    </p>
    </b></asp:Content>

