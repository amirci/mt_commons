using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Delegates;


namespace MavenThought.Commons.Extensions
{
    public static partial class Enumerable
    {
        /// <summary>
        /// Applies an action to each element in the collection
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="action">Action to apply</param>
        /// <remarks> collection->forAll( x | action( x ) )</remarks>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            ForEach((IEnumerable) collection, action);
        }


        /// <summary>
        /// Applies an action to each element in the collection (Casting to T)
        /// </summary>
        /// <typeparam name="T">Type to cast</typeparam>
        /// <param name="collection">Collection of elements</param>
        /// <param name="action">Action to use on each element</param>
        /// <remarks> collection->forAll( x | action( x.oclAsType(T) ) )</remarks>
        public static void ForEach<T>(this IEnumerable collection, Action<T> action)
        {
            foreach( var e in collection )
            {
                action( (T) e);
            }
        }

        /// <summary>
        /// Applies an action to each element in the collection passing the index
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="action">Action to apply</param>
        /// <remarks> collection->forAll( x | action( x ) )</remarks>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<int, T> action)
        {
            var i = 0 ;

            foreach (var e in collection)
            {
                action(i++, e);
            }
        }

        /// <summary>
        /// Applies an action for all the elements in the collection that match the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to satisfy</param>
        /// <param name="action">Action to apply</param>
        /// <remarks>colection->forAll( x | if( predicate(x) ) action(x) )</remarks>
        public static void ForEach<T>(this IEnumerable<T> collection, Predicate<T> predicate,  Action<T> action)
        {
            ForEach((IEnumerable)collection, predicate, action);
        }

        /// <summary>
        /// Applies an action for all the elements in the collection that match the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to satisfy</param>
        /// <param name="action">Action to apply</param>
        /// <remarks>colection->forAll( x | if( predicate(x) ) action(x) )</remarks>
        public static void ForEach<T>(this IEnumerable<T> collection, Predicate<int, T> predicate, Action<int, T> action)
        {
            var i = 0;

            foreach (var t in collection)
            {
                if (predicate(i, t))
                {
                    action(i, t);
                }

                i++;
            }
        }

        /// <summary>
        /// Applies an action for all the elements in the collection that match the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to satisfy</param>
        /// <param name="action">Action to apply</param>
        /// <remarks>colection->forAll( x | if( predicate(x) ) action(x) )</remarks>
        public static void ForEach<T>(this IEnumerable collection, Predicate<T> predicate, Action<T> action)
        {
            foreach (var t in collection)
            {
                if (predicate((T)t))
                    action((T)t);
            }
        }

        /// <summary>
        /// Applies a functor for each element of the collection
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <typeparam name="TResult">Type of the result of the functor</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="func">Functor to use</param>
       public static IEnumerable<TResult> ForEach<T, TResult>(this IEnumerable<T> collection, Func<T, TResult> func)
        {
            return collection.Select(func).ToList();
        }

       /// <summary>
       /// Applies a functor for each element of the collection passing the index
       /// </summary>
       /// <typeparam name="T">Type of the collection</typeparam>
       /// <typeparam name="TResult">Type of the result of the functor</typeparam>
       /// <param name="collection">Collection to use</param>
       /// <param name="func">Functor to use</param>
       public static IEnumerable<TResult> ForEach<T, TResult>(this IEnumerable<T> collection, Func<int, T, TResult> func)
       {
           var result = new List<TResult>();

           var action = new Action<int, T>((i, e) => result.Add(func(i, e)));

           ForEach(collection, action);

           return result;
       }

        /// <summary>
        /// Applies a functor for all the elements in the collection that match the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to satisfy</param>
        /// <param name="func">Functor to apply</param>
        /// <returns>A collection with the reult of calling func on the matching element</returns>
        public static IEnumerable<TResult> ForEach<T, TResult>(this IEnumerable collection, Predicate<T> predicate, Func<T, TResult> func)
        {
            var result = new List<TResult>();

            var action = new Action<T>(e => result.Add(func(e)));

            ForEach(collection, predicate, action);

            return result;
        }

        /// <summary>
        /// Applies a functor for all the elements in the collection that match the predicate
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="predicate">Predicate to satisfy</param>
        /// <param name="func">Functor to apply</param>
        /// <returns>A collection with the reult of calling func on the matching element</returns>
        public static IEnumerable<TResult> ForEach<T, TResult>(this IEnumerable<T> collection, Predicate<int, T> predicate, Func<int, T, TResult> func)
        {
            var result = new List<TResult>();

            var action = new Action<int, T>((i, e) => result.Add(func(i, e)));

            ForEach(collection, predicate, action);

            return result;
        }
    }
}