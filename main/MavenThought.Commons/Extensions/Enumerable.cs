using System.Collections;

namespace MavenThought.Commons.Extensions
{
    /// <summary>
    /// Main declaration for utility class
    /// </summary>
    public static partial class Enumerable
    {
        /// <summary>
        /// Returns the amount of elements in the collection
        /// </summary>
        /// <param name="collection">Collection to use</param>
        /// <returns>result = collection@pre.size</returns>
        public static int Count(this IEnumerable collection)
        {
            var result = 0;

            collection.ForEach((object x) => result++);

            return result;
        }

        /// <summary>
        /// Returns a value indicating whether the collection is empty
        /// </summary>
        /// <param name="collection">Collection to check for</param>
        /// <returns><c>true</c> if the collection has zero elements, <c>false</c> otherwise</returns>
        public static bool IsEmpty(this IEnumerable collection)
        {
            return collection.Count() == 0;   
        }
    }
}