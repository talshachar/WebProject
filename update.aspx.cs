using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class update : System.Web.UI.Page
{
    DataService ds = new DataService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {

            Response.Redirect("signin.aspx");
        }
        if (!Page.IsPostBack)
        {
            FillDDLCities();
            this.TextBoxID.Text = ds.GetUserDetails(Session["UserID"].ToString()).ID;
            this.TextBoxFirstName.Text = ds.GetUserDetails(Session["UserID"].ToString()).FirstName;
            this.TextBoxLastName.Text = ds.GetUserDetails(Session["UserID"].ToString()).LastName;
            this.TextBoxAddress.Text = ds.GetUserDetails(Session["UserID"].ToString()).Address;
            this.TextBoxEmail.Text = ds.GetUserDetails(Session["UserID"].ToString()).Email;
            this.DropDownListCity.Text = ds.GetUserDetails(Session["UserID"].ToString()).City;
        }
    }

    private void FillDDLCities()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("~/App_Data/CitiesXML.xml"));
        this.DropDownListCity.DataTextField = "Heb";
        this.DropDownListCity.DataSource = ds.Tables[0];
        this.DropDownListCity.DataBind();
        this.DropDownListCity.Items.Insert(0, new ListItem("-- בחר עיר --", "0"));
    }

    protected void ButtonUpdateDetails_Click(object sender, EventArgs e)
    {
        if (ds.Auth(Session["UserID"].ToString(), this.TextBoxPasswordDetails.Text))
        {
            User user = new User(Session["UserID"].ToString(), this.TextBoxEmail.Text, this.TextBoxFirstName.Text, this.TextBoxLastName.Text, this.DropDownListCity.SelectedItem.Text, this.TextBoxAddress.Text, this.TextBoxPasswordDetails.Text, Convert.ToInt16(Session["Permission"]));
            ds.UpdateUserDeatils(user);
            this.LabelErrorDetails.Text = "העדכון בוצע בהצלחה";
            this.LabelErrorDetails.Visible = true;
        }
        else
        {
            this.LabelErrorDetails.Text = "הכנס את הסיסמה הנוכחית על מנת לעדכן את הפרטים";
            this.LabelErrorDetails.Visible = true;
        }
    }
    protected void ButtonUpdatePassword_Click(object sender, EventArgs e)
    {
        if (ds.Auth(Session["UserID"].ToString(), this.TextBoxPasswordPassword.Text))
        {

            User user = new User(Session["UserID"].ToString(), ds.GetUserDetails(Session["UserID"].ToString()).Email, ds.GetUserDetails(Session["UserID"].ToString()).FirstName, ds.GetUserDetails(Session["UserID"].ToString()).LastName, ds.GetUserDetails(Session["UserID"].ToString()).City, ds.GetUserDetails(Session["UserID"].ToString()).Address, this.TextBoxNewPassword.Text, Convert.ToInt16(Session["Permission"]));
            ds.UpdateUserDeatils(user);
            this.LabelErrorPassword.Text = "העדכון בוצע בהצלחה";
            this.LabelErrorPassword.Visible = true;
        }
    }
}