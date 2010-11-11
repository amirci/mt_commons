using System.Collections.Generic;
using System.Linq;

namespace MavenThought.Commons.Extensions
{
    /// <summary>
    /// Enumerable extensions for sequences
    /// </summary>
    public static partial class Enumerable
    {
        /// <summary>
        /// Returns the slice of the collection between elements start and end
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="start">Start of the slice</param>
        /// <param name="end">End of the slice</param>
        /// <returns>result = collection@pre->at( start, end )</returns>
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> collection, int start, int end)
        {
            var count = collection.Count();

            Ensure.IsTrue(start.Between(0, end) && end.Between(0, count), 
                          "The start '{0}' and end '{1}' should be between 0 and {2}", 
                          start, end, count);

            return collection.Where((e, i) => i.Between(start, end));
        }

        /// <summary>
        /// Returns all the elements but the last
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="sequence">collection to use</param>
        /// <returns>result = collection@pre->at( 0, length - 2 )</returns>
        public static IEnumerable<T> Head<T>(this IEnumerable<T> sequence)
        {
            return sequence.Take(sequence.Count() - 1);
        }

        /// <summary>
        /// Returns all the elements but the first
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="sequence">Collection to use</param>
        /// <returns>result = collection@pre->at( 1, length - 1)</returns>
        public static IEnumerable<T> Tail<T>(this IEnumerable<T> sequence)
        {
            return sequence.Skip(1);
        }

        /// <summary>
        /// Concats one element to the sequence
        /// </summary>
        /// <typeparam name="T">Type of the sequence</typeparam>
        /// <param name="sequence">Sequence to use</param>
        /// <param name="element">Element to concat</param>
        /// <returns>A new sequence that has the concatenation of sequence@pre + element</returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> sequence, T element)
        {
            return sequence.Concat(new[] { element });
        }
    }
}