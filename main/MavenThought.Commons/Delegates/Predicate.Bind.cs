using System;
using MavenThought.Commons.Delegates;


namespace MavenThought.Commons.Delegates
{
    public static partial class Predicates
    {
        /// <summary>
        /// Binary binder to unary predicate
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="pred"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Predicate<T1> Bind<T1, T2>( this Predicate<T1, T2> pred, T2 value)
        {
            return x => pred(x, value);
        }
    }
}