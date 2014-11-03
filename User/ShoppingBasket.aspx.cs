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

public partial class User_ShoppingBasket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Cast custom session-counter to an int for later use
        int k = (int)Session["Counter"];

        //Create a new data table
        DataTable dataTable = new DataTable();

        //Add columns to the data table
        dataTable.Columns.Add("Matrett");
        dataTable.Columns.Add("Antall");
        dataTable.Columns.Add("Pris");
        dataTable.Columns.Add("Tidspunkt");
        dataTable.Columns.Add("Sum");

        //Declaration of various variables that we'll need
        string temp1;
        string temp2;
        string temp3;
        string[] temp4;
        int totalSum = 0;
        int sum = 0;

        //-------------------------------------------------------------
        //The data from the session variables will be put 
        //in a temporarily string which will be up in an
        //array that will contain the different data. It will then put
        //that data in a data table and the prosess is repeted as many 
        //times as necessary to insert all the orders
        //-------------------------------------------------------------
        for (int i = 1; i <= k; i++)
        {
            sum = 0;

            temp3 = Session["sessionRowData" + i.ToString()].ToString(); 
            temp4 = temp3.Split('_');

            DataRow row = dataTable.NewRow();
            temp1 = temp4[1];
            temp2 = temp4[2];
            sum = (Convert.ToInt32(temp1) * Convert.ToInt32(temp2));
            totalSum = totalSum + sum;

            row["Matrett"] = temp4[0];
            row["Antall"] = temp4[1];
            row["Pris"] = temp4[2] + ",-";
            row["Tidspunkt"] = temp4[3];
            row["Sum"] = sum.ToString() + ",-";
            dataTable.Rows.Add(row);            
        }

        TotalSumLabel.Text = totalSum.ToString()+",-";

        //Adds the data table to a dataset, so that it can be added to a GridView
        DataSet dataSet = new DataSet();
        dataSet.Tables.Add(dataTable);
        
        //This is where the data from the data table is placed in the GridView
        GridView1.DataSource = dataSet;
        GridView1.DataBind();

        ShoppingBasketLabel.Visible = false;

        //-----------------------------------------------
        //A test to see if the GridView is empty.
        //If it is, it will then only view a label that
        //states the shoppingbasket is empty.
        //-----------------------------------------------
        if (GridView1.Rows.Count == 0)
        {
            ShoppingBasketLabel.Text = "Handlevognen din er tom.";

            ShoppingBasketLabel.Visible = true;
            TotalSumLabelText.Visible = false;
            TotalSumLabel.Visible = false;
            OrderButton.Visible = false;
        }
        

    }
    
    protected void OrderNow_Click(object sender, EventArgs e)
    {
        int k = (int)Session["Counter"];
        Database db = new Database();
        
        //------------------------------------------------------------
        //Runs through the for-chain, puts the session data in a string
        //and parses the string into an array that then contains the 
        //needed information to make the order.
        //------------------------------------------------------------
        for (int i = 1; i <= k; i++)
        {
            string temp3 = Session["sessionRowData" + i.ToString()].ToString(); 
            string[] temp4 = temp3.Split('_');
            
            //Calls up the insertOrder method in the Database class, this method inserts the order into the database
            db.insertOrder(temp4[4], temp4[3], Convert.ToInt32(temp4[5]), temp4[1], "Ikke bekreftet.", "Ikke Betalt");
        }
        
        //Clears all the session variables to prevent repeted orders
        Session.Clear();
        Session["Counter"] = 0;
        
        Response.Redirect("ActiveOrder.aspx");                                          
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int key = (int)Session["Counter"];
        int temp = e.RowIndex;
        temp = temp + 1;
        
        //Removes the selected order from the session data
        Session.Remove("sessionRowData" + temp.ToString());
        temp = temp + 1;


        //Fixes the session data accordingly to the GridView
        for (int temp2 = temp; temp2 <= key; temp2++)
        {
            Session["sessionRowData" + (temp2 - 1).ToString()] = Session["sessionRowData" + temp2.ToString()];
        }

        //Decrements the Session-Counter
        Session["Counter"] = (key - 1);

        Response.Redirect("ShoppingBasket.aspx");
    }
}
