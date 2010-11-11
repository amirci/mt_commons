using System.Collections.Generic;

namespace MavenThought.Commons.Extensions
{
    public static partial class Enumerable
    {
        /// <summary>
        /// Creates a collection given a sequence of elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static IEnumerable<T> Create<T>(params T[] elements)
        {
            var result = new List<T>();

            elements.ForEach(result.Add);

            return result;
        }
    }
}