using System;

namespace MavenThought.Commons
{
    /// <summary>
    /// Tuple with four members
    /// </summary>
    /// <typeparam name="TFirst">First type</typeparam>
    /// <typeparam name="TSecond">Second type</typeparam>
    /// <typeparam name="TThird">Third type</typeparam>
    /// <typeparam name="TFourth">Fourth type</typeparam>
    public interface ITuple<TFirst, TSecond, TThird, TFourth> : IEquatable<ITuple<TFirst, TSecond, TThird, TFourth>>
    {
        /// <summary>
        /// Gets the first element in the tuple
        /// </summary>
        TFirst First { get; }

        /// <summary>
        /// Gets the second element in the tuple
        /// </summary>
        TSecond Second { get; }

        /// <summary>
        /// Gets the third element in the tuple
        /// </summary>
        TThird Third { get; }

        /// <summary>
        /// Gets the forth element in the tuple
        /// </summary>
        TFourth Fourth { get; }       
    }
}