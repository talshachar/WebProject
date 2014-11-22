using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ShoppingCart
/// </summary>
public class ShoppingCart
{
    ArrayList records;
    public int counter;

    public ShoppingCart()
    {
        records = new ArrayList();
    }
    public ArrayList Records
    {
        get { return records; }
    }
    public int Length
    {
        get { return records.Count; }
    }
  
    public double GetFinalPrice()
    {
        // מחזיר מחיר של כל המוצרים בסל
        double total = 0.0;
        for (int i = 0; i < records.Count; i++)
        {

            total += ((double)(((RecordInCart)records[i]).Price) * (double)(((RecordInCart)records[i]).Quantity));
        }
        return total;
    }

    private int SearchRecord(int RecordCode)
    {
        for (int i = 0; i < records.Count; i++)
        {
            if (((Record)records[i]).RecordCode == RecordCode) return i;
        }
        return -1;
    }

    // Adds a Record to the records list.
    // returns the result of the inserting action (true - everything was alright).
    public void AddRecord(Record Record)
    {
        // מוסיף מוצר לסל, אם קיים כבר בסל מעלה את הכמות ב 1  
        int index = SearchRecord(Record.RecordCode);
        if (index == -1)
        {
            this.records.Add(Record);
        }
        else
        {
            ((RecordInCart)records[index]).Quantity++;
        }
        counter++;
    }

    public void DeleteRecord(Record Record)
    {
        // מבטל מוצר מהסל
        int index = SearchRecord(Record.RecordCode);
        this.records.RemoveAt(index);
    }

    public void UpdateRecord(RecordInCart Record)
    {
        // מעדכן כמות של מוצר בסל
        int index = SearchRecord(Record.RecordCode);
        ((RecordInCart)records[index]).Quantity = Record.Quantity;
    }

    public DataSet ConvertToViewDataTable()
    {
        DataTable dtShoppingCart = new DataTable();
        DataColumn[] dtColumns = new DataColumn[] { new DataColumn("RecordCode"), new DataColumn("RecordName"), new DataColumn("Price"), new DataColumn("Quantity") };
        dtColumns[0].DataType = typeof(System.Int32);
        dtColumns[2].DataType = typeof(System.Double);
        dtColumns[3].DataType = typeof(System.Decimal);
        dtShoppingCart.Columns.AddRange(dtColumns);
        for (int i = 0; i < this.records.Count; i++)
        {
            DataRow currRow = dtShoppingCart.NewRow();
            currRow["ProdCode"] = ((RecordInCart)records[i]).RecordCode;
            currRow["ProdName"] = ((RecordInCart)records[i]).RecordName;
            currRow["Price"] = ((RecordInCart)records[i]).Price;
            currRow["Quantity"] = ((RecordInCart)records[i]).Quantity;
            dtShoppingCart.Rows.Add(currRow);
        }
        DataSet ds = new DataSet();
        ds.Tables.Add(dtShoppingCart);
        return ds;
    }
}