using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class records : System.Web.UI.Page
{
    PagedDataSource pager; //לדאטא ליסא אין פייג'ינג לכן נשתמש באובייקט זה
    public int CurrentPage; //עמוד נוכחי
    DataSet ds;
    protected ShoppingCart Cart;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.CurrentPage = 0;
            Session["CurrentPage"] = 0;
            PopulateDataList();
        }
        else
        {
            this.CurrentPage = Convert.ToInt32(Session["CurrentPage"]);
        }
        int pageInd = this.CurrentPage + 1; //מספר העמוד
        this.LabelPageIndex.Text = pageInd.ToString();


        if (Session["Cart"] == null)
        {
            Cart = new ShoppingCart();
        }
        else
        {
            Cart = (ShoppingCart)Session["Cart"];
        }
    }
    public void PopulateDataList()
    {
        //מאכלסת את הדאטא ליסט בנתונים מהמסד נתונים

        pager = new PagedDataSource();
        DataService service = new DataService();
        ds = service.GetRecords();
        if (ds != null)
        {
            pager.AllowPaging = true;
            pager.DataSource = ds.Tables[0].DefaultView;
            //מחזיר דאטאויו הנוצר מהטבלה

            pager.PageSize = 8;
            pager.CurrentPageIndex = this.CurrentPage;
            this.ButtonNextPage.Visible = !pager.IsLastPage;
            this.ButtonPrevPage.Visible = !pager.IsFirstPage;
            this.DataListRecords.DataSource = pager;
            this.DataListRecords.DataBind();
        }
    }
    protected void ButtonNextPage_Click(object sender, EventArgs e)
    {
        Session["CurrentPage"] = Convert.ToInt32(Session["CurrentPage"]) + 1;
        this.CurrentPage = Convert.ToInt32(Session["CurrentPage"]);
        PopulateDataList();
        int pageInd = this.CurrentPage + 1;
        this.LabelPageIndex.Text = pageInd.ToString();
    }
    protected void ButtonPrevPage_Click(object sender, EventArgs e)
    {
        Session["CurrentPage"] = Convert.ToInt32(Session["CurrentPage"]) - 1;
        this.CurrentPage = Convert.ToInt32(Session["CurrentPage"]);
        PopulateDataList();
        int pageInd = this.CurrentPage + 1;
        this.LabelPageIndex.Text = pageInd.ToString();
    }
    protected void DataListRecords_ItemCommand(object source, DataListCommandEventArgs e)
    {
        DataListItem dl = DataListRecords.Items[e.Item.ItemIndex];
        string RecordCode = ((Label)dl.FindControl("LabelRecordCode")).Text; ;
        string RecordName = ((Label)dl.FindControl("LabelRecordName")).Text;
        string Price = (((Label)dl.FindControl("LabelRecordPrice")).Text).Substring(2);
        //string ArtistName = ((Label)dl.FindControl("LabelArtistName")).Text;
        //string ReleaseYear = ((Label)dl.FindControl("LabelReleaseYear")).Text;
        RecordInCart NewRecord = new RecordInCart(int.Parse(RecordCode), RecordName, decimal.Parse(Price), 1);
        Cart.AddRecord(NewRecord);
        Page.Session["Cart"] = Cart;
        Response.Redirect("shopping-cart.aspx");
    }
}