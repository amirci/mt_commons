using System.Collections.Generic;
using System.Linq;

namespace MavenThought.Commons.Extensions
{
    public partial class Enumerable
    {
        /// <summary>
        /// Selects an element from the collection randomly
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <returns>A random element from the collection</returns>
        public static T RandomElement<T>(this IEnumerable<T> collection)
        {
            return collection.FirstOrDefault();
        }
    }
}
