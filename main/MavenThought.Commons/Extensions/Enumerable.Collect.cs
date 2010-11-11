using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace MavenThought.Commons.Extensions
{
    public static partial class Enumerable
    { 
        /// <summary>
        /// Collects the result of applying a function to each element in the collection
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="fn">functor to use to collect the value</param>
        /// <returns> result = collection@pre->collect( x | fn( x ) )</returns>
        public static IEnumerable<TResult> Collect<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> fn)
        {
            return collection.Select(fn);
        }

        /// <summary>
        /// Collects the result of applying a function to each element in the collection
        /// </summary>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="fn">Functor to use to convert the value</param>
        /// <returns> result = collection@pre->collect( x | fn( x ) )</returns>
        public static IEnumerable<TResult> Collect<TResult>(this IEnumerable collection, Func<object, TResult> fn)
        {
            return collection.Cast<TResult>().Collect(fn);
        }
    }
}