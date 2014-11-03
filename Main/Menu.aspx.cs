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

public partial class Meny : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {
        
        Database db = new Database();

        //Using the getData method from the database class
        ArrayList al = db.selectDishData();

        foreach(Dish d in al)
        {
            //Add new <div class = mainDynamic> in html
            System.Web.UI.HtmlControls.HtmlGenericControl divDynamicTag = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            divDynamicTag.TagName = "div class=\"mainDynamic\"";

            //Add all needed html tags in html
            System.Web.UI.HtmlControls.HtmlGenericControl htmlTag1 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            htmlTag1.TagName = "h2";            
            
            System.Web.UI.HtmlControls.HtmlGenericControl htmlTag2 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            htmlTag2.TagName = "h3";            

            System.Web.UI.HtmlControls.HtmlGenericControl htmlTag3 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            htmlTag3.TagName = "p";

            System.Web.UI.HtmlControls.HtmlGenericControl htmlTag4 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            htmlTag4.TagName = "span";

            System.Web.UI.HtmlControls.HtmlGenericControl htmlTag5 = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
            htmlTag5.TagName = "div class=\"buttondiv\""; ;

            //Dish information goes inside the html tags
            htmlTag1.InnerText = d.DishMenu;
            htmlTag2.InnerText = d.DishName;
            htmlTag3.InnerText = d.DishInformation;
            htmlTag4.InnerText = "Pris: "+d.DishPrice+",-";           
            
            
            //Add all html tags inside mainDynamic class
            divDynamicTag.Controls.Add(htmlTag1);
            divDynamicTag.Controls.Add(htmlTag2);
            divDynamicTag.Controls.Add(htmlTag3);
            divDynamicTag.Controls.Add(htmlTag4);
            

            //Dynamic order button
            Button orderButton = new Button();

           
            //Set order button ID = dish ID --> multiple generated buttons 
            orderButton.ID = d.DishID.ToString();
            orderButton.Text = "Bestill nå!";
            orderButton.Click += new System.EventHandler(Order_Clicked);

            htmlTag5.Controls.Add(orderButton);

            //Add mainDynamic class in panel
            MenuPanel.Controls.Add(divDynamicTag);
            MenuPanel.Controls.Add(htmlTag5);

        }       

    }

    protected void Order_Clicked(object sender, EventArgs e)
    {
        Button orderButton = (Button)sender;
        Database db = new Database();
        Dish d = new Dish();
        
        //Using button ID (which is the dish ID) to get dish
        d.DishOrderLabel = db.selectDishOrder(orderButton.ID);
        d.DishOrderPriceLabel = db.selectDishOrderPrice(orderButton.ID);
        
        Response.Redirect("../User/Order.aspx");

    }

}
