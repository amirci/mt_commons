using System.Collections;
using System.Collections.Generic;
using MavenThought.Commons.Extensions;

namespace MavenThought.Commons
{
    partial class Ensure
    {

        /// <summary>
        /// Ensures that a string is not null or empty
        /// </summary>
        /// <param name="s">String to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for string format</param>
        static public void IsNotNullOrEmpty(string s, string msg, params object[] args)
        {
            IsTrue(string.IsNullOrEmpty(s), msg, args);
        }

        /// <summary>
        /// Ensure that the collection is not empty
        /// </summary>
        /// <param name="collection">Collection to use</param>
        /// <param name="msg">message to use</param>
        /// <param name="args">Argument for the string format</param>
        static public void IsNotEmpty(IEnumerable collection, string msg, params object[] args)
        {
            IsTrue(collection != null && collection.Count() > 0, msg, args);
        }
        /// <summary>
        /// Ensures a collection is not empty 
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the string format</param>
        static public void IsNotEmpty<T>(IEnumerable<T> collection, string msg, params object[] args)
        {
            IsNotEmpty((IEnumerable)collection, msg, args);
        }

        /// <summary>
        /// Ensures the collection is not empty
        /// </summary>
        /// <typeparam name="T">Type of the collection</typeparam>
        /// <param name="collection">Collection to use</param>
        static public void IsNotEmpty<T>(IEnumerable<T> collection)
        {
            IsNotEmpty(collection, "The collection can't be empty");
        }
    }
}
