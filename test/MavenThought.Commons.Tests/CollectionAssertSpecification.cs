using System.Collections.Generic;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests
{
    /// <summary>
    /// Base specification for Assert
    /// </summary>
    public abstract class CollectionAssertSpecification<T>
        : BaseSpecification
    {
        /// <summary>
        /// Gets or sets the collection to use in the specification
        /// </summary>
        protected IEnumerable<T> Collection { get; set; }

        /// <summary>
        /// Setup the collection
        /// </summary>
        protected override void GivenThat()
        {
            this.Collection = new RandomGenerator().GenerateCollection<T>(100);
        }
    }
}