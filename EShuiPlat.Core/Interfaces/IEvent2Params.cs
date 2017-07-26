using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Core.Events
{
  public  interface IEvent2Params<T,V> where T: ESEventArgs where V:EventParams
    {
        void Handle(T eventargs,V eventparams);
    }
}
