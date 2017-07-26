using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace System
{
    public static class SystemExtention
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ReplaceValue<T>(this T model, string name, string value)
        {
            string str = model.ToString();
            if (name != null) str = str.Replace("{" + name.ToUpper() + "}", value);

            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SetParmValue<T>(this T model, string name, string value)
        {
            string str = model.ToString();
            if (name != null) str = str.Replace("{" + name.ToUpper() + "}", value);

            return str;
        }
        /// <summary>
        /// 通过Dic参数取代模板中的规则
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string ToXmlByDic<T>(this T model, Dictionary<string, string> dic)
        {
            string str = model.ToString();
            foreach (var item in dic)
            {
                if (item.Key != null)
                {
                    if (item.Value != null)
                    {
                        str = str.Replace("{" + item.Key.ToUpper() + "}", item.Value);
                    }
                    else
                    {
                        str = str.Replace("{" + item.Key.ToUpper() + "}", "");
                    }
                }

            }

            return str;
        }
        public static string ReplaceTemplateRuleByDic<T>(this T model, Dictionary<string, string> dic)
        {
            string str = model.ToString();
            foreach (var item in dic)
            {
                if (item.Key != null)
                {
                    if (item.Value != null)
                    {
                        str = str.Replace("{" + item.Key.ToUpper() + "}", item.Value);
                    }
                    else
                    {
                        str = str.Replace("{" + item.Key.ToUpper() + "}", "");
                    }
                }

            }

            return str;
        }
        /// <summary>
        /// 拼接两个dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="dic1"></param>
        /// <param name="dic2"></param>
        /// <returns></returns>
        public static Dictionary<T, V> ConcatDic<T, V>(this Dictionary<T, V> dic1, Dictionary<T, V> dic2 = null)
        {
            if (dic1 != null)
            {
                if (dic2 != null) dic1.Concat(dic2).ToDictionary(K => K.Key, kv => kv.Value);
            }
            else
            {
                return dic2;
            }
            return dic1;
        }

        public static string KPToXmlTemplate<T, V>(this KeyValuePair<T, V> instance, string strReg = null)
        {
            string result = "";
            if (strReg == null)
            {
                strReg = "<{KEY}>{{KEY}}</{KEY}>";

                if (instance.Key != null && instance.Value != null)
                {
                    result = strReg.Replace("{KEY}", instance.Key.ToString());
                }

            }
            else
            {
                if (strReg != null && strReg.Length > 10)
                {
                    if (instance.Key != null && instance.Value != null)
                    {
                        result = strReg.Replace("{KEY}", instance.Key.ToString());
                    }
                }
            }
            return result;
        }

        public static string KPToXml<T, V>(this KeyValuePair<T, V> instance, string strReg = null)
        {
            string result = "";
            if (strReg == null)
            {
                strReg = "<{KEY}>{VALUE}</{KEY}>";

                if (instance.Key != null && instance.Value != null)
                {
                    result = strReg.Replace("{KEY}", instance.Key.ToString()).Replace("{VALUE}", instance.Value.ToString());
                }

            }
            else
            {
                if (strReg != null && strReg.Length > 10)
                {
                    if (instance.Key != null && instance.Value != null)
                    {
                        result = strReg.Replace("{" + instance.Key.ToString().ToUpper() + "}", instance.Value.ToString());
                    }
                }
            }
            return result;
        }
        public static string DicToXml<T, V>(this Dictionary<T, V> instance, string strReg = null)
        {
            string result = "";

            foreach (var item in instance)
            {
                result = result + item.KVPToXml(strReg);

            }
            return result;
        }
        public static string DicToXmlTemplate<T, V>(this Dictionary<T, V> instance, string strReg = null)
        {
            string result = "";

            foreach (var item in instance)
            {
                result = result + item.KVPToXmlTemplate(strReg);

            }
            return result;
        }

        public static List<T> KeyList<T, V>(this Dictionary<T, V> instance)
        {
            List<T> lists = new List<T>();

            foreach (var item in instance)
            {
                lists.Add(item.Key);

            }
            return lists;
        }
        public static List<V> ValueList<T, V>(this Dictionary<T, V> instance)
        {
            List<V> lists = new List<V>();

            foreach (var item in instance)
            {
                lists.Add(item.Value);

            }
            return lists;
        }
    }
}
