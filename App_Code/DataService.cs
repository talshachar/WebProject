using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for DataService
/// </summary>
public class DataService
{
    private OleDbConnection connection;
    public DataService()
    {
        this.connection = new OleDbConnection(Connect.getConnectionString());
    }

    public void InsertUser(User user)
    {
        // Inserts new user to the database
        OleDbCommand cmd = new OleDbCommand("InsertUser", connection);
        cmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam;

        objparam = cmd.Parameters.Add("@ID", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.ID;

        objparam = cmd.Parameters.Add("@Email", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.Email;

        objparam = cmd.Parameters.Add("@FirstName", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.FirstName;

        objparam = cmd.Parameters.Add("@LastName", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.LastName;

        objparam = cmd.Parameters.Add("@City", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.City;

        objparam = cmd.Parameters.Add("@Address", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.Address;

        objparam = cmd.Parameters.Add("@Password", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.Password;

        objparam = cmd.Parameters.Add("@Permission", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.Permission;

        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    public bool IsExist(string ID)
    {
        // Checks if the ID is already exists in the database
        try
        {
            connection.Open();
            string sql = "SELECT * FROM UsersTBL WHERE ID=" + "'" + ID + "'";
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            object user = cmd.ExecuteScalar();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }


    public bool Auth(string ID, string password)
    {
        // Checks if the details are correct
        try
        {
            connection.Open();
            string sql = "SELECT * FROM UsersTBL WHERE ID='" + ID + "' AND Password='" + password + "'";
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            object user = cmd.ExecuteScalar();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }


    public User GetUserDetails(string ID)
    {
        // Gets user details by ID
        OleDbCommand cmd = new OleDbCommand("GetUserDetails", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter objparam;
        objparam = cmd.Parameters.Add("@ID", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = ID;
        DataSet ds = new DataSet();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        User user = new User();
        try
        {
            connection.Open();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "UsersTBL");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        user.ID = ds.Tables["UsersTBL"].Rows[0]["ID"].ToString();
        user.Email = ds.Tables["UsersTBL"].Rows[0]["Email"].ToString();
        user.FirstName = ds.Tables["UsersTBL"].Rows[0]["FirstName"].ToString();
        user.LastName = ds.Tables["UsersTBL"].Rows[0]["LastName"].ToString();
        user.City = ds.Tables["UsersTBL"].Rows[0]["City"].ToString();
        user.Address = ds.Tables["UsersTBL"].Rows[0]["Address"].ToString();
        user.Password = ds.Tables["UsersTBL"].Rows[0]["Password"].ToString();
        user.Permission = Convert.ToInt16(ds.Tables["UsersTBL"].Rows[0]["Permission"].ToString());
        return user;
    }


    public void UpdateUserDeatils(User user)
    {
        OleDbCommand cmd = new OleDbCommand("UpdateUserDetails", connection);
        cmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam;

        objparam = cmd.Parameters.Add("@Email", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.Email;

        objparam = cmd.Parameters.Add("@FirstName", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.FirstName;

        objparam = cmd.Parameters.Add("@LastName", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.LastName;

        objparam = cmd.Parameters.Add("@City", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.City;

        objparam = cmd.Parameters.Add("@Address", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.Address;

        objparam = cmd.Parameters.Add("@Password", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.Password;

        objparam = cmd.Parameters.Add("@Permission", OleDbType.Integer);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.Permission;

        objparam = cmd.Parameters.Add("@ID", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = user.ID;

        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    public DataSet GetUsers()
    {
        OleDbCommand cmd = new OleDbCommand("SelectAllUsers", connection);
        try
        {
            connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            //יש לציין שאובייקט הקומנד מטפל בשגרה מאוחסנת            

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "UsersTBL");
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }

    public DataSet GetRecords()
    {
        OleDbCommand cmd = new OleDbCommand("SelectAllRecords", connection);
        try
        {
            connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            //יש לציין שאובייקט הקומנד מטפל בשגרה מאוחסנת            

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "RecordsTBL");
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }


    public void ChangeStatus(string ID, bool Status)
    {
        OleDbCommand cmd = new OleDbCommand("UpdateStatus", connection);
        cmd.CommandType = CommandType.StoredProcedure;

        OleDbParameter objparam;

        objparam = cmd.Parameters.Add("@Status", OleDbType.Boolean);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = Status;

        objparam = cmd.Parameters.Add("@ID", OleDbType.BSTR);
        objparam.Direction = ParameterDirection.Input;
        objparam.Value = ID;
        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }


    public void DeleteUser(string ID)
    {
        //מחיקת משתמש
        OleDbCommand cmd = new OleDbCommand("DeleteUser", connection);
        try
        {
            connection.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            //יש לציין שאובייקט הקומנד מטפל בשגרה מאוחסנת            

            OleDbParameter objparam;
            objparam = cmd.Parameters.Add("@ID", OleDbType.BSTR);
            objparam.Value = ID;

            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
    }
}