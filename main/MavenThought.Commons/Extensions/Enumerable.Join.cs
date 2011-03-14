namespace MavenThought.Commons.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public static partial class Enumerable
    {
        /// <summary>
        /// Joins the elements of a collection to a string using a separator
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="separator">Separator to use</param>
        /// <returns>result = collection@pre->collect( x | x.ToString() + separator ).head()</returns>
        public static string Join<T>( this IEnumerable<T> collection, char separator)
        {
            return collection.Join(separator, x => Equals(x, null) ? "null" : x.ToString());
        }

        /// <summary>
        /// Joins the element in the collection using fn to convert each element to string
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="separator">Separator to use</param>
        /// <param name="fn">Function to use to convert to string</param>
        /// <returns>result = concatenation( fn(x) + separator ).head()</returns>
        public static string Join<T>(this IEnumerable<T> collection, char separator, Func<T, string> fn)
        {
            return collection
                .Head()
                .Aggregate(new StringBuilder(), (b, x) =>
                                                    {
                                                        b.Append(fn(x));
                                                        b.Append(separator);
                                                        return b;
                                                    })
                .Append(collection.Last())
                .ToString();
        }

    }
}