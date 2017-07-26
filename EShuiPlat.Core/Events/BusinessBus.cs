using EShuiPlat.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Core.Events
{
  public   class BusinessBus<T>
    {
        public event Func<T, Results> BusinessFunc;
        public event Predicate<T> CheckEvent;
        public event Action<T> BusinessAction;
        public event Func<T, Results> BusinessCheck;
        public virtual Results On_BusinessCheckFirst(T obj)
        {
            Delegate[] dList = BusinessCheck.GetInvocationList();
            Results rs = new Results();
           foreach (Func<T, Results> item in dList)
           {
           
             rs = item(obj);
               
             if (rs.result > 0) break;
            }
            return rs;
        }
        public virtual Results On_BusinessCheck(T obj)
        {
            
            return BusinessCheck( obj);
        }
        public virtual List<Results> On_BusinessCheckLists(T obj)
        {
            Delegate[] dList = BusinessCheck.GetInvocationList();
            List<Results> lists = new  List<Results>();
            foreach (Func<T, Results> item in dList)
            {

               var rs = item(obj);

               lists.Add(rs);
            }
            return lists;
        }
        
        public virtual Results On_BusinessFunc(T obj)
        {

            return BusinessFunc(obj);
        }
        public virtual Results On_BusinessFuncFirst(T obj)
        {

            Delegate[] dList = BusinessFunc.GetInvocationList();
            Results rs = new Results();
            foreach (Func<T, Results> item in dList)
            {

                 rs = item(obj);

                if(rs.result>0)break;
            }
            return rs;
        }

        public virtual List<Results> On_BusinessFuncLists(T obj)
        {

            Delegate[] dList = BusinessFunc.GetInvocationList();
            List<Results> lists = new List<Results>();
            foreach (Func<T, Results> item in dList)
            {

                var rs = item(obj);

                lists.Add(rs);
            }
            return lists;
        }
        public virtual bool On_CheckEvent(T obj)
        {
            return CheckEvent(obj);
        }
        public virtual bool On_CheckEventFirst(T obj)
        {
            Delegate[] dList = CheckEvent.GetInvocationList();
            bool flags=false;
            foreach (Predicate<T> item in dList)
            {

                flags = item(obj);

                if (!flags)
                {
                   
                    break;
                }
            }
            return flags;
            
        }
        public virtual void On_BusinessAction(T obj)
        {
             BusinessAction(obj);
        }
    }
    public class BusinessBus<T,V>
    {
        public event Func<T,V, Results> BusinessFunc;
        public event Func<T,V,bool> CheckEvent;
        public event Action<T,V> BusinessAction;
        public event Func<T,V, Results> BusinessCheck;
        public virtual Results On_BusinessCheck(T obj,V args)
        {
            return BusinessCheck(obj, args);
        }
        public virtual Results On_BusinessCheckFirst(T obj, V args)
        {
            Delegate[] dList = BusinessCheck.GetInvocationList();
            Results rs = new Results();
            foreach (Func<T, V, Results> item in dList)
            {

                rs = item(obj,args);

                if (rs.result > 0) break;
            }
            return rs;
            
        }
        public virtual List<Results> On_BusinessCheckLists(T obj, V args)
        {
            Delegate[] dList = BusinessCheck.GetInvocationList();
            List<Results> lists = new List<Results>();
            foreach (Func<T, V, Results> item in dList)
            {

                var rs = item(obj,args);

                lists.Add(rs);
            }
            return lists;
        }
        public virtual Results On_BusinessFunc(T obj, V args)
        {
            return BusinessFunc(obj, args);
        }
        public virtual Results On_BusinessFuncFirst(T obj, V args)
        {
            Delegate[] dList = BusinessFunc.GetInvocationList();
            Results rs = new Results();
            foreach (Func<T, V, Results> item in dList)
            {

                rs = item(obj,args);

                if (rs.result > 0) break;
            }
            return rs; 
        }
        public virtual List<Results> On_BusinessFuncLists(T obj, V args)
        {
            Delegate[] dList = BusinessFunc.GetInvocationList();
            List<Results> lists = new List<Results>();
            foreach (Func<T, V, Results> item in dList)
            {

                var rs = item(obj,args);

                lists.Add(rs);
            }
            return lists;
            
        }
        public virtual bool On_CheckEvent(T obj, V args)
        {
            return CheckEvent(obj, args);
        }

        public virtual bool On_CheckEventFirst(T obj, V args)
        {
            Delegate[] dList = CheckEvent.GetInvocationList();
            bool flags = false;
            foreach (Func<T, V, bool> item in dList)
            {

                flags = item(obj,args);

                if (!flags)
                {

                    break;
                }
            }
            return flags;
           
        }
        public virtual void On_BusinessAction(T obj, V args)
        {
            BusinessAction(obj, args);
        }
    }
}
