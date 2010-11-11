using System;
using System.Collections.Generic;
using MavenThought.Commons.Delegates;

namespace MavenThought.Commons.Extensions
{
    public static partial class Enumerable
    {
        /// <summary>
        /// Finds the index of the predicate in the collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">Collection to search</param>
        /// <param name="predicate">Predicate to use</param>
        /// <returns>result where predicate( collection->at( result ) ) and forAll( 0 <= i < result : !predicate( collection->at( i ) ) )</returns>
        /// <remarks>result = -1 implies collection->forAll( x | !predicate( x ) )</remarks>
        public static int IndexOf<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            var i = 0;

            // Cursor to iterate
            var cursor = collection.GetEnumerator();

            // While the predicate is false, increment i
            while( cursor.MoveNext() && !predicate(cursor.Current)) i++;

            // if predicate is not found
            return i == collection.Count() ? -1 : i;
        }

        /// <summary>
        /// Finds the index of element in the collection
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">collection to search</param>
        /// <param name="element">element to find the index for</param>
        /// <returns>result where collection->at( result ) = element and forAll( 0 <= i < result : collection->at( i ) != element )</returns>
        /// <remarks>result = -1 implies !collection->includes( element )</remarks>
        public static int IndexOf<T>(this IEnumerable<T> collection, T element)
        {
            var isEqual = Predicates.IsEqualTo<T, T>().Bind(element);

            return collection.IndexOf(isEqual);
        }
    }
}