using System;
using System.Collections.Generic;

namespace MavenThought.Commons.Extensions
{
    /// <summary>
    /// Extensions for numbers (Integer, Long, etc)
    /// </summary>
    static public class NumberExt
    {
        /// <summary>
        /// Runs the action the amount of times specified
        /// </summary>
        /// <param name="amount">The amount of times to run the action</param>
        /// <param name="action">Action to run</param>
        public static void Times(this int amount, Action action)
        {
            Times(amount, i => action() );
        }

        /// <summary>
        /// Runs the action the amount of times specified passing the index as parameter
        /// </summary>
        /// <param name="amount">The amount of times to run the action</param>
        /// <param name="action">Action to run</param>
        public static void Times(this int amount, Action<int> action)
        {
            for (var i = 0; i < amount; i++)
            {
                action(i);
            }
        }

        /// <summary>
        /// Returns if a number is in range 
        /// </summary>
        /// <param name="number">Number to check for</param>
        /// <param name="min">Min range</param>
        /// <param name="max">Max range</param>
        /// <returns>True if number is between min and max</returns>
        public static bool Between(this int number, double min, double max)
        {
            return number >= min && number <= max;
        }

        /// <summary>
        /// Runs the functor the amount of times specified returning the collection with the results
        /// </summary>
        /// <typeparam name="TResult">Type of the result of the functor</typeparam>
        /// <param name="amount">The amount of times to run the functor</param>
        /// <param name="functor">Functor to run</param>
        /// <returns>A collection with all the results</returns>
        public static IEnumerable<TResult> Times<TResult>(this int amount, Func<TResult> functor )
        {
            var result = new List<TResult>();

            Times(amount, () => result.Add(functor()));

            return result;
        }

        /// <summary>
        /// Runs the functor the amount of times specified returning the collection with the results
        /// </summary>
        /// <typeparam name="TResult">Type of the result of the functor</typeparam>
        /// <param name="amount">Amount of times to call</param>
        /// <param name="functor">Functor to use</param>
        /// <returns>The collection with the result of calling the functor with each element</returns>
        public static IEnumerable<TResult> Times<TResult>(this int amount, Func<int, TResult> functor)
        {
            var result = new List<TResult>();

            Times(amount, i => result.Add(functor(i)));

            return result;
        }
    }
}