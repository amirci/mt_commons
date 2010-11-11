using System;

namespace MavenThought.Commons.Delegates
{
    public static partial class Predicates
    {
        /// <summary>
        /// Boolean negation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static Predicate<T> Not<T>(this Predicate<T> predicate)
        {
            return x => !predicate(x);
        }

        /// <summary>
        /// Boolean and
        /// </summary>
        /// <typeparam name="T">Type of the predicate</typeparam>
        /// <param name="left">Predicate left operand</param>
        /// <param name="right">Predicate right operand</param>
        /// <returns>result where result(x) === left(x) && right(x)</returns>
        public static Predicate<T> And<T>( this Predicate<T> left, Predicate<T> right )
        {
            return x => left(x) && right(x);
        }

        /// <summary>
        /// Boolean Or
        /// </summary>
        /// <typeparam name="T">Type of the predicates</typeparam>
        /// <param name="left">Left operand</param>
        /// <param name="right">Right operand</param>
        /// <returns>result where result(x) === left(x) || right(x)</returns>
        public static Predicate<T> Or<T>( this Predicate<T> left, Predicate<T> right )
        {
            return x => left(x) || right(x);            
        }
    }
}