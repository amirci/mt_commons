using System.Collections.Generic;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests
{
    /// <summary>
    /// Test for assert are not null
    /// </summary>
    /// <typeparam name="T">Type of the collection</typeparam>
    public abstract class AssertAreNotNullSpecification<T> : BaseSpecification
    {
        /// <summary>
        /// Gets or sets the collection to use
        /// </summary>
        protected IEnumerable<T> Collection { get; set; }
    }
}