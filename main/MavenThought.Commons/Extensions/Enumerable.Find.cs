using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MavenThought.Commons.Extensions
{
    /// <summary>
    /// Enumerable Find extension
    /// </summary>
    public static partial class Enumerable
    {
        /// <summary>
        /// Finds the first element in the collection that satisfies the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to search</param>
        /// <param name="predicate">Predicate to satisfy</param>
        /// <returns>The first element to satisfy the predicate</returns>
        /// <remarks>If the predicate can not be satisfied default(T) is returned</remarks>
        public static T Find<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            return collection.FirstOrDefault(t => predicate(t));
        }

        /// <summary>
        /// Finds the first element in the collection that satisfies the predicate
        /// </summary>
        /// <typeparam name="T">Type of the predicate</typeparam>
        /// <param name="collection">Collection to search</param>
        /// <param name="predicate">Predicate to satisfy</param>
        /// <returns>The first element to satisfy the predicate</returns>
        /// <remarks>If the predicate can not be satisfied default(T) is returned</remarks>
        public static T Find<T>(this IEnumerable collection, Predicate<T> predicate)
        {
            return collection.Cast<T>().Find(predicate);
        }

        /// <summary>
        /// Finds all the elements in the collection that satisfy the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to search</param>
        /// <param name="predicate">Predicate to satisfy</param>
        /// <returns>A collection with all the elements that satisfy the predicate</returns>
        public static IEnumerable<T> FindAll<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            return collection.Where(t => predicate(t)); 
        }

        /// <summary>
        /// Finds all the elements in the collection that satisfy the predicate
        /// </summary>
        /// <typeparam name="T">Type of the predicate</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to satisfy</param>
        /// <returns>A collection with all the elements that satisfy the predicate</returns>
        public static IEnumerable<T> FindAll<T>(this IEnumerable collection, Predicate<T> predicate)
        {
            return collection.Cast<T>().FindAll(predicate);
        }

        /// <summary>
        /// Finds all the elements that match the predicate and then applies the functor
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to filter</param>
        /// <param name="functor">Functor to use</param>
        /// <returns>The collection of elements that match the predicate with the functor applied</returns>
        public static IEnumerable<TResult> FindAll<T, TResult>(this IEnumerable<T> collection, Predicate<T> predicate, Func<T, TResult> functor)
        {
            return collection.FindAll(predicate).Select(functor).ToList();
        }

        /// <summary>
        /// Finds all the elements that match the predicate and then applies the functor
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to filter</param>
        /// <param name="functor">Functor to use</param>
        /// <returns>The collection of elements that match the predicate with the functor applied</returns>
        public static IEnumerable<TResult> FindAll<T, TResult>(this IEnumerable collection, Predicate<T> predicate, Func<T, TResult> functor)
        {
            return collection.Cast<T>().FindAll(predicate, functor);
        }

        /// <summary>
        /// Find the previous element to the element that matches the predicate
        /// </summary>
        /// <typeparam name="T">Type of the element</typeparam>
        /// <param name="collection">Collection to search</param>
        /// <param name="pred">Predicate to satisfy</param>
        /// <returns>
        /// A pair e1 x e2 where:
        /// - e1 is null if the first element in the collection satisfies the predicate
        /// - e2 satisfies the predicate and e1 is the previous element in the collection
        /// - null if no element satisfies the predicate
        /// </returns>
        public static IPair<T, T> FindPrevious<T>(this IEnumerable<T> collection, Predicate<T> pred)
        {
            Func<IPair<T, T>, IPair<T, T>> choosePair = r => pred(r.Second) ? r : Pair.MakeSecond(r.First);

            return collection
                .ToPairs()
                .Find(pair => pred(pair.First) || pred(pair.Second))
                .WhenNotNull(choosePair);
        }
    }
}