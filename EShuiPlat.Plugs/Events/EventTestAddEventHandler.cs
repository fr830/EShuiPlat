using EShuiPlat.Core.Events;
using EShuiPlat.Entity.EventEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Plugs.Events
{
    public class EventTestAddEventHandler : IEvent1Param<EventTest>
    {
        public void Handle(EventTest eventargs)
        {

           
            // eventargs.order.VersionNumber=10;
            
        }
    }
}
