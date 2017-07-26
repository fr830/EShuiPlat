using EShuiPlat.Core.Events;
using EShuiPlat.Entity.EventEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Plugs.Events
{
    public class EventTest1AddEventHandler : IEvent2Params<EventTest, EventTest1>
    {
        public void Handle(EventTest eventargs, EventTest1 eventparams)
        {
            
            eventparams.order.Price = eventparams.order.Price + eventargs.order.Price;
        }
    }
}
