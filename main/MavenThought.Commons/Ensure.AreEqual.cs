namespace MavenThought.Commons
{
    partial class Ensure
    {
        /// <summary>
        /// Ensures that two objets are equal specifying a message
        /// </summary>
        /// <typeparam name="T">Type of the objects</typeparam>
        /// <param name="first">First argument</param>
        /// <param name="second">Second argument</param>
        /// <param name="msg">Message to use</param>
        /// <param name="args">Arguments for the string format</param>
        public static void AreEqual<T>(T first, T second, string msg, params object[] args)
        {
            IsTrue(Equals(first, second), msg, args);
        }

        /// <summary>
        /// Ensures that two objects are equal
        /// </summary>
        /// <typeparam name="T">Type of the objects</typeparam>
        /// <param name="first">First argument</param>
        /// <param name="second">Second argument</param>
        public static void AreEqual<T>(T first, T second)
        {
            AreEqual(first, second, "The objects are not equal");
        }
    }
}
