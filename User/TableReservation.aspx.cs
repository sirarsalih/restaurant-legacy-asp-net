using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Main_TableReservation : System.Web.UI.Page
{
    //Declaration
    string[] mon_thur;
    string[] fri_sat;
    string[] sunday;
    int day;
    int month;
    string dayofweek;

    protected void MyCalendar_DayRender(object source, DayRenderEventArgs e)
    {        
        //Users can only select days within this month and in future months and only as long as the day they choose is not behind the current day
        if(e.Day.IsOtherMonth)
        {
            e.Day.IsSelectable=false;
        }

        if (e.Day.Date.Day < Calendar1.TodaysDate.Day)
        {
            e.Day.IsSelectable = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //--------------------------------------------------
        // To prevent session-data and important test to be
        // reset when doing postback
        //--------------------------------------------------
        if (!IsPostBack)
        {
            bool isReadyToOrder = false;
            bool check1 = false;
            bool check2 = false;
            bool check3 = false;

            Undo.Visible = false;

            ReserveButton.Text = "Sjekk tidspunkt";
            Check1.Visible = false;
            Check2.Visible = false;
            MustChooseTableLabel.Visible = false;

            Session["isReadyToOrder"] = isReadyToOrder;
            Session["check1"] = check1;
            Session["check2"] = check2;
            Session["check3"] = check3;
        }

        //----------------------------------------------
        // A test to prevent the user from not choosing 
        // a table
        //----------------------------------------------
        if (DropDownList2.SelectedValue != "Velg...")
        {
            MustChooseTableLabel.Visible = false;

            Database db = new Database();

            SeatsLabel.Text = db.selectTableSeats(Convert.ToInt32(DropDownList2.SelectedValue)).ToString();
            SeatsLabel.Visible = true;
            SeatsAmountLabel.Visible = true;

        }
        else
        {
            SeatsLabel.Visible = false;
            SeatsAmountLabel.Visible = false;
        }
    }

    //--------------------------------------------------------------
    // This is where we test if the booleanArray is full of 'Trues'
    // or if it contains a false element
    //--------------------------------------------------------------
    public bool ArraysEqual(bool[] booleanArray)
    {
        foreach (bool k in booleanArray)
        {
           if(k != true)
           {
               return false;
           }
        }
        return true;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        MustChooseDayLabel.Visible = false;

        day = Calendar1.SelectedDate.Day;
        month = Calendar1.SelectedDate.Month;
        dayofweek = Calendar1.SelectedDate.DayOfWeek.ToString();


        mon_thur = new string[10] { "1400", "1500", "1600", "1700", "1800", "1900", "2000", "2100", "2200", "2300" };
        fri_sat = new string[11] { "1400", "1500", "1600", "1700", "1800", "1900", "2000", "2100", "2200", "2300", "2400" };
        sunday = new string[8] { "1400", "1500", "1600", "1700", "1800", "1900", "2000", "2100" };

        //-----------------------------------------------------
        // This switch/case statement allows the users to view
        // the opening and closing time of the restaurant for
        // the day they choose
        //-----------------------------------------------------
        switch (dayofweek)
        {
            case "Monday":
                DropDownList1.DataSource = mon_thur;
                break;
            case "Tuesday":
                DropDownList1.DataSource = mon_thur;
                break;
            case "Wednesday":
                DropDownList1.DataSource = mon_thur;
                break;
            case "Thursday":
                DropDownList1.DataSource = mon_thur;
                break;
            case "Friday":
                DropDownList1.DataSource = fri_sat;
                break;
            case "Saturday":
                DropDownList1.DataSource = fri_sat;
                break;
           case "Sunday":
                DropDownList1.DataSource = sunday;
                break;
        }
        // Adds the time to the dropdownlist
        DropDownList1.DataBind();
    
    }

    protected void Check_Click(object sender, EventArgs e)
    {
        //Puts session varibles into our checks so that we can use them
        bool check1 = Convert.ToBoolean(Session["check1"]);
        bool check2 = Convert.ToBoolean(Session["check2"]);
        bool check3 = Convert.ToBoolean(Session["check3"]);
        bool isReadyToOrder = Convert.ToBoolean(Session["isReadyToOrder"]);


        //----------------------------------------------
        // A test to prevent the user from not choosing 
        // a table
        //----------------------------------------------
        if (DropDownList2.SelectedValue == "Velg...")
        {
            MustChooseTableLabel.Visible = true;
            check3 = false;            
        }
        else
        {
            MustChooseTableLabel.Visible = false;   
            check3 = true;
        }

        //Check to see if the textboxes are empty
        TextBoxCheck tbc = new TextBoxCheck();

        bool checking = tbc.textBoxChecks(FromTimeTexbox, FromTimeTexbox2, EmptyTimeLabel, ToTimeTextBox, ToTimeTextBox2);

        //Is one of the textboxes empty?
        if (checking)
        {   
            //Yes
            return;
        }
        
        //No
        else
        {
            // Checks to see if the user hasn't chosen a day
            if (DropDownList1.SelectedValue == "Velg dag")
            {
                MustChooseDayLabel.Visible = true;
            }
            else
            {
                    MustChooseDayLabel.Visible = false;
                    int maxCounter;
                    for (maxCounter = 0; maxCounter < DropDownList1.Items.Count; maxCounter++)
                    {

                    }
                    // Declarations
                    int DropDownListMaxHour = Convert.ToInt32(DropDownList1.Items[maxCounter - 1].ToString());
                    int DropDownListMinHour = Convert.ToInt32(DropDownList1.Items[0].ToString());

                    string FromTimeText = FromTimeTexbox.Text + FromTimeTexbox2.Text;
                    string ToTimeText = ToTimeTextBox.Text + ToTimeTextBox2.Text;

                    int FromTimeTextHour = Convert.ToInt32(FromTimeText);
                    int ToTimeTextHour = Convert.ToInt32(ToTimeText);

                    // Gets the UserID
                    MembershipUser myObject = Membership.GetUser(User.Identity.Name);
                    object UserID = myObject.ProviderUserKey;


                    //------------------------------------------
                    //
                    //Check textbox values against dropdownlist
                    //
                    //------------------------------------------
                    if (FromTimeTextHour > DropDownListMaxHour)
                    {
                        WrongTimeLabel.Visible = true;
                        return;
                    }
                    else if (FromTimeTextHour <= DropDownListMaxHour && FromTimeTextHour >= DropDownListMinHour)
                    {
                        WrongTimeLabel.Visible = false;
                        //FromTimeTextHour OK
                        Check1.Text = "Tidspunkt ";
                        Check1.Visible = false;
                        check1 = true;
                    }
                    else if (FromTimeTextHour < DropDownListMinHour)
                    {
                        WrongTimeLabel.Visible = true;
                        return;
                    }

                    if (ToTimeTextHour > DropDownListMaxHour)
                    {
                        WrongTimeLabel.Visible = true;
                        Check1.Visible = false;
                        Check2.Visible = false;
                        return;
                    }
                    else if (ToTimeTextHour <= DropDownListMaxHour && ToTimeTextHour >= DropDownListMinHour)
                    {
                        WrongTimeLabel.Visible = false;
                        //ToTimeTextHour OK
                        Check2.Text = "passer.";
                        Check2.Visible = false;
                        check2 = true;
                    }

                    if (Convert.ToInt32(FromTimeTexbox.Text) > Convert.ToInt32(ToTimeTextBox.Text))
                    {

                        WrongTimeLabel.Visible = true;
                        Check1.Visible = false;
                        Check2.Visible = false;
                        check2 = false;
                    }
                    else
                    {
                        WrongTimeLabel.Visible = false;
                    }

                    if (Convert.ToInt32(FromTimeTexbox.Text) == Convert.ToInt32(ToTimeTextBox.Text) && Convert.ToInt32(ToTimeTextBox2.Text) < (Convert.ToInt32(FromTimeTexbox2.Text) + 30))
                    {
                        Minimum.Visible = true;
                        Check1.Visible = false;
                        Check2.Visible = false;

                        check1 = false;
                        check2 = false;
                        check3 = false;
                    }
                    else
                    {
                        Minimum.Visible = false;
                    }

                    //-------------------------------------------------------------
                    // If the time selected fits, it will then go into this one
                    // This is where the table reservation will be inserted into
                    // the Reservation table
                    //------------------------------------------------------------
                    if (isReadyToOrder)
                    {

                        Database db = new Database();
                        string selectedDate = Calendar1.SelectedDate.ToString();

                        int selectedDateLength = selectedDate.Length;
                        string selectedDay = selectedDate.Remove(selectedDateLength - 8);

                        string date = selectedDay.Substring(3, 2) + "." + selectedDay.Substring(0, 2) + selectedDay.Substring(5);

                        db.insertReserveOrder(UserID.ToString(), Convert.ToInt32(DropDownList2.SelectedValue), date + FromTimeText.Substring(0, 2) + ":" + FromTimeText.Substring(2, 2) + ":00", date + ToTimeText.Substring(0, 2) + ":" + ToTimeText.Substring(2, 2) + ":00", date);

                        isReadyToOrder = false;

                        Undo.Visible = false;

                        check1 = false;
                        check2 = false;
                        check3 = false;

                        FromTimeTexbox.Enabled = true;
                        FromTimeTexbox2.Enabled = true;
                        ToTimeTextBox.Enabled = true;
                        ToTimeTextBox2.Enabled = true;

                        Calendar1.Enabled = true;
                        DropDownList1.Enabled = true;
                        DropDownList2.Enabled = true;

                        Response.Redirect("ActiveReservation.aspx");

                    }

                    //---------------------------------------------------------
                    // If the time selected fits with the opening and closing
                    // hours, and if the selected time is not less than 30 minutes
                    //
                    // It will then select all the reservations for that table
                    // on the selected day, and do tests to see if the time 
                    // the User wants fits with the database
                    //---------------------------------------------------------
                    if (check1 == true && check2 == true && check3 == true)
                    {

                        Database db = new Database();
                        ArrayList al = new ArrayList();

                        string selectedDate = Calendar1.SelectedDate.ToString().Substring(3, 2) + "." + Calendar1.SelectedDate.ToString().Substring(0, 2) + Calendar1.SelectedDate.ToString().Substring(5);
                        al = db.selectReserveDay(Convert.ToInt32(DropDownList2.SelectedValue), selectedDate);

                        //-------------------------------------------------
                        // If no reservations for the selected day are made,
                        // we can skip further tests and go in here
                        //-------------------------------------------------
                        if (al.Count == 1)
                        {

                            ReserveButton.Text = "Reserver nå!";
                            Check1.Visible = true;
                            Check2.Visible = true;

                            isReadyToOrder = true;

                            FromTimeTexbox.Enabled = false;
                            FromTimeTexbox2.Enabled = false;
                            ToTimeTextBox.Enabled = false;
                            ToTimeTextBox2.Enabled = false;

                            Calendar1.Enabled = false;
                            DropDownList1.Enabled = false;
                            DropDownList2.Enabled = false;


                        }

                        //------------------------------------------------
                        // Else if there are any reservations for that table on the seleced day
                        //------------------------------------------------
                        else
                        {
                            bool[] booleanArray = new bool[al.Count / 2];

                            bool[] arrayCompare = new bool[booleanArray.Count()];

                            string fromDateTime = "";
                            string toDateTime = "";

                            string fromTime = "";
                            string toTime = "";

                            string temp = "";
                            string temp2 = "";

                            int fromTimeDatabase = 0;
                            int toTimeDatabase = 0;
                            int fromTimeUser = 0;
                            int toTimeUser = 0;
                            int j = 0;

                            //------------------------------------------------------------------
                            // Runs through all the reservations for the selected table for the
                            // selected day
                            // and does the check
                            //------------------------------------------------------------------
                            for (int i = 0; i < al.Count; i = i + 2)
                            {
                                fromDateTime = fromDateTime = al[i].ToString();
                                toDateTime = toDateTime = al[i + 1].ToString();

                                fromTime = fromDateTime.Remove(0, 10);
                                toTime = toDateTime.Remove(0, 10);

                                temp = fromTime.Replace(":", "");
                                temp2 = toTime.Replace(":", "");

                                fromTimeDatabase = Convert.ToInt32(temp);
                                toTimeDatabase = Convert.ToInt32(temp2);

                                fromTimeUser = (FromTimeTextHour * 100);
                                toTimeUser = (ToTimeTextHour * 100);

                                // This is the test
                                if (((fromTimeUser < fromTimeDatabase) && (toTimeUser < fromTimeDatabase)) || (fromTimeUser > toTimeDatabase))
                                {
                                    //Can reserve at given time
                                    booleanArray[j] = true;
                                }
                                else
                                {
                                    //Can not reserve
                                    booleanArray[j] = false;
                                }
                                j++;

                            }
                            // If all the tests return true
                            if (ArraysEqual(booleanArray))
                            {
                                isReadyToOrder = true;
                                Undo.Visible = true;
                                ReserveButton.Text = "Reserver nå!";

                                Check1.Visible = true;
                                Check2.Visible = true;

                                FromTimeTexbox.Enabled = false;
                                FromTimeTexbox2.Enabled = false;
                                ToTimeTextBox.Enabled = false;
                                ToTimeTextBox2.Enabled = false;

                                Calendar1.Enabled = false;
                                DropDownList1.Enabled = false;
                                DropDownList2.Enabled = false;
                            }
                            else
                            {
                                WrongTimeLabel.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        check1 = false;
                        check2 = false;
                    }
            }
        }
        // Puts the variables to the session so that they're not lost.
        Session["isReadyToOrder"] = isReadyToOrder;
        Session["check1"] = check1;
        Session["check2"] = check2;
    }

    // This button will undo all the variables so that the users can
    // select a new time
    protected void Undo_Click(object sender, EventArgs e)
    {
        FromTimeTexbox.Enabled = true;
        FromTimeTexbox2.Enabled = true;
        ToTimeTextBox.Enabled = true;
        ToTimeTextBox2.Enabled = true;

        Calendar1.Enabled = true;
        DropDownList1.Enabled = true;
        DropDownList2.Enabled = true;

        bool isReadyToOrder = false;
        bool check1 = false;
        bool check2 = false;

        Session["isReadyToOrder"] = isReadyToOrder;
        Session["check1"] = check1;
        Session["check2"] = check2;
        
        Undo.Visible = false;

        ReserveButton.Text = "Sjekk tidspunkt";

        Check1.Visible = false;
        Check2.Visible = false;
    }
}
