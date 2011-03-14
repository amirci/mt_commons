using System;

namespace MavenThought.Commons
{
    /// <summary>
    /// Exception to throw when ensure is not value
    /// </summary>
    public class EnsureException : Exception
    {
        /// <summary>
        /// Constructor using a message
        /// </summary>
        /// <param name="message">Message to use for the exception</param>
        public EnsureException(string message)
            : base(message)
        {
        }
    }
}