using System;
using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when find all finds elements that match
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_find_all_finds_elements_that_match<T> : FindPreviousSpecification<T>
    {
        /// <summary>
        /// Actual elements found
        /// </summary>
        private IEnumerable<T> _actual;

        /// <summary>
        /// Expected elements to be returned
        /// </summary>
        private IEnumerable<T> _expected;

        [It]
        public void Should_return_the_expected_elements()
        {
            Assert.AreElementsEqual(this._expected, this._actual);
        }

        /// <summary>
        /// Setup the expected elements
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            // Select all the elements in even positions
            this._expected = this.Collection.Where((e, i) => i % 2 == 0);

            this.Predicate = e => this._expected.Contains(e);
        }

        /// <summary>
        /// Find all the elements that match the predicate
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Collection.FindAll(this.Predicate);
        }
    }
}