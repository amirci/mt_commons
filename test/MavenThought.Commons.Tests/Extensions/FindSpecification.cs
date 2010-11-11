using MavenThought.Commons.Extensions;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Base specification for Find
    /// </summary>
    public abstract class FindSpecification<T>
        : BaseEnumerableSpecification<T>
    {
        /// <summary>
        /// Gets or sets the actual value
        /// </summary>
        protected T Actual { get; set; }

        /// <summary>
        /// Find the item in the collection
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Collection.Find(this.Predicate);
        }
    }
}