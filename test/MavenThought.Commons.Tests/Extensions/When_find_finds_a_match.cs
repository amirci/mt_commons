using System;
using System.Linq;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when find has a match
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_find_finds_a_match<T> : FindSpecification<T>
    {
        /// <summary>
        /// Checks that the element returned is the expected
        /// </summary>
        [It]
        public void Should_return_the_element_found()
        {
            Assert.AreEqual(this.Collection.ElementAt(3), this.Actual);
        }

        /// <summary>
        /// Setup to a predicate that finds the element
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Predicate = x => Equals(x, this.Collection.ElementAt(3));
        }
    }
}