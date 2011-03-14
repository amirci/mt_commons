using System;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when find does not find an element
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_find_does_not_find_a_match<T> : FindSpecification<T>
    {
        /// <summary>
        /// Checks that the element returned is the expected
        /// </summary>
        [It]
        public void Should_return_the_default_value_for_the_type()
        {
            Assert.AreEqual(default(T), this.Actual);
        }

        /// <summary>
        /// Setup to a predicate that finds the element
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Predicate = x => false;
        }
    }
}