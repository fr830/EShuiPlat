using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Core.Events
{
  public  interface IEvent1Param<T>
    where T : ESEventArgs
    {
        void Handle(T eventargs);
    }
}

