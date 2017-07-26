using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Core.Events
{
 public   class BusinessLink<T>
    {
       public event Func<T, T> BusinessFunc;
        public event Action<T> BusinessAction;
        public virtual T On_BusinessFunc(T obj)
        {

            Delegate[] dList = BusinessFunc.GetInvocationList();
            T rs = obj;
            foreach (Func<T, T> item in dList)
            {
                rs = item(rs);
      
            }
            return rs;
        }
        public virtual void On_BusinessAction(T obj)
        {

            Delegate[] dList = BusinessFunc.GetInvocationList();
            
            foreach (Action<T> item in dList)
            {

                item(obj);

            }
            
        }
        public event Predicate<T> CheckEvent;
        public virtual bool On_CheckEvent(T obj)
        {
            Delegate[] dList = CheckEvent.GetInvocationList();
            var rs = obj;
            bool flags = false;
            foreach (Predicate<T> item in dList)
            {

                 flags = item(obj);
                if (!flags) break;
               
            }
            return flags;
        }
    }

    public class BusinessLink<T,V>
    {
        public event Func<T,V, T> BusinessFunc;
        public event Action<T,V> BusinessAction;
        public virtual void On_BusinessAction(T obj,V param)
        {

            Delegate[] dList = BusinessFunc.GetInvocationList();

            foreach (Action<T,V> item in dList)
            {

                item(obj,param);

            }

        }
        public virtual T On_BusinessFunc(T obj,V param)
        {

            Delegate[] dList = BusinessFunc.GetInvocationList();
            T rs = obj;
            foreach (Func<T,V, T> item in dList)
            {

                rs = item(rs,param);

            }
            return rs;
        }

    }
}
