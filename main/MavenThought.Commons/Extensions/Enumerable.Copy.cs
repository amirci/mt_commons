using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MavenThought.Commons.Extensions
{
    public static partial class Enumerable
    {
        /// <summary>
        /// Copies the values of the collection to the target
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Source</param>
        /// <param name="result">Target</param>
        /// <returns>The taret collection</returns>
        public static IEnumerable<T> Copy<T>(this IEnumerable<T> collection, ICollection<T> result)
        {
            collection.ForEach(result.Add);

            return result;
        }
        
        /// <summary>
        /// Copies the elements of the collection that satisfy the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection to copy</typeparam>
        /// <param name="collection">Collection to copy</param>
        /// <param name="result">Result to put the elements that satisfy the predicate</param>
        /// <param name="predicate">Predicate to filter the elements</param>
        /// <returns> result = collection@pre->select( x | predicate( x ) )</returns>
        public static IEnumerable<T> Copy<T>(this IEnumerable<T> collection, ICollection<T> result, Predicate<T> predicate)
        {
            collection
                .Where(x => predicate(x))
                .ForEach(result.Add);

            return result;
        }

        /// <summary>
        /// Copies the elements of the collection that satisfy the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to copy</param>
        /// <param name="result">Result to fill with the elements</param>
        /// <param name="predicate">Predicate to satisfy</param>
        /// <returns> result = collection@pre->select( x | predicate( x ) )</returns>
        public static IEnumerable<T> Copy<T>(this IEnumerable collection, ICollection<T> result, Predicate<T> predicate)
        {
            collection
                .Cast<T>()
                .Where(x => predicate(x))
                .ForEach(result.Add);

            return result;
        }

        /// <summary>
        /// Copies the elements to a new collection aplying the functor
        /// </summary>
        /// <typeparam name="T">Type of the input collection</typeparam>
        /// <typeparam name="TResult">Type of the output collection</typeparam>
        /// <param name="collection">Collection to copy</param>
        /// <param name="result">Target collection</param>
        /// <param name="functor">Functor to apply</param>
        /// <returns>The result collection with the copied elements</returns>
        public static IEnumerable<TResult> Copy<T, TResult>(this IEnumerable<T> collection, ICollection<TResult> result, Func<T, TResult> functor)
        {
            collection.ForEach(x => result.Add(functor(x)));

            return result;
        }
    }
}