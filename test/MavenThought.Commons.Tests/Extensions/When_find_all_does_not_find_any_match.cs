using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when ...
    /// </summary>
    /// <typeparam name="T">Type of the collection</typeparam>
    [Specification]
    public class When_find_all_does_not_find_any_match<T> : FindAllSpecification<T>
    {
        /// <summary>
        /// Actual values obtained
        /// </summary>
        private IEnumerable<T> _actual;

        /// <summary>
        /// Checks the result is an empty collection
        /// </summary>
        [ItShould]
        public void Should_return_an_empty_collection()
        {
            Assert.IsEmpty(this._actual);
        }

        /// <summary>
        /// Setup the predicate to fail for every element
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Predicate = x => false;
        }

        /// <summary>
        /// Findall the elements
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Collection.FindAll(this.Predicate);
        }
    }
}