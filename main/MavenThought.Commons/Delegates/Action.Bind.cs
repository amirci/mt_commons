using System;

namespace MavenThought.Commons.Delegates
{
    public static class ActionHelper
    {
        /// <summary>
        /// Returns a unary action equivalent to the binary action with the second argument bound to a value
        /// </summary>
        /// <typeparam name="T1">Type for first argument</typeparam>
        /// <typeparam name="T2">Type for second argument</typeparam>
        /// <param name="action">Binary action to use</param>
        /// <param name="val">Value to bind as second parameter</param>
        /// <returns>result where forAll( x | result( x ) = action( x, val ) ) </returns>
        public static Action<T1> Bind<T1, T2>(this Action<T1, T2> action, T2 val)
        {
            return x => action(x, val);
        }

        /// <summary>
        /// Returns a unary action equivalent to the binary action with the first argument bound to a value
        /// </summary>
        /// <typeparam name="T1">Type of the first parameter</typeparam>
        /// <typeparam name="T2">Type of the second parameter</typeparam>
        /// <param name="action">Action to use</param>
        /// <param name="val">Value to bind as first parameter</param>
        /// <returns>result where forAll( x | result( x ) = action( val, x ) ) </returns>
        public static Action<T2> Bind<T1, T2>(this Action<T1, T2> action, T1 val)
        {
            return x => action(val, x);
        }
    }
}