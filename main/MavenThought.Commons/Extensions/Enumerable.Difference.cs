using System.Collections.Generic;
using MavenThought.Commons.Delegates;

namespace MavenThought.Commons.Extensions
{
    /// <summary>
    /// Collection difference
    /// </summary>
    public partial class Enumerable
    {
        /// <summary>
        /// Calculates the difference between c1 and c2 (all the elements in c1 that are not in c2)
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="c1">Collection 1</param>
        /// <param name="c2">Collection 2</param>
        /// <param name="equality">Equality predicate to use</param>
        /// <returns>A collection with all the elements that exist in c1 but no in c2</returns>
        public static IEnumerable<T> Difference<T>(this IEnumerable<T> c1, IEnumerable<T> c2, Predicate<T, T> equality)
        {
            return c1.FindAll(e1 => !c2.Exists(equality.Bind(e1)));
        }

        /// <summary>
        /// Calculates the difference between c1 and c2 (all the elements in c1 that are not in c2)
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="c1">Collection 1</param>
        /// <param name="c2">Collection 2</param>
        /// <returns>A collection with all the elements that exist in c1 but no in c2</returns>
        public static IEnumerable<T> Difference<T>(this IEnumerable<T> c1, IEnumerable<T> c2)
        {
            return c1.Difference(c2, (e1, e2) => e1.Equals(e2));
        }
    }
}