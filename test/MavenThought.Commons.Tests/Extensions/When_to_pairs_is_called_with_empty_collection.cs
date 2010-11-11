using System;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when the collection is empty
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_to_pairs_is_called_with_empty_collection<T> : ToPairsSpecification<T>
    {
        /// <summary>
        /// Checks the actual collection is empty
        /// </summary>
        [It]
        public void Should_return_an_empty_collection()
        {
            Assert.IsEmpty(this.Actual);
        }

        /// <summary>
        /// Create an empty collection
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Collection = new T[] { };
        }

        /// <summary>
        /// Call ToPairs
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Collection.ToPairs();
        }
    }
}