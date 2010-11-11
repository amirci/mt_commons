namespace MavenThought.Commons
{
    /// <summary>
    /// Implementation of IPair
    /// </summary>
    /// <typeparam name="TFirst">First element type</typeparam>
    /// <typeparam name="TSecond">Second element type</typeparam>
    public class Pair<TFirst, TSecond> : IPair<TFirst, TSecond>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pair{TFirst,TSecond}"/> class. 
        /// </summary>
        /// <param name="first">
        /// First argument
        /// </param>
        /// <param name="second">
        /// Second argument
        /// </param>
        public Pair(TFirst first, TSecond second)
        {
            this.First = first;
            this.Second = second;
        }

        /// <summary>
        /// Gets the first element in the pair
        /// </summary>
        public TFirst First { get; private set; }

        /// <summary>
        /// Gets the second element in the pair
        /// </summary>
        public TSecond Second { get; private set; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(IPair<TFirst, TSecond> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.First, First) && Equals(other.Second, Second);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param><exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is IPair<TFirst, TSecond> && Equals((IPair<TFirst, TSecond>) obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                return (First.GetHashCode()*397) ^ Second.GetHashCode();
            }
        }
    }
}