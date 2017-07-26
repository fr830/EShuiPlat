using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EShuiPlat.Core.Events
{
  public  class EventBus
    {
        private   EventBus _eventBus = null;
        private   Dictionary<Type, List<Type>> _eventMapping = new Dictionary<Type, List<Type>>();  // 在这个字典中，key存储的是事件，而value中存储的是事件处理程序
        private   Dictionary<Type, List<Type>> _event2Mapping = new Dictionary<Type, List<Type>>();  // 在这个字典中，key存储的是事件，而value中存储的是事件处理程序



        public EventBus() {
            _eventMapping = ESCache.Event1ParamMapping;
            _event2Mapping = ESCache.Event2ParamMapping;
        }
        /// <summary>
        /// 单例
        /// </summary>
        /// <returns></returns>
        public   EventBus Instance()
        {
            if (_eventBus == null)
            {
                _eventBus = new EventBus();
                
            }
            return _eventBus;
        }
        /// <summary>
        /// 这里没有用到队列之类的东西，使用的是直接调用的方式
        /// </summary>
        /// <param name="eventData"></param>
        public   void ExecuteEvent1Param(ESEventArgs eventData)
        {
            // 找出这个事件对应的处理者
            Type eventType = eventData.GetType();

            if (_eventMapping.ContainsKey(eventType) == true)
            {
                foreach (Type item in _eventMapping[eventType])
                {
                    MethodInfo mi = item.GetMethod("Handle");
                    if (mi != null)
                    {
                        object o = Activator.CreateInstance(item);
                        mi.Invoke(o, new object[] { eventData });
                    }
                }

            }
        }
        public   void ExecuteEvent2Param(ESEventArgs eventargs, EventParams eventparams)
        {
            // 找出这个事件对应的处理者
            Type eventType = eventparams.GetType();

            if (_event2Mapping.ContainsKey(eventType) == true)
            {
                foreach (Type item in _event2Mapping[eventType])
                {
                    MethodInfo mi = item.GetMethod("Handle");
                    if (mi != null)
                    {
                        object o = Activator.CreateInstance(item);
                        mi.Invoke(o, new object[] { eventargs,eventparams });
                    }
                }

            }
        }
    }
}
