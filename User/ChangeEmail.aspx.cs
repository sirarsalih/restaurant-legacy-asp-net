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
using System.Data.SqlClient;

public partial class User_ChangeEmail : System.Web.UI.Page
{
    //Calls up the database class so that we can access the methods there.
    Database db = new Database();

    protected void Page_Load(object sender, EventArgs e)
    {
        //So that we can access the textbox and labels in the login-view.
        TextBox EmailTextBox = (TextBox)LoginView6.FindControl("EmailBox");
        Label EmailLabel = (Label)LoginView6.FindControl("Hidden_Email");
        EmailLabel.Visible = false;

        //Gets the current user's uniqe UserID
        string UserID = Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString();

        //Puts the data from the TextBox into the hidden label so that we can use it later.
        EmailLabel.Text = EmailTextBox.Text;
        
        //Updates the textbox with the user's current Email-Adress
        EmailTextBox.Text = db.selectEmail(UserID);
    }
    protected void Submit_Click(object sender, EventArgs e)
    {

        //So that we can access the hidden label.
        Label EmailLabel = (Label)LoginView6.FindControl("Hidden_Email");


        //Calls the method called changeEmail in the database class.
        db.updateEmail(EmailLabel.Text, Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString());

        Response.Redirect("MyPage.aspx");
    }
}
