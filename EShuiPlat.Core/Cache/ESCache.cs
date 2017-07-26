using System;
using System.Collections.Generic;
using System.Text;

namespace EShuiPlat.Core
{
  public static  class ESCache
    {
        public static Dictionary<Type, List<Type>> Event1ParamMapping = new Dictionary<Type, List<Type>>();  // 在这个字典中，key存储的是事件，而value中存储的是事件处理程序
        public static Dictionary<Type, List<Type>> Event2ParamMapping = new Dictionary<Type, List<Type>>();  // 在这个字典中，key存储的是事件，而value中存储的是事件处理程序
    }
}
