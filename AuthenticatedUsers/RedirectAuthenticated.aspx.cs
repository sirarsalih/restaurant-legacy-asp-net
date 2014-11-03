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

public partial class AuthenticatedUsers_RedirectAuthenticated : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //-------------------------------------------------------------
        // A middle page that will redirect users to their main pages
        // depending on their role.
        //-------------------------------------------------------------
        if (User.IsInRole("Administrator"))
        {
            Response.Redirect("../Administrator/AdministratorPanel.aspx");
        }

        else if (User.IsInRole("Super Moderator"))
        {
            Response.Redirect("../SuperModerator/ActiveWatch.aspx");
        }

        else if (User.IsInRole("User"))
        {
            Response.Redirect("../User/MyPage.aspx");
        }
    }
}
