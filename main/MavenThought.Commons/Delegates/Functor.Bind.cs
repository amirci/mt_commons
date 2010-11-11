
using System;

namespace MavenThought.Commons.Delegates
{
    public static partial class FunctorHelper
    {
        /// <summary>
        /// Binds the second argument of a binary functor to a constant
        /// </summary>
        /// <typeparam name="T1">Type of the first argument</typeparam>
        /// <typeparam name="T2">Type of the second argument</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="fn">Functor to bind</param>
        /// <param name="val">Constant value to use</param>
        /// <returns>A unary functor x where x(TArg1) returns fn(TArg1, val)</returns>
        public static Func<T1, TResult> Bind<T1, T2, TResult>(this Func<T1, T2, TResult> fn, T2 val)
        {
            return x => fn(x, val);
            
        }

        /// <summary>
        /// Binds the first argument of a binary functor to a constant
        /// </summary>
        /// <typeparam name="T1">Type of the first argument</typeparam>
        /// <typeparam name="T2">Type of the second argument</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="fn">Functor to bind</param>
        /// <param name="val">Constant value to use</param>
        /// <returns>A unary functor x where x(TArg2) returns fn(val, TArg2)</returns>
        public static Func<T2, TResult> Bind<T1, T2, TResult>(this Func<T1, T2, TResult> fn, T1 val)
        {
            return x => fn(val, x);
        }

        /// <summary>
        /// Binds the argument of a unary functor to a constant
        /// </summary>
        /// <typeparam name="T">Type of the argument</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="fn">Functor to bind</param>
        /// <param name="val">Constant value to use</param>
        /// <returns>A generator x where x() return fn( val )</returns>
        public static Generator<TResult> Bind<T, TResult>(this Func<T, TResult> fn, T val)
        {
            return () => fn(val);
        }
    }
}