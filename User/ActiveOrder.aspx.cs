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

public partial class User_ActiveOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //------------------------------------------------------------------
        // This code puts the viewing users uniqe UserID in a hidden label,
        // so that we can acces it in the griview and use it in our select
        // statement
        //------------------------------------------------------------------
        MembershipUser myObject = Membership.GetUser(User.Identity.Name);
        object UserID = myObject.ProviderUserKey;
        Middleman.Text = UserID.ToString();

        // a label containing contact information.
        ContactLabel.Visible = true;
    }

    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        //This is what updates the gridview every 10 seconds.
        GridView1.DataBind();

        // Test to see if the gridview is empty.
        if (GridView1.Rows.Count == 0)
        {
            NoActiveOrderLabel.Visible = true;
        }

        else
        {

            NoActiveOrderLabel.Visible = false;        
        }

    }
}
