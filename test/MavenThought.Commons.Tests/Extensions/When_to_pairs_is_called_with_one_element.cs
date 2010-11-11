using System;
using MavenThought.Commons.Extensions;
using System.Linq;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when the collection has one element
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_to_pairs_is_called_with_one_element<T> : ToPairsSpecification<T>
    {
        /// <summary>
        /// Checks the collection has one pair
        /// </summary>
        [It]
        public void Should_return_one_pair()
        {
            Assert.AreEqual(1, this.Collection.Count());
        }

        /// <summary>
        /// Checks the pair is the first element and the default value for T
        /// </summary>
        [It]
        public void Should_create_a_pair_with_the_element_and_the_default_value()
        {
            Assert.AreEqual(Pair.Make(this.Collection.First(), default(T)), this.Actual.First());
        }

        /// <summary>
        /// Setup the collection
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Collection = new RandomGenerator().GenerateCollection<T>(1);
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