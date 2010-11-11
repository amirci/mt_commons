using System;
using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Delegates;

namespace MavenThought.Commons.Extensions
{
    static public partial class Enumerable
    {
        /// <summary>
        /// Checks a predicate for all the elements in the collection
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to use</param>
        /// <returns>result = collection@pre->forAll( x | predicate(x) )</returns>
        public static bool ForAll<T>( this IEnumerable<T> collection, Predicate<T> predicate )
        {
            return collection.All( x => predicate(x) );
        }

        /// <summary>
        /// Checks that one element at least in the collection satisfies the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to use</param>
        /// <returns>result = collection@pre->exists( x | predicate(x) )</returns>
        public static bool Exists<T>( this IEnumerable<T> collection, Predicate<T> predicate )
        {
            return collection.Any(x => predicate(x));
        }

        /// <summary>
        /// Checks that no element in the collection satisfies the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to use</param>
        /// <returns>result = collection@pre->forAll( x | !predicate(x) )</returns>
        public static bool ForNone<T>( this IEnumerable<T> collection, Predicate<T> predicate )
        {
            return collection.ForAll( predicate.Not() );
        }
    }
}