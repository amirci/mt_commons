using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when calculating the difference
    /// </summary>
    [Specification]
    public class When_calculating_difference_with_predicate : DifferenceSpecification<When_calculating_difference_with_predicate.IBase>
    {
        /// <summary>
        /// Collection 1
        /// </summary>
        private IEnumerable<IBase> _c1;

        /// <summary>
        /// Collection 2
        /// </summary>
        private IEnumerable<IBase> _c2;

        /// <summary>
        /// Actual difference
        /// </summary>
        private IEnumerable<IBase> _actual;

        /// <summary>
        /// 
        /// </summary>
        public interface IBase
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public interface IDerived1 : IBase
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public interface IDerived2 : IBase
        {
        }

        /// <summary>
        /// Checks the first 5 elements are not returned
        /// </summary>
        [It]
        public void Should_return_last_five_elements()
        {
            this._actual.ForEach(Assert.IsInstanceOfType<IDerived2>);
        }

        /// <summary>
        /// Setup collections
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._c1 = new[] { Mock<IDerived1>() };

            this._c2 = new IBase[] { Mock<IDerived1>(), Mock<IDerived2>() };
        }

        /// <summary>
        /// Calculate the difference
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this._c1.Difference(this._c2, (e1, e2) => e1.GetType() == e2.GetType());
        }
    }
}