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
    public class When_find_all_finds_elements_that_match_and_transforms<T> : FindPreviousSpecification<T>
    {
        /// <summary>
        /// Actual elements found
        /// </summary>
        private IEnumerable<int> _actual;

        /// <summary>
        /// Expected elements to be returned
        /// </summary>
        private IEnumerable<int> _expected;

        /// <summary>
        /// Collection to elements to find
        /// </summary>
        private IEnumerable<T> _elementsFound;

        /// <summary>
        /// Checks the expected elements are returned
        /// </summary>
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
            this._elementsFound = this.Collection.Where((e, i) => i % 2 == 0);

            this.Predicate = e => this._elementsFound.Contains(e);

            this._expected = this._elementsFound.Select(e => e.GetHashCode());
        }

        /// <summary>
        /// Find all the elements that match the predicate
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Collection.FindAll(this.Predicate, e => e.GetHashCode());
        }
    }
}