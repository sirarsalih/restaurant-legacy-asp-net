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
using System.Net.Mail;



public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        
    }

    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        //Enabling extra data insertion into database
        TextBox UserNameTextBox = (TextBox)CreateUserWizardStep.ContentTemplateContainer.FindControl("UserName");
        SqlDataSource DataSource =(SqlDataSource)CreateUserWizardStep.ContentTemplateContainer.FindControl("InsertExtraInfo");

        //Gets the uniqe userID
        MembershipUser User = Membership.GetUser(UserNameTextBox.Text);
        object UserGUID = User.ProviderUserKey;

        DataSource.InsertParameters.Add("UserId", UserGUID.ToString());
        DataSource.Insert();

        //Registered users get User role
        Roles.AddUserToRole(CreateUserWizard1.UserName, "User");


    }



    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}
