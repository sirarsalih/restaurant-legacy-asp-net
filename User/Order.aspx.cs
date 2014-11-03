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

public partial class User_Order : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {        
        //Gets the price and name of the dish selected on the previous page
        Dish d = new Dish();
        DishOrderLabel.Text = d.DishOrderLabel;
        DishOrderPriceLabel.Text = d.DishOrderPriceLabel.ToString();
    }

    protected void Save_Click(object sender, EventArgs e)
    {        

        //Gets the user's unique UserID
        MembershipUser myObject = Membership.GetUser(User.Identity.Name);
        object UserID = myObject.ProviderUserKey;

        //Calls the database class
        Database db = new Database();
        
        //Get today's date and time
        string dateTime=DateTime.Now.ToString();

        //Get the date only
        string date = dateTime.Substring(6, 4)+"."+dateTime.Substring(3,3)+dateTime.Substring(0,2)+" ";

        string correctDateTime = date + OrderTimeTexbox.Text +":"+ OrderTimeTexbox2.Text+":00";
 
        int DishOrderPriceLabelInt = Convert.ToInt32(DishOrderPriceLabel.Text);

        int dishID = db.selectDishOrderID(DishOrderLabel.Text);

        //Increment session counter
        Session["Counter"] = (int)Session["Counter"] + 1;

        //The data for one order
        Session["sessionRowData" + Session["Counter"].ToString()] = DishOrderLabel.Text.ToString() + "_" + DishAmountLabel.Text.ToString() + "_" + DishOrderPriceLabel.Text.ToString() + "_" + correctDateTime.ToString() + "_" + UserID.ToString() + "_" + dishID.ToString();

        Response.Redirect("../Main/Menu.aspx");

    }
    

    //---------------------------------------------------------------------
    //These buttons are used to increment/decrement the number of orders. Max is set to 10.
    //---------------------------------------------------------------------
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        int number = Convert.ToInt32(DishAmountLabel.Text);

        if (number == 1)
        {
            return;
        }

        else
        {
            number = number - 1;

            DishAmountLabel.Text = number.ToString();
        }

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        int number = Convert.ToInt32(DishAmountLabel.Text);

        if(number == 10)
        {
            return;
        }

        number = number + 1;

        DishAmountLabel.Text = number.ToString();
    }
   
}
