using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected ShoppingCart Cart;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Cart"] == null)
        {
            Cart = new ShoppingCart();
        }
        else
        {
            Cart = (ShoppingCart)Session["Cart"];
        }
    }
    protected void ButtonSignIn_Click(object sender, EventArgs e)
    {
        DataService ds = new DataService();
        if (ds.Auth(this.TextBoxID.Text, this.TextBoxPassword.Text))
        {
            Session["UserID"] = this.TextBoxID.Text;
            User user = ds.GetUserDetails(this.TextBoxID.Text);
            Session["Permission"] = user.Permission;
            Session["FullName"] = user.FirstName + " " + user.LastName;
        }
        else
        {
            this.LabelError.Text = "מס' תעודת זהות או סיסמה אינם נכונים";
            this.LabelError.Visible = true;
        }
    }
}
