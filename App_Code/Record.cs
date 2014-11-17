using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Record
/// </summary>
public class Record
{
    protected int recordCode;
    protected string recordName;

    public Record()
    {
        this.recordCode = -1;
        this.recordName = null;
    }

    public Record(Record r)
    {
        this.recordCode = r.recordCode;
        this.recordName = r.recordName;
    }
    public Record(int RecordID, string RecordName)
    {
        this.recordCode = RecordCode;
        this.recordName = RecordName;
    }
    public Record(int RecordID)
    {
        this.recordCode = RecordCode;
    }
    public int RecordCode
    {
        get { return recordCode; }
        set { recordCode = value; }
    }
    public string RecordName
    {
        get { return recordName; }
        set { recordName = value; }
    }
}