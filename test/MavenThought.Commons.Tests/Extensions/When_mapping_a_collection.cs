using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when converting using a map
    /// </summary>
    [Specification]
    public class When_mapping_a_collection<T> : MapSpecification<T>
    {
        /// <summary>
        /// Actual value obtained
        /// </summary>
        private IDictionary<T, string> _actual;

        /// <summary>
        /// Checks the collection is the keys
        /// </summary>
        [It]
        public void Should_return_the_same_keys()
        {
            Assert.AreElementsEqual(this.Collection, this._actual.Keys);
        }

        /// <summary>
        /// Checks the values are the conversion to string
        /// </summary>
        [It]
        public void Should_return_the_values_as_string()
        {
            Assert.ForAll(this.Collection, e => this._actual[e] == e.ToString());
        }

        /// <summary>
        /// Convert the collection to a map
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Collection.Map(x => x.ToString());
        }
    }
}