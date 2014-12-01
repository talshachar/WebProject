using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
    int orderID;
    DateTime orderDate;
    DateTime requiredDate;
    private ShoppingCart orderRecords;
    string mailingAddress;
    string creditCardID;
	public Order()
	{
		//OrderProductds.Products=new ArrayList();
	}
    public ShoppingCart OrderProductds
    {
        get { return this.orderRecords; }
        set { this.orderRecords = value; }
    }
    public int OrderID
    {
        get { return this.orderID; }
        set { this.orderID = value; }
    }
    public DateTime OrderDate
    {
        get { return this.orderDate; }
        set { this.orderDate = value; }
    }
    public DateTime RequiredDate
    {
        get { return this.requiredDate; }
        set { this.requiredDate = value; }
    }
    public string MailingAddress
    {
        get { return this.mailingAddress; }
        set { this.mailingAddress = value; }
    }
    public string CreditCardID
    {
        get { return this.creditCardID; }
        set { this.creditCardID = value; }
    }
}