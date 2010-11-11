using System;
using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;


namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when slice is called with valid parameters
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_slice_is_called_with_valid_parameters<T> : SliceSpecification<T>
    {
        /// <summary>
        /// Actual value returned
        /// </summary>
        private IEnumerable<T> _actual;

        /// <summary>
        /// Min boundary to slice
        /// </summary>
        private int _minBoundary;

        /// <summary>
        /// max boundary to slice
        /// </summary>
        private int _maxBoundary;

        /// <summary>
        /// Tests that the slice operation returns the elements between start and end
        /// </summary>
        [It]
        public void Should_return_the_elements_between_min_and_max()
        {
            var expected = this.Collection.Where((e, i) => i.Between(this._minBoundary, this._maxBoundary));

            Assert.AreElementsEqual(expected, this._actual);
        }

        /// <summary>
        /// Setup min and max boundaries
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._minBoundary = 3;
            this._maxBoundary = 80;
        }

        /// <summary>
        /// Slice the collection
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Collection.Slice(this._minBoundary, this._maxBoundary);
        }
    }
}