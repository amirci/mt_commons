using System;

namespace MavenThought.Commons.Delegates
{
    /// <summary>
    /// Functor for 5 parameters
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TArg1"></typeparam>
    /// <typeparam name="TArg2"></typeparam>
    /// <typeparam name="TArg3"></typeparam>
    /// <typeparam name="TArg4"></typeparam>
    /// <typeparam name="TArg5"></typeparam>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <returns></returns>
    public delegate TResult Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);

    /// <summary>
    /// Functor for 6 Parameters
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <typeparam name="TArg1"></typeparam>
    /// <typeparam name="TArg2"></typeparam>
    /// <typeparam name="TArg3"></typeparam>
    /// <typeparam name="TArg4"></typeparam>
    /// <typeparam name="TArg5"></typeparam>
    /// <typeparam name="TArg6"></typeparam>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <param name="arg5"></param>
    /// <param name="arg6"></param>
    /// <returns></returns>
    public delegate TResult Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);

    /// <summary>
    /// Utility class for Functors
    /// </summary>
    public static partial class FunctorHelper
    {
        /// <summary>
        /// Functor to obtain the type of an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>A functor f where f(x) returns x.GetType()</returns>
        public static Func<T, Type> GetClassType<T>()
        {
            return x => x.GetType();
        }
    }
}