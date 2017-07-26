using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Core.Events
{
 public   class EventParams
    {
        public EventParams()
        {
            EventParamsID = Guid.NewGuid().ToString();
        }
        public string EventParamsID { get; }
        /// <summary>
        /// 事件发生的时间
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// 事件源
        /// </summary>
        public object EventSource { get; set; }
    }
}
