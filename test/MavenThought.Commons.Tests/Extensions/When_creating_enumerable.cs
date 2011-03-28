using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when creating a collection of enumerable
    /// </summary>
    [Specification]
    public class When_creating_enumerable : BaseEnumerableSpecification<int>
    {
        /// <summary>
        /// Actual collection created
        /// </summary>
        private IEnumerable<int> _actual;

        /// <summary>
        /// Checks both collections have the same elements
        /// </summary>
        [It]
        public void Should_have_the_same_elements()
        {
            this._actual.Should().Have.SameSequenceAs(new[] { 1, 2, 3, 4, 5 });
        }

        /// <summary>
        /// Create the collection
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = Enumerable.Create(1, 2, 3, 4, 5);
        }
    }
}