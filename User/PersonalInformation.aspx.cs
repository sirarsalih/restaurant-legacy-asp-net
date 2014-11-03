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

public partial class Main_Account : System.Web.UI.Page
{

    Database db = new Database();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //So that we can access the textbox and labels in the login-view
        TextBox AddressTextBox = (TextBox)LoginView2.FindControl("AddressTextBox");
        TextBox ZipCodeTextBox = (TextBox)LoginView2.FindControl("ZipCodeTextBox");
        TextBox CityTextBox = (TextBox)LoginView2.FindControl("CityTextBox");
        Label AddressLabel = (Label)LoginView2.FindControl("Hidden_Address");
        Label ZipCodeLabel = (Label)LoginView2.FindControl("Hidden_ZipCode");
        Label CityLabel = (Label)LoginView2.FindControl("Hidden_City");
        
        AddressLabel.Visible = false;
        ZipCodeLabel.Visible = false;
        CityLabel.Visible = false;

        //The user's unique UserID
        string UserID = Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString();

        //Inserts the data from the textbox into the hidden labels for later use
        AddressLabel.Text = AddressTextBox.Text;
        ZipCodeLabel.Text = ZipCodeTextBox.Text;
        CityLabel.Text = CityTextBox.Text;

        //The user's current Adress, ZipCode and City is placed in the textbox
        AddressTextBox.Text = db.selectAddress(UserID);
        ZipCodeTextBox.Text = db.selectZipCode(UserID).ToString();
        CityTextBox.Text = db.selectCity(UserID);
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        //So that we can access the hidden labels
        //Needed to change the User data
        Label AddressLabel = (Label)LoginView2.FindControl("Hidden_Address");
        Label ZipCodeLabel = (Label)LoginView2.FindControl("Hidden_ZipCode");
        Label CityLabel = (Label)LoginView2.FindControl("Hidden_City");
        

        //Calles up the needed methods from the database class.
        db.updateAddress(AddressLabel.Text, Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString());
        db.updateZipCode(ZipCodeLabel.Text, Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString());
        db.updateCity(CityLabel.Text, Membership.GetUser(User.Identity.Name).ProviderUserKey.ToString());
        
        Response.Redirect("MyPage.aspx");

    }
}
