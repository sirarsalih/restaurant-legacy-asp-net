using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Dish
/// </summary>

//This class is for dish property

public class Dish
{
    private int dishID;
    private string dishMenu;
    private string dishName;
    private string dishInformation;
    private int dishPrice;
    
    private static string dishOrderLabel;
    private static int dishOrderPriceLabel;

    public Dish()
    {
    
    }

    public int DishID
    {
        get
        {
            return dishID;
        }

        set
        {
            dishID = value;
        }
    }

    public string DishMenu
    {
        get
        {
            return dishMenu;
        }
        
        set
        {
            dishMenu = value;
        }
    }

    public string DishName
    {
        get
        {
            return dishName;
        }
        set
        {
           dishName = value;
        }
    }

    public string DishInformation
    {
        get
        {
            return dishInformation;
        }
        set
        {
            dishInformation = value;
        }
    }

    public int DishPrice
    {
        get
        {
            return dishPrice;
        }
        set
        {
            dishPrice = value;
        }
    }

    public string DishOrderLabel
    {

        get
        {
            return dishOrderLabel;
        }

        set
        {
            dishOrderLabel = value;
        }
    }

    public int DishOrderPriceLabel
    {
        get
        {
            return dishOrderPriceLabel;
        }
        set
        {
            dishOrderPriceLabel = value;
        }
    }
}
