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
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Database
/// </summary>

//This is the database class
public class Database
{
    ConnectionStringSettings settings = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"];
    string connectionString;
    SqlConnection cn;

    public Database()
    {


    }

    //Select table seats
    public int selectTableSeats(int tableID)
    {
        int seats = 0;
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string sql = "SELECT Restaurant_Tables.Seats FROM Restaurant_Tables WHERE Restaurant_Tables.TableID = "+tableID;
        SqlCommand cmd = new SqlCommand(sql, cn);

        try
        {
            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                seats = Convert.ToInt32(sqlReader["Seats"]);
            }

        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }

        return seats;
    }
    
    //Insert reservation order
    public int insertReserveOrder(string userID, int tableID, string timeFromID, string timeToID, string day)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        SqlCommand cmd;

        string sql = "INSERT INTO Reservation VALUES (@UserId, @TableID, @TimeFromID, @TimeToID, @Day)";

        try
        {
            cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@UserId", userID);
            cmd.Parameters.AddWithValue("@TableID", tableID);
            cmd.Parameters.AddWithValue("@TimeFromID", timeFromID);
            cmd.Parameters.AddWithValue("@TimeToID", timeToID);
            cmd.Parameters.AddWithValue("@Day", day);

            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    
    }

    //Select chosen day from calender for reservation
    public ArrayList selectReserveDay(int tableID, string day)
    {
        ArrayList al = new ArrayList();

        string timeFromID;
        string timeToID;



        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        
        string sql = "SELECT Reservation.TimeFromID, Reservation.TimeToID FROM Reservation WHERE Reservation.TableID = "+tableID+" AND Reservation.Day = '"+day + "'";

        SqlCommand cmd = new SqlCommand(sql, cn);

        try
        {
            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {

                timeFromID = sqlReader["TimeFromID"].ToString();
                timeToID = sqlReader["TimeToID"].ToString();

                al.Add(timeFromID);
                al.Add(timeToID);
            }
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return al;
    
    }

    //Insert text into index page table
    public int insertText(string indexText)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        SqlCommand cmd;

        string sql = "INSERT INTO IndexInformationPage VALUES (@IndexText)";

        try
        {
            cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@IndexText", indexText);

            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    
    }

    //Select text from index page table
    public string selectText()
    {
        string text="";
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string sql = "SELECT IndexInformationPage.IndexText FROM IndexInformationPage";
        SqlCommand cmd = new SqlCommand(sql, cn);

        try
        {
            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                text = sqlReader["IndexText"].ToString();                
            }

        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }

        return text;
    }

    //Update ActiveWatch GridView
    public int updateOrder(string userID, int dishID, string timeID, string status)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "UPDATE Orders SET Status = '" + status + "' WHERE Orders.UserId= '" + userID + "'" + " AND Orders.DishID =" + dishID + " AND Orders.TimeID = '" + timeID + "'";
        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    
    }

    //Delete from ActiveWatch GridView
    public int deleteOrder(string userID, int dishID, string timeID)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        SqlCommand cmd;

        string sql = "DELETE FROM Orders WHERE Orders.UserId = '" + userID + "' AND Orders.DishID = " + dishID + " AND Orders.TimeID = '" + timeID + "'"; 

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    }


    //Updates order status (order is payed for)
    public int updateOrderStatus(string userID, int dishID, string timeID, string payed)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "UPDATE Orders SET Payed = " + payed + " WHERE UserId ='" + userID + "'" + " AND DishID = "+dishID+" AND TimeID ='"+timeID+"'";

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Payed", payed);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    
    }


    //Insert new data into Dishes
    public int insertDishData(string Dish, string DishMenu, string DishInformation, string DishPrice)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        SqlCommand cmd;

        string sql = "INSERT INTO Dishes VALUES (@DishMenuID, @Dish, @DishInformation, @DishPrice)";

        try
        {
            cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@DishMenuID", DishMenu);
            cmd.Parameters.AddWithValue("@Dish", Dish);
            cmd.Parameters.AddWithValue("@DishInformation", DishInformation);
            cmd.Parameters.AddWithValue("@DishPrice", DishPrice);

            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();   
        }
        return 0;
    }

    //Delete the selected DishMenu
    public int deleteDishMenuData(string DishMenu)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        SqlCommand cmd;

        string sql = "DELETE FROM DishMenus WHERE DishMenuID =" + DishMenu;

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    }

    //Delete the selected Dish
    public int deleteDishData(string Dish)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        SqlCommand cmd;

        string sql = "DELETE FROM Dishes WHERE DishID =" + Dish;

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;

    }
        
    //Insert new DishMenu data
    public int insertDishMenuData(string DishMenu)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }

        SqlCommand cmd;

        string sql = "INSERT INTO DishMenus VALUES (@DishMenu)";

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@DishMenu", DishMenu);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    }

    //Select Dish data 
    public ArrayList selectDishData()
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string sql = "SELECT Dishes.DishID, DishMenus.DishMenu, Dishes.Dish, Dishes.DishInformation, Dishes.DishPrice FROM DishMenus, Dishes WHERE Dishes.DishMenuID = DishMenus.DishMenuID";
        SqlCommand cmd = new SqlCommand(sql, cn);
        ArrayList al = new ArrayList();

        try
        {
           SqlDataReader sqlReader = cmd.ExecuteReader();

           while (sqlReader.Read())
           {
               Dish d = new Dish();

               d.DishID = (int)sqlReader["DishID"];
               d.DishMenu = (string)sqlReader["DishMenu"];
               d.DishName = (string)sqlReader["Dish"];
               d.DishInformation = (string)sqlReader["DishInformation"];
               d.DishPrice = (int)sqlReader["DishPrice"];

               al.Add(d);
           }

        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }

        return al;
    }

    //Select DishID 
    public int selectDishOrderID(string dish)
    {
        int dishID = 0;
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string sql = "SELECT Dishes.DishID FROM Dishes WHERE Dishes.Dish = '" + dish+"'";
        SqlCommand cmd = new SqlCommand(sql, cn);

        try
        {
            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                dishID = (int)sqlReader["DishID"];
            }
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return dishID;
    }

    //Select Dish
    public string selectDishOrder(string OrderButtonID)
    {
        string dish = "";
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string sql = "SELECT Dishes.Dish FROM Dishes WHERE Dishes.DishID =" + OrderButtonID;
        SqlCommand cmd = new SqlCommand(sql, cn);

        try
        {
            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                dish = (string)sqlReader["Dish"];
            }

        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return dish;
    }

    //Select DishPrice
    public int selectDishOrderPrice(string OrderButtonID)
    {
        int dishPrice = 0;
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        string sql = "SELECT Dishes.DishPrice FROM Dishes WHERE Dishes.DishID =" + OrderButtonID;
        SqlCommand cmd = new SqlCommand(sql, cn);

        try
        {
            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                dishPrice = (int)sqlReader["DishPrice"];
            }

        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return dishPrice;
    }

    //Insert all data into Orders table
    public int insertOrder(string userID, string timeID, int dishID, string antall, string status, string payed)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "INSERT INTO Orders VALUES (@UserId, @TimeID, @DishID, @Antall, @Status, @Payed)";
                      

        try
        {
            cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@UserId", userID);
            cmd.Parameters.AddWithValue("@TimeID", timeID);
            cmd.Parameters.AddWithValue("@DishID", dishID);
            cmd.Parameters.AddWithValue("@Antall", antall);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Payed", payed);
            
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    
    }

    //Select Address
    public string selectAddress(string UserID)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);
        string CurrentAddress = "";

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "SELECT UserAddress.Address FROM UserAddress WHERE UserAddress.UserId = '" + UserID + "'";

        try
        {
            cmd = new SqlCommand(sql, cn);
            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                CurrentAddress = sqlReader["Address"].ToString();
            }
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return CurrentAddress;
    }

    //Select City
    public string selectCity(string UserID)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);
        string CurrentCity = "";

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "SELECT UserAddress.City FROM UserAddress WHERE UserAddress.UserId = '" + UserID + "'";

        try
        {
            cmd = new SqlCommand(sql, cn);
            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                CurrentCity = sqlReader["City"].ToString();
            }
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return CurrentCity;
    }

    //Select ZipCode
    public int selectZipCode(string UserID)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);
        int CurrentZipCode = 0;

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "SELECT UserAddress.ZipCode FROM UserAddress WHERE UserAddress.UserId = '" + UserID + "'";

        try
        {
            cmd = new SqlCommand(sql, cn);
            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                CurrentZipCode = (int)sqlReader["ZipCode"];
            }
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return CurrentZipCode;
    }

    //Select Email
    public string selectEmail(string UserID)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);
        string currentEmail = "";

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "SELECT aspnet_Membership.Email FROM aspnet_Membership WHERE aspnet_Membership.UserId = '" + UserID + "'";

        try
        {
            cmd = new SqlCommand(sql, cn);
            SqlDataReader sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                currentEmail = sqlReader["Email"].ToString();
            }
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return currentEmail;
    }

    //Update Address
    public int updateAddress(string userdata, string userID)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "UPDATE UserAddress SET UserAddress.Address = '"+userdata+"' WHERE UserAddress.UserId ='"+userID+"'";

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Address", userdata);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    }

    //Update City
    public int updateCity(string userdata, string userID)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "UPDATE UserAddress SET UserAddress.City = '"+userdata+"' WHERE UserAddress.UserId ='"+userID+"'";

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@City", userdata);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    }

    //Update ZipCode
    public int updateZipCode(string userdata, string userID)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "UPDATE UserAddress SET UserAddress.ZipCode = '"+userdata+"' WHERE UserAddress.UserId ='"+userID+"'";

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@ZipCode", userdata);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    }

    //Update Email
    public int updateEmail(string userdata, string userID)
    {
        connectionString = settings.ConnectionString;
        cn = new SqlConnection(connectionString);

        if (cn.State == ConnectionState.Closed)
        {
            cn.Open();
        }
        SqlCommand cmd;
        string sql = "UPDATE aspnet_Membership SET aspnet_Membership.Email = '" + userdata + "' WHERE aspnet_Membership.UserId ='" + userID + "'";

        try
        {
            cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Email", userdata);
            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlexception)
        {
            Console.WriteLine(sqlexception);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            cn.Close();
        }
        return 0;
    }

 
}
