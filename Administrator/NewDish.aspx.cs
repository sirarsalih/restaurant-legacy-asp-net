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

public partial class Administrator_NewDish : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void AddDish_Click(object sender, EventArgs e)
    {

        //Calls the Database class.
        Database db = new Database();

        //Calls the method called insertDishData from the database class.
        db.insertDishData(DishTextBox.Text, DishMenuListBox.SelectedValue, DishMenuInformationTextBox.Text, DishPriceTextBox.Text);

        Response.Redirect("../Main/Menu.aspx");
        
    
    
    }
}
