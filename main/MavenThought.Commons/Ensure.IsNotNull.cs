using System;

namespace MavenThought.Commons
{
    public partial class Ensure
    {
        /// <summary>
        /// Ensures the object is not null
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the string format</param>
        /// <exception cref="EnsureException">If the object is null with the specified message</exception>
        public static void IsNotNull(object obj, string msg, params object[] args)
        {
            IsTrue(obj != null, msg, args);
        }

        /// <summary>
        /// Ensures the object is not using the specified exception
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void IsNotNull<T>(object obj) where T : Exception, new()
        {
            IsTrue<T>( obj != null );
        }

        /// <summary>
        /// Ensure the object is not null using the functor to create the exception to throw
        /// </summary>
        /// <typeparam name="T">Type of the exception</typeparam>
        /// <param name="obj">Object to check</param>
        /// <param name="functor">Functor to create the exception using the message</param>
        /// <param name="message">Message to use</param>
        /// <param name="args">Args for the message</param>
        public static void IsNotNull<T>(object obj, Func<string, T> functor, string message, params object[] args) where T : Exception
        {
            IsTrue(obj!=null, functor, message, args);
        }
    }
}
