using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class shopping_cart : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            PopulateGridView();
        }
    }
    void PopulateGridView()
    {
        // מילוי סל הקניות במוצרים שהוספו אליו
        GridViewShoppingCart.DataSource = Cart.Records;
        GridViewShoppingCart.DataBind();
    }
}