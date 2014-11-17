using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class signin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataService ds = new DataService();
        if (ds.Auth(Request.Form["ID"], Request.Form["Password"]))
        {
            Session["UserID"] = Request.Form["ID"];
            User user = ds.GetUserDetails(Request.Form["ID"]);
            Session["Permission"] = user.Permission;
            Session["FullName"] = user.FirstName + " " + user.LastName;
            Response.Redirect("home.aspx");
        }
        else
        {
            Session["LoginError"] = 1;
            Response.Redirect("home.aspx");
        }
    }
}