using System;
using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when ...
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_to_pairs_is_called_with_more_than_one_element<T> : ToPairsSpecification<T>
    {
        /// <summary>
        /// Expected result
        /// </summary>
        private IEnumerable<Pair<T, T>> _expected;

        /// <summary>
        /// Checks all the pairs are returned
        /// </summary>
        [It]
        public void Should_return_all_the_pairs()
        {
            Assert.AreElementsEqual(this._expected, this.Actual);
        }

        protected override void GivenThat()
        {
            base.GivenThat();

            var expected = new List<Pair<T, T>>();

            var previous = this.Collection.First();

            this.Collection.Skip(1).ForEach(e =>
                                                {
                                                    expected.Add(Pair.Make(previous, e));

                                                    previous = e;
                                                });

            this._expected = expected;
        }

        /// <summary>
        /// Call topairs
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = this.Collection.ToPairs();
        }
    }
}