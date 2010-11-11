using System;

namespace MavenThought.Commons
{
    /// <summary>
    /// Pair of elements
    /// </summary>
    /// <typeparam name="TFirst">First Element of the Pair</typeparam>
    /// <typeparam name="TSecond">Second element in the pair</typeparam>
    public interface IPair<TFirst, TSecond> : IEquatable<IPair<TFirst, TSecond>>
    {
        /// <summary>
        /// Gets the first element in the pair
        /// </summary>
        TFirst First { get; }

        /// <summary>
        /// Gets the second element in the pair
        /// </summary>
        TSecond Second { get; }
    }
}