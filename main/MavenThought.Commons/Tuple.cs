namespace MavenThought.Commons
{
    /// <summary>
    /// Implementation of ternary tuple
    /// </summary>
    /// <typeparam name="TFirst">First type</typeparam>
    /// <typeparam name="TSecond">Second type</typeparam>
    /// <typeparam name="TThird">Third type</typeparam>
    public class Tuple<TFirst, TSecond, TThird> : ITuple<TFirst, TSecond, TThird>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tuple{TFirst,TSecond,TThird}"/> class.
        /// </summary>
        /// <param name="first">First component of the tuple</param>
        /// <param name="second">Second component of the tuple </param>
        /// <param name="third">Third component of the tuple </param>
        public Tuple(TFirst first, TSecond second, TThird third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }

        /// <summary>
        /// Gets the first element in the tuple
        /// </summary>
        public TFirst First
        {
            get; private set;
        }

        /// <summary>
        /// Gets the second element in the tuple
        /// </summary>
        public TSecond Second
        {
            get; private set;
        }

        /// <summary>
        /// Gets the third element in the tuple
        /// </summary>
        public TThird Third
        {
            get; private set;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format("Tuple(3) <{0}, {1}, {2}>", this.First, this.Second, this.Third);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="other">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><exception cref="T:System.NullReferenceException">The <paramref name="other"/> parameter is null.</exception><filterpriority>2</filterpriority>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return other is ITuple<TFirst, TSecond, TThird> && this.Equals((ITuple<TFirst, TSecond, TThird>) other);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.First.GetHashCode() ^ this.Second.GetHashCode() ^ this.Third.GetHashCode();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(ITuple<TFirst, TSecond, TThird> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(this.First, other.First) &&
                   Equals(this.Second, other.Second) &&
                   Equals(this.Third, other.Third);
        }
    }
}