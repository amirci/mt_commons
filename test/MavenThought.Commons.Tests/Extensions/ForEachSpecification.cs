using System;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Test for the ForEach extension to collection
    /// </summary>
    /// <typeparam name="T">Type of the collection</typeparam>
    public abstract class ForEachSpecification<T> : BaseEnumerableSpecification<T>
    {
        /// <summary>
        /// Gets the action to use
        /// </summary>
        protected Action<T> Action { get; private set; }

        /// <summary>
        /// Gets the functor to use
        /// </summary>
        protected Func<T, T> Functor { get; private set; }

        /// <summary>
        /// Setup action
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Action = MockIt(this.Action);

            this.Functor = MockIt(this.Functor);
        }
    }
}