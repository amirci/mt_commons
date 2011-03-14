using System;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Base specification for Times
    /// </summary>
    public abstract class TimesSpecification<T>
        : BaseEnumerableSpecification<T>    
    {
        /// <summary>
        /// Gets the action to use
        /// </summary>
        protected Action Action { get; private set; }

        /// <summary>
        /// Gets the functor to use
        /// </summary>
        protected Func<T> Functor { get; private set; }

        /// <summary>
        /// Gets the amount to use
        /// </summary>
        protected int Amount { get; private set; }

        /// <summary>
        /// Setup action
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Action = MockIt(this.Action);

            this.Functor = MockIt(this.Functor);

            this.Amount = 20;
        }
    }
}