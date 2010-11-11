using System;
using System.Collections.Generic;
using System.Linq;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when calculating the difference
    /// </summary>
    [Specification]
    [Row(typeof(object))]
    [Row(typeof(double))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_calculating_difference<T> : DifferenceSpecification<T>
    {
        /// <summary>
        /// Collection 1
        /// </summary>
        private IEnumerable<T> _c1;

        /// <summary>
        /// Collection 2
        /// </summary>
        private IEnumerable<T> _c2;

        /// <summary>
        /// Actual difference
        /// </summary>
        private IEnumerable<T> _actual;

        /// <summary>
        /// Checks the first 5 elements are not returned
        /// </summary>
        [It]
        public void Should_return_last_five_elements()
        {
            Assert.AreElementsEqual(this._c1.Skip(5), this._actual);
        }

        /// <summary>
        /// Setup collections
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            var random = new RandomGenerator();

            this._c1 = random.GenerateCollection<T>(10);

            this._c2 = this._c1.Take(5);

            this._c2.Concat(random.GenerateCollection<T>(5));
        }

        /// <summary>
        /// Calculate the difference
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this._c1.Difference(this._c2);
        }
    }
}