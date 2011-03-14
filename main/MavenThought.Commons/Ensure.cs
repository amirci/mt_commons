using System;
using System.Globalization;

namespace MavenThought.Commons
{
    /// <summary>
    /// Ensure related methods
    /// </summary>
    public static partial class Ensure
    {
        /// <summary>
        /// Default exception to throw
        /// </summary>
        public static Func<string, Exception> DefaultExceptionFunctor { get; set; }

        /// <summary>
        /// Default message when is true fails
        /// </summary>
        public static string DefaultIsTrueMessage { get; set; }

        /// <summary>
        /// Ensures that the condition is true
        /// </summary>
        /// <param name="condition">Condition to check</param>
        public static void IsTrue(bool condition)
        {
            IsTrue(condition, DefaultIsTrueMessage);
        }

        /// <summary>
        /// Ensure the condition is true specifying a message
        /// </summary>
        /// <param name="condition">Condition to check</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the string format</param>
        public static void IsTrue(bool condition, string msg, params object[] args)
        {
            IsTrue(condition, DefaultExceptionFunctor, msg, args);
        }

        /// <summary>
        /// Ensure the condition is true or throws the specified exception
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        public static void IsTrue<T>(bool condition) where T : Exception, new()
        {
            IsTrue(condition, () => new T());
        }

        /// <summary>
        /// Ensure the condition is true. If not uses the functor to throw the exception T
        /// </summary>
        /// <typeparam name="T">Type of the exception</typeparam>
        /// <param name="condition">Condition to check</param>
        /// <param name="functor">Functor to create the exception</param>
        public static void IsTrue<T>(bool condition, Func<T> functor) where T : Exception
        {
            // The message does not matter
            IsTrue(condition, s => functor(), string.Empty);
        }

        /// <summary>
        /// Ensure the condition is true. If not uses the functor to throw an exception with the message
        /// </summary>
        /// <typeparam name="T">Type of the exception</typeparam>
        /// <param name="condition">Condition to use</param>
        /// <param name="functor">Functor to create the exception</param>
        /// <param name="message">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        public static void IsTrue<T>(bool condition, Func<String, T> functor, string message, params object[] args)
            where T : Exception
        {
            if (!condition)
            {
                var fmsg = string.Format(CultureInfo.CurrentCulture, message, args);
                throw functor(fmsg);
            }
        }

        /// <summary>
        /// Default values intialization
        /// </summary>
        static Ensure()
        {
            DefaultExceptionFunctor = s => new EnsureException(s);
            DefaultIsTrueMessage = "The condition specified is not true";
        }
    }
}