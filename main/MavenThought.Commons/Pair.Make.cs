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
    }
}