using EShuiPlat.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Core
{
  public  class SysBase:IBase
    {
        public SysBase()
        {
            KeyID =Guid.NewGuid().ToString();
        }
        public long ID { get; set; }
        public long ChangeCount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public long VersionNumber { get; set; }
        public string Status { get; set; }

        public string KeyID { get;}

        public virtual string ToSQL(string SQLstrReg = null)
        {

            if (SQLstrReg == null) return null;
            return SQLstrReg.ReplaceTemplateRuleByDic(this.GetPropertieInfo());
        }

        public virtual string ToXML()
        {
            return this.GetPropertieInfo().ToXml();
        }

        public virtual string ToXML(string XmlStrReg = null)
        {
            return this.GetPropertieInfo().ToXml(XmlStrReg);
        }
    
}
}
