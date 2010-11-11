namespace MavenThought.Commons
{
    /// <summary>
    /// Implementation of foruth-ary tuple
    /// </summary>
    /// <typeparam name="TFirst">
    /// First type
    /// </typeparam>
    /// <typeparam name="TSecond">
    /// Second type
    /// </typeparam>
    /// <typeparam name="TThird">
    /// Third type
    /// </typeparam>
    /// <typeparam name="TFourth">
    /// Fourth parameter
    /// </typeparam>
    public class Tuple<TFirst, TSecond, TThird, TFourth> : ITuple<TFirst, TSecond, TThird, TFourth>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tuple{TFirst,TSecond,TThird,TFourth}"/> class.
        /// </summary>
        /// <param name="first">
        /// The first. 
        /// </param>
        /// <param name="second">
        /// The second. 
        /// </param>
        /// <param name="third">
        /// The third. 
        /// </param>
        /// <param name="fourth">
        /// The fourth. 
        /// </param>
        public Tuple(TFirst first, TSecond second, TThird third, TFourth fourth)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
            this.Fourth = fourth;
        }

        /// <summary>
        /// Gets the first element in the tuple
        /// </summary>
        public TFirst First { get; private set; }

        /// <summary>
        /// Gets the second element in the tuple
        /// </summary>
        public TSecond Second { get; private set; }

        /// <summary>
        /// Gets the third element in the tuple
        /// </summary>
        public TThird Third { get; private set; }

        /// <summary>
        /// Gets the forth element in the tuple
        /// </summary>
        public TFourth Fourth { get; private set; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">
        /// An object to compare with this object.
        /// </param>
        public bool Equals(ITuple<TFirst, TSecond, TThird, TFourth> other)
        {
            if (this == other)
            {
                return true;
            }

            return Equals(this.First, other.First) &&
                   Equals(this.Second, other.Second) &&
                   Equals(this.Third, other.Third) &&
                   Equals(this.Fourth, other.Fourth);
        }
    }
}