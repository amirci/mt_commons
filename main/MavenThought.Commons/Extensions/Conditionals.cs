using System;

namespace MavenThought.Commons.Extensions
{
    /// <summary>
    /// Extensions with conditionals
    /// </summary>
    public static class Conditionals
    {
        /// <summary>
        /// Returns other value if the instance is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="otherValue"></param>
        /// <returns></returns>
        public static T WhenNotNull<T>(this T instance, T otherValue) where T : class
        {
            return instance.IsNull() ? instance : otherValue;
        }
    
        /// <summary>
        /// Returns the evaluation of the functor if the instance is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="otherValue"></param>
        /// <returns></returns>
        public static T WhenNotNull<T>(this T instance, Func<T> otherValue) where T : class
        {
            return instance.IsNull() ? instance : otherValue();
        }

        /// <summary>
        /// Returns the evaluation of the functor using the instance if the instance is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="otherValue"></param>
        /// <returns></returns>
        public static T WhenNotNull<T>(this T instance, Func<T, T> otherValue) where T : class
        {
            return instance.IsNull() ? instance : otherValue(instance);
        }

        /// <summary>
        /// Returns true if the value is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T instance) where T : class
        {
            return instance == null;
        }

        public static bool IsNotNull<T>(this T instance) where T : class
        {
            return !instance.IsNull();
        }
    }
}
