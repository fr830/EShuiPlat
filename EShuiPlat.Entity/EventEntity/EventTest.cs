using EShuiPlat.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Entity.EventEntity
{
 public   class EventTest: ESEventArgs
    {
        public Order order { get; set; }
    }
}
