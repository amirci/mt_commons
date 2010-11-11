using System;
using System.Collections.Generic;
using System.Linq;

namespace MavenThought.Commons.Extensions
{
    public static partial class Enumerable
    {
        /// <summary>
        /// Maps a collection to a dictionary using a mapper functor for the value
        /// </summary>
        /// <typeparam name="TKey">Type of the key (same as the collection)</typeparam>
        /// <typeparam name="TValue">Type of the value</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="mapper">Mappert functor to use</param>
        /// <returns>A dictionary which each element is the result of applying the mapper to the source collection</returns>
        public static IDictionary<TKey, TValue> Map<TKey, TValue>(this IEnumerable<TKey> collection, Func<TKey, TValue> mapper)
        {
            // Call map with the identity
            return collection.ToDictionary(x => x, mapper);
        }

        /// <summary>
        /// Maps a collection to a dictionary using a mapper functor for the value
        /// </summary>
        /// <typeparam name="TKey">Type of the key (same as the collection)</typeparam>
        /// <typeparam name="TValue">Type of the value</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="mapper">Mappert functor to use</param>
        /// <param name="comparer">Comparer to use</param>
        /// <returns>A dictionary which each element is the result of applying the mapper to the source collection</returns>
        public static IDictionary<TKey, TValue> Map<TKey, TValue>(this IEnumerable<TKey> collection, 
            Func<TKey, TValue> mapper, IEqualityComparer<TKey> comparer)
        {
            // Call map with the identity and the comparer
            return collection.ToDictionary(x => x, mapper, comparer);
        }    
    }
}