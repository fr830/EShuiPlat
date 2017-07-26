using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Core.Interfaces
{
    public interface IBase
    {
        string KeyID { get; }
        long ID { get; set; }
        long ChangeCount { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        long VersionNumber { get; set; }
        string Status { get; set; }
        string ToSQL(string SQLstrReg = null);
        string ToXML();
        string ToXML(string XmlStrReg = null);
    }
}
