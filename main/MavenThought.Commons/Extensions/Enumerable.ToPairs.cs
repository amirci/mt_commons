using System.Collections.Generic;
using System.Linq;

namespace MavenThought.Commons.Extensions
{
    public static partial class Enumerable
    {
        /// <summary>
        /// Transforms the collection to a collection of pairs Pair<0, 1>, Pair<1, 2>, son on
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <returns>A collection of pairs</returns>
        public static IEnumerable<Pair<T, T>> ToPairs<T>(this IEnumerable<T> collection)
        {
            var array = collection.ToArray();

            var result = new List<Pair<T, T>>();

            if (array.Length == 0)
            {
                return result;
            }

            if (array.Length == 1)
            {
                result.Add(Pair.Make(array[0], default(T)));
            }

            for (var i = 0; i < array.Length - 1; i++)
            {
                result.Add(Pair.Make(array[i], array[i + 1]));
            }

            return result;
        }
   }
}