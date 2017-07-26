using EShuiPlat.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Core.Base
{
  public  class Results: IBase
    {
        public Results()
        {
            KeyID = Guid.NewGuid().ToString();
        }
        public long ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public long VersionNumber { get; set; }
        public string Status { get; set; }

        public string Messages { get; set; }

        public int result { get;set; }
        public string KeyID { get; }
        public long ChangeCount { get;set; }

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
