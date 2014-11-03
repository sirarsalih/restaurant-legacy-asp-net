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

public partial class Administrator_DeleteDishes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DeleteDish_Click(object sender, EventArgs e)
    {
        //Calls the database class
        Database db = new Database();

        //Calls the method deleteDishData from the class database
        db.deleteDishData(DishesListBox.SelectedValue);
        Response.Redirect("DeleteDishes.aspx");
    }
}
