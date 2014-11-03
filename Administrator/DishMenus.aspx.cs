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

public partial class Administrator_Dishes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void AddDishMenu_Click(object sender, EventArgs e)
    {
        //Test to see if the textbox is empty
        if (DishMenuTextBox.Text == "")
        {
            return;
        }
        
        Database db = new Database();

        //Calls the method insertDishData from the database class
        db.insertDishMenuData(DishMenuTextBox.Text);
        Response.Redirect("DishMenus.aspx");
    }
    
    protected void DeleteDishMenu_Click(object sender, EventArgs e)
    {
        //Calls the Database class
        Database db = new Database();

        //Calls the deleteDishMenuData from the database class.
        db.deleteDishMenuData(DishMenuListBox.SelectedValue);
        Response.Redirect("DishMenus.aspx");
    }
}
