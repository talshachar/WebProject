using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            Response.Redirect("home.aspx");
        }
       if(!Page.IsPostBack)
           FillDDLCities();
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

    public bool ValidateID(string id)
    {
        // ID Validation
        int ID = int.Parse(id);
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            int digit = ID % 10; ;
            if (i % 2 == 0)
            {
                sum += digit;
            }
            else
            {
                if (digit * 2 > 9)
                {
                    sum += digit * 2 % 10 + digit * 2 / 10;
                }
                else
                {
                    sum += digit * 2;
                }
            }
            ID = ID / 10;
        }
        if (sum % 10 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void CustomValidatorID_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = ValidateID(args.Value);
    }
    protected void ButtonSignUp_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            DataService ds = new DataService();
            if (ds.IsExist(this.TextBoxID.Text) == false)
            {
                User user = new User(this.TextBoxID.Text, this.TextBoxEmail.Text, this.TextBoxFirstName.Text, this.TextBoxLastName.Text, this.DropDownListCity.Text, this.TextBoxAddress.Text, this.TextBoxPassword.Text, 1);
                ds.InsertUser(user);
                Session["UserID"] = this.TextBoxID.Text;
                Session["Permisssion"] = 1;
                Session["FullName"] = user.FirstName + " " + user.LastName;
                Response.Redirect("home.aspx");
            }
        }
    }
}