using System;
using System.Collections.Generic;
using System.Linq;

namespace MavenThought.Commons.Extensions
{
    public static partial class Enumerable
    {
        /// <summary>
        /// Iterates the collection as pairs
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="action">Action to call</param>
        public static void ForEachPair<T>(this IEnumerable<T> collection, Action<T, T> action)
        {
            var array = collection.ToArray();

            if (array.Length == 0)
            {
                return;
            }

            if (array.Length == 1)
            {
                action(array[0], default(T));
            }

            for (var i = 0; i < array.Length - 1; i++)
            {
                action(array[i], array[i + 1]);
            }
        }
    }
}
