using EShuiPlat.Core.Events;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
namespace System
{
    public static class EShuiNetExtention
    {
        public static bool ExecuteCheckEventFirst<T>(this T model, BusinessBus<T> bus)
        {
           return bus.On_CheckEventFirst(model);
        }
        public static bool ExecuteCheckEvent<T>(this T model, BusinessBus<T> bus)
        {
            return bus.On_CheckEvent(model);
        }
        
        /// <summary>
        /// 获取类中所有字段信息到字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetFieldsInfo<T>(this T model)
        {
            Dictionary<string, string> FieldInfos = new Dictionary<string, string>();
            FieldInfos.Clear();
            FieldInfo[] fields = model.GetType().GetFields();
            foreach (FieldInfo info in fields)
            {
                FieldInfos.Add(info.Name, info.GetValue(model).ToString());
            }

            return FieldInfos;
        }
        public static T Do<T>(this T t, Action<T> action)
        {
            action(t);
            return t;
        }
        public static T Do<T>(this T t, Predicate<T> predicate, Func<T, T> func)
        {
            return predicate(t) ? func(t) : t;
        }
        /// <summary>
        /// 获取所有属性到字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetPropertieInfo<T>(this T model)
        {

            Dictionary<string, string> FieldInfos = new Dictionary<string, string>();
            FieldInfos.Clear();
            PropertyInfo[] fields = model.GetType().GetProperties();
            foreach (PropertyInfo info in fields)
            {
                if (info.GetValue(model) != null)
                {
                    FieldInfos.Add(info.Name, info.GetValue(model).ToString());
                }
                else
                {
                    FieldInfos.Add(info.Name, "");
                }
            }


            return FieldInfos;
        }
        /// <summary>
        /// 获取字段列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<string> GetFieldList<T>(this T model)
        {
            List<string> FieldsList = new List<string>();
            FieldInfo[] fields = model.GetType().GetFields();
            foreach (FieldInfo info in fields)
            {
                FieldsList.Add(info.Name);
            }
            return FieldsList;
        }
        /// <summary>
        /// 获取属性列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<string> GetPropertyList<T>(this T model)
        {

            List<string> FieldsList = new List<string>();
            PropertyInfo[] fields = model.GetType().GetProperties();
            foreach (PropertyInfo info in fields)
            {
                FieldsList.Add(info.Name);
            }
            return FieldsList;
        }
        /// <summary>
        /// 获取类中所有私有方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<string> GetPrivateMethodList<T>(this T model)
        {

            List<string> FieldsList = new List<string>();
            MethodInfo[] fields = model.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo info in fields)
            {
                FieldsList.Add(info.Name);
            }
            return FieldsList;
        }
        /// <summary>
        /// 获取类中所有公有方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<string> GetPublicMethodList<T>(this T model)
        {

            List<string> FieldsList = new List<string>();
            MethodInfo[] fields = model.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (MethodInfo info in fields)
            {
                FieldsList.Add(info.Name);
            }
            return FieldsList;
        }
        /// <summary>
        /// 获取类中所有方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<string> GetMethodList<T>(this T model)
        {

            List<string> FieldsList = new List<string>();
            MethodInfo[] fields = model.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo info in fields)
            {

                FieldsList.Add(info.Name);
            }
            return FieldsList;
        }
        public static List<string> GetMethodParams<T>(this T model, string methodname)
        {

            List<string> FieldsList = new List<string>();
            MethodInfo[] fields = model.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo info in fields)
            {
                if (methodname == info.Name)
                {


                    info.GetParameters();
                }
            }
            return FieldsList;
        }
        /// <summary>
        /// 调用类中有返回值方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="FunctionName"></param>
        /// <param name="Params"></param>
        /// <returns></returns>
        public static object InvokeMethod<T>(this T model, string FunctionName, object[] Params)
        {

            Type t = model.GetType();
            MethodInfo method = t.GetMethod(FunctionName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            return method.Invoke(model, Params);
        }
        /// <summary>
        /// 调用类中无返回值方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="FunctionName"></param>
        /// <param name="Params"></param>
        public static void InvokeVoidMethod<T>(this T model, string FunctionName, object[] Params)
        {

            Type t = model.GetType();
            MethodInfo method = t.GetMethod(FunctionName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(model, Params);
        }
        /// <summary>
        /// 为类中属性赋值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="fieldinfo"></param>
        /// <returns></returns>
        public static T SetPropertyValue<T>(this T model, Dictionary<string, string> fieldinfo)
        {
            if (model == null)
            {
                model = default(T);
            }
            List<string> FieldsList = new List<string>();
            PropertyInfo[] fields = model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            foreach (PropertyInfo info in fields)
            {
                info.SetValue(model, fieldinfo[info.Name]);

            }

            return model;
        }
        /// <summary>
        /// 为类中字段赋值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="fieldinfo"></param>
        /// <returns></returns>
        public static T SetFieldValue<T>(this T model, Dictionary<string, string> fieldinfo)
        {
            if (model == null)
            {
                model = default(T);
            }
            List<string> FieldsList = new List<string>();
            FieldInfo[] fields = model.GetType().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            foreach (FieldInfo info in fields)
            {
                info.SetValue(model, fieldinfo[info.Name]);

            }

            return model;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
        ///递归寻找子控件
        //        public static IEnumerable<T> GetControls<T>(this Control control, Func<T, bool> filter) where T : Control
        //{
        //             foreach (Control c in control.Controls)
        //                 {
        //                 if (c is T && (filter == null || filter(c as T)))
        //                     {
        //                    yield return c as T;
        //                     }
        //                 foreach (T _t in GetControls<T>(c, filter))
        //                     yield return _t;
        //                 }
        //             }



        public static IEnumerable<T> GetDescendants<T>(this T root,
          Func<T, IEnumerable<T>> childSelector, Predicate<T> filter)
        {
            foreach (T t in childSelector(root))
            {
                if (filter == null || filter(t))
                    yield return t;
                foreach (T child in GetDescendants((T)t, childSelector, filter))
                    yield return child;
            }
        }
        /**************
1         //Form1.cs
2     //获取本窗体所有控件
3     var controls = (this as Control).GetDescendants(c => c.Controls.Cast<Control>(), null);
4     //获取所有选中的CheckBox
5     var checkBoxes = (this as Control).GetDescendants(
6             c => c.Controls.Cast<Control>(),
7             c => (c is CheckBox) && (c as CheckBox).Checked
8         )
9         .Cast<CheckBox>();
        *******************/
        public static IEnumerable<T> GetDescendants<TRoot, T>(this TRoot root,
          Func<TRoot, IEnumerable<T>> rootChildSelector,
          Func<T, IEnumerable<T>> childSelector, Predicate<T> filter)
        {
            foreach (T t in rootChildSelector(root))
            {
                if (filter == null || filter(t))
                    yield return t;
                foreach (T child in GetDescendants(t, childSelector, filter))
                    yield return child;
            }
        }
        /************************
         //获取TreeView中所有以“酒”结尾的树结点             
    var treeViewNode = treeView1.GetDescendants(
        treeView => treeView.Nodes.Cast<TreeNode>(),
        treeNode => treeNode.Nodes.Cast<TreeNode>(),
        treeNode => treeNode.Text.EndsWith("酒")
        );
        *******************************/
    }
}