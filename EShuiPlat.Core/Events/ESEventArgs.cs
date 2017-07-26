using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Core.Events
{
   public class ESEventArgs
    {

        public ESEventArgs()
        {
            ArgsID =Guid.NewGuid().ToString();
        }
        public string ArgsID { get; }
        /// <summary>
        /// 事件发生的时间
        /// </summary>
        public DateTime EventTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>

        public string Version { get; set; }

        /// <summary>
        /// 事件源
        /// </summary>
        public object EventSource { get; set; }

    }
}
