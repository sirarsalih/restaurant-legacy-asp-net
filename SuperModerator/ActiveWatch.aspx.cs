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

public partial class SuperModerator_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //Test to see if the order gridview is empty.
        //Sets a few hidden labels to visible if true.
        if (GridView1.Rows.Count == 0)
        {
            NotConfirmedLabel.Visible = false;

            NoIncomingOrdersLabel.Visible = true;
        }
            
        else
        {
            NoIncomingOrdersLabel.Visible = false;        
        }

        //Test to see if the table reservation gridview is empty.
        if (GridView2.Rows.Count == 0)
        {
            NoIncomingReservationsLabel.Visible = true;
        }

        else
        {
            NoIncomingReservationsLabel.Visible = false;
        }
    }

    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        // Important !!!
        // This updates the GridViews on ticks
        GridView1.DataBind();
        GridView2.DataBind();

        //--------------------------------------------------------
        // Goes through the orders gridview and tests if there
        // is any "Ikke bekreftet fields" and gives a warning
        // if there is
        //--------------------------------------------------------
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {            

            if (!GridView1.Rows[i].Cells[5].Text.Equals("Ikke bekreftet."))
            {
                NotConfirmedLabel.Visible = false;
            }

            else
            {
                NotConfirmedLabel.Visible = true;
            }
        
        }

    }
}