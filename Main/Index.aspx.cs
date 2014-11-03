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

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Add new <div class = mainDynamic> in html
        System.Web.UI.HtmlControls.HtmlGenericControl divDynamicTag = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
        divDynamicTag.TagName = "div class=\"mainDynamic\"";

        //Add needed html tag in html
        System.Web.UI.HtmlControls.HtmlGenericControl htmlTag = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
        htmlTag.TagName = "p";

        //Calls the Database class.
        Database db = new Database();

        //Calls the method selectText in the database class and puts it in the htmltag
        htmlTag.InnerText = db.selectText();

        divDynamicTag.Controls.Add(htmlTag);

        TextPanel.Controls.Add(divDynamicTag);

    }
}
