using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.DBHelper.Interfaces
{
    public interface IAggregateRoot
    {
        string KeyID { get; }
        long ID { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        long VersionNumber { get; set; }
        string Status { get; set; }
        string ToSQL(string SQLstrReg = null);
        string ToXML();
        string ToXML(string XmlStrReg = null);
    }
}
