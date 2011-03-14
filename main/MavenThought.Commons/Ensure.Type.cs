using System;

namespace MavenThought.Commons
{
    public partial class Ensure
    {
        /// <summary>
        /// Ensure that the argument is an instance of T
        /// </summary>
        /// <typeparam name="T">Type to check against</typeparam>
        /// <param name="o">Object to check for</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the string format</param>
        public static void IsInstanceOf<T>(object o, string msg, params object[] args)
        {
            IsInstanceOf<T, Exception>(o, DefaultExceptionFunctor, msg, args);
        }

        /// <summary>
        /// Ensure that the argument is an instance of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void IsInstanceOf<T>(object obj)
        {
            IsInstanceOf<T>(obj, "The type {0} is not assignable to {1}", obj.GetType(), typeof(T));
        }

        /// <summary>
        /// Ensure that the argument is an instance of T using the functor to create an exception if not.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="UEx"></typeparam>
        /// <param name="obj"></param>
        /// <param name="functor"></param>
        public static void IsInstanceOf<T, UEx>(object obj, Func<string, UEx> functor) where UEx : Exception
        {
            IsInstanceOf<T, UEx>(obj, functor, "The type {0} is not assignable to {1}", obj.GetType(), typeof(T));            
        }

        public static void IsIntanceOf<T, UEx>(object obj, Func<UEx> functor) where UEx : Exception
        {
            IsInstanceOf<T, UEx>(obj, s => functor());
        }

        /// <summary>
        /// Ensure the argument is an instance of T.
        /// </summary>
        /// <typeparam name="T">Target type to check for</typeparam>
        /// <typeparam name="UEx">Type of the exception to throw</typeparam>
        /// <param name="obj">Obj to check</param>
        /// <param name="functor">Functor to create the exception</param>
        /// <param name="message">Message to use</param>
        /// <param name="args">Arguments for the message</param>
        static public void IsInstanceOf<T, UEx>(object obj, Func<string, UEx> functor, string message, params object[]args) where UEx : Exception
        {
            IsTrue(typeof(T).IsAssignableFrom(obj.GetType()), functor, message, args);
        }
    }
}
