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

public partial class Administrator_EditIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {

        //Test to see if the textbox is empty
        if (IndexTextBox.Text == "")
        {
            IndexTextLabel.Visible = true;

            return;
        }

        else
        {   //Calls the Database class
            Database db = new Database();

            //Calls the method insertText in the database class
            db.insertText(IndexTextBox.Text);

            Response.Redirect("../Main/Index.aspx");
        }
    }
}
