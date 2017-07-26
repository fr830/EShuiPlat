using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class LinkExtention
    {
        /********************************************************************************************
         * 
         * 
         * 
         *  //扩展方式
            int int0 = -121;
            int int1 = int0.If(i => i < 0, i => -i)
                .If(i => i > 100, i => i - 100)
                .If(i => i % 2 == 1, i => i - 1);
            //常规方式
            int int3 = -121;
            if (int3 < 0) int3 = -int3;
            if (int3 > 100) int3 -= 100;
            if (int3 % 2 == 1) int3--;

    ****************************************************************************************************/
        public static T If<T>(this T t, Predicate<T> predicate, Func<T, T> func) where T : struct
        {
            return predicate(t) ? func(t) : t;
        }
        public static TOutput Switch<TOutput, TInput>(this TInput input, IEnumerable<TInput> inputSource, IEnumerable<TOutput> outputSource, TOutput defaultOutput)
        {
            IEnumerator<TInput> inputIterator = inputSource.GetEnumerator();
            IEnumerator<TOutput> outputIterator = outputSource.GetEnumerator();

            TOutput result = defaultOutput;
            while (inputIterator.MoveNext())
            {
                if (outputIterator.MoveNext())
                {
                    if (input.Equals(inputIterator.Current))
                    {
                        result = outputIterator.Current;
                        break;
                    }
                }
                else break;
            }
            return result;
        }
        public static void While<T>(this T t, Predicate<T> predicate, Action<T> action) where T : class
        {
            while (predicate(t)) action(t);
        }
        public static void While<T>(this T t, Predicate<T> predicate, params Action<T>[] actions) where T : class
        {
            while (predicate(t))
            {
                foreach (var action in actions)
                    action(t);
            }
        }
        public static T If<T>(this T t, Predicate<T> predicate, params Action<T>[] actions) where T : class
        {
            if (t == null) throw new ArgumentNullException();
            if (predicate(t))
            {
                foreach (var action in actions)
                    action(t);
            }
            return t;
        }
        /// <summary>
        /// 先执行操作，再返回自身
        /// </summary>
        public static T Do<T>(this T t, Action<T> action)
        {
            action(t);
            return t;
        }

    }
}
