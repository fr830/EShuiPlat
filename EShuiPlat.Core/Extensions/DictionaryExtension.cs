using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class DictionaryExtension
    {
        public static string KVPToXmlTemplate<T, V>(this KeyValuePair<T, V> instance, string strReg = null)
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

        public static string KVPToXml<T, V>(this KeyValuePair<T, V> instance, string strReg = null)
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
        public static string ToXml<T, V>(this Dictionary<T, V> instance, string strReg = null)
        {
            string result = "";

            foreach (var item in instance)
            {
                result = result + item.KVPToXml(strReg);

            }
            return result;
        }
        public static string ToXmlTemplate<T, V>(this Dictionary<T, V> instance, string strReg = null)
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
