﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RecordInCart
/// </summary>
public class RecordInCart : Record
{
	 protected decimal price;
    protected System.Int16 quantity;

	public RecordInCart()
	{
        price = -1;
        quantity = 0;
	}

    public RecordInCart(RecordInCart r)
        : base(r)
    {
        this.price = r.Price;
        this.quantity = r.Quantity;
    }
    public RecordInCart(int RecordCode, string RecordName, decimal Price, short Quantity)
        : base(RecordCode, RecordName)
    {
        quantity = Quantity;
        price = Price;
    }

    public RecordInCart(int RecordCode)
        : base(RecordCode)
    {

    }

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

    public System.Int16 Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
}