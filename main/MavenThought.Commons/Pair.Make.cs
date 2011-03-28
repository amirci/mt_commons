namespace MavenThought.Commons
{
    /// <summary>
    /// Pair static methods
    /// </summary>
    public static class Pair
    {
        /// <summary>
        /// Create a pair from first second
        /// </summary>
        /// <typeparam name="TFirst">Type of the first member</typeparam>
        /// <typeparam name="TSecond">Type of the second member</typeparam>
        /// <param name="first">First member value</param>
        /// <param name="second">Second member value</param>
        /// <returns>A new instance of the pair</returns>
        public static Pair<TFirst, TSecond> Make<TFirst, TSecond>(TFirst first, TSecond second)
        {
            return new Pair<TFirst, TSecond>(first, second);
        }

        /// <summary>
        /// Creates the pair first x null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <returns></returns>
        public static IPair<T, T> MakeFirst<T>(T first)
        {
            return Make(first, default(T));
        }

        /// <summary>
        /// Creates the pair null x second
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IPair<T, T> MakeSecond<T>(T second)
        {
            return Make(default(T), second);
        }
    }
}