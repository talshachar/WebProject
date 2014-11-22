using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class manage_users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /* Permission check */
        if (!Page.IsPostBack)
        {
            PopulateGrid();
        }
    }

    public DataSet GetData()
    {
        DataService service = new DataService();
        return service.GetUsers();
    }

    public void PopulateGrid()
    {
        GridViewUsers.DataSource = GetData();
        GridViewUsers.DataBind();
    }

    protected void GridViewUsers_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewUsers.EditIndex = e.NewEditIndex;
        PopulateGrid();
    }
    protected void GridViewUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewUsers.EditIndex = -1;
        PopulateGrid();
    }
    protected void GridViewUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            User user = new User();
            DataService service = new DataService();
            string ID = GridViewUsers.Rows[e.RowIndex].Cells[0].Text;
            string FirstName = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
            string LastName = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
            string City = ((DropDownList)(GridViewUsers.Rows[e.RowIndex].Cells[3].FindControl("DropDownListCity"))).SelectedItem.Text;
            string Address = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
            string Email = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[5].Controls[0])).Text;
            string Password = ((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[6].Controls[0])).Text;
            int Permission = Convert.ToInt16(((TextBox)(GridViewUsers.Rows[e.RowIndex].Cells[7].Controls[0])).Text);

            user.ID = ID;
            user.LastName = LastName;
            user.FirstName = FirstName;
            user.Address = Address;
            user.City = City;
            user.Email = Email;
            user.Password = Password;
            user.Permission = Permission;
            service.UpdateUserDeatils(user);
            CheckBox Status = (CheckBox)(GridViewUsers.Rows[e.RowIndex].Cells[8].FindControl("CheckBoxStatus"));
            service.ChangeStatus(user.ID, Status.Checked);
            GridViewUsers.EditIndex = -1;
            PopulateGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataService service = new DataService();
        string ID = this.GridViewUsers.Rows[e.RowIndex].Cells[0].Text;
        service.DeleteUser(ID);
        this.GridViewUsers.EditIndex = -1;
        PopulateGrid();
    }
    protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer && e.Row.RowType != DataControlRowType.Pager)
        {
            if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Normal)))
            {
                DropDownList ddl = (DropDownList)e.Row.Cells[3].FindControl("DropDownListCity");
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/App_Data/CitiesXML.xml"));
                ddl.DataTextField = "Heb";
                ddl.DataSource = ds.Tables[0];
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("-- בחר עיר --", "0"));
                object currCity = DataBinder.Eval(e.Row.DataItem, "City");
                ddl.SelectedValue = currCity.ToString();
            }
        }
    }
}