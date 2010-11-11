using MavenThought.Commons.Extensions;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Base specification for FindPrevious
    /// </summary>
    /// <typeparam name="T">Type of the element to find</typeparam>
    public abstract class FindPreviousSpecification<T>
        : BaseEnumerableSpecification<T>
    {
        /// <summary>
        /// Gets or sets the actual result obtained from FindPrevious
        /// </summary>
        protected IPair<T, T> Actual { get; set; }

        /// <summary>
        /// Find the previous element
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Collection.FindPrevious(this.Predicate);
        }
    }
}