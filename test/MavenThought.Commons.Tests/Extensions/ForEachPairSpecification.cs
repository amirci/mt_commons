using System;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Base specification for ForEachPair
    /// </summary>
    public abstract class ForEachPairSpecification<T>
        : BaseEnumerableSpecification<T>
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