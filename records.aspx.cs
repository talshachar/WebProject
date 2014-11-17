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
    public int currentPage; //עמוד נוכחי
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.currentPage = 0;
            Session["CurrentPage"] = 0;
            PopulateDataList();
        }
        else
        {
            this.currentPage = Convert.ToInt32(Session["CurrentPage"]);
        }
        int pageInd = this.currentPage + 1; //מספר העמוד
        this.LabelPageIndex.Text = pageInd.ToString();
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
            pager.CurrentPageIndex = this.currentPage;
            this.LinkButtonNextPage.Enabled = !pager.IsLastPage;
            this.LinkButtonPrevPage.Enabled = !pager.IsFirstPage;
            this.DataListRecords.DataSource = pager;
            this.DataListRecords.DataBind();
        }
    }
    protected void LinkButtonNextPage_Click(object sender, EventArgs e)
    {
        Session["CurrentPage"] = Convert.ToInt32(Session["CurrentPage"]) + 1;
        this.currentPage = Convert.ToInt32(Session["CurrentPage"]);
        PopulateDataList();
        int pageInd = this.currentPage + 1;
        this.LabelPageIndex.Text = pageInd.ToString();
    }
    protected void LinkButtonPrevPage_Click(object sender, EventArgs e)
    {
        Session["CurrentPage"] = Convert.ToInt32(Session["CurrentPage"]) - 1;
        this.currentPage = Convert.ToInt32(Session["CurrentPage"]);
        PopulateDataList();
        int pageInd = this.currentPage + 1;
        this.LabelPageIndex.Text = pageInd.ToString();
    }
    protected void DataListRecords_ItemCommand(object source, DataListCommandEventArgs e)
    {
        DataListItem dl = DataListRecords.Items[e.Item.ItemIndex];
        int RecordCode = Convert.ToInt32(DataListRecords.DataKeys[e.Item.ItemIndex]);
        string RecordName = ((Label)dl.FindControl("LabelRecordName")).Text;
        string ArtistName = ((Label)dl.FindControl("LabelArtistName")).Text;
        string ReleaseYear = ((Label)dl.FindControl("LabelReleaseYear")).Text;

    }
}