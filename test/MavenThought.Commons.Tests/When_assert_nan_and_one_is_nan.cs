using Gallio.Framework.Assertions;
using MavenThought.Commons.Testing;
using MbUnit.Framework;
using Assert = MavenThought.Commons.Testing.Assert;

namespace MavenThought.Commons.Tests
{
    /// <summary>
    /// Specification when one number is NaN
    /// </summary>
    [ExceptionSpecification]
    public class When_assert_nan_and_one_is_nan : CollectionAssertSpecification<double>
    {
        /// <summary>
        /// Checks the exception is thrown
        /// </summary>
        [Test]
        public void Should_throw_an_assert_exception()
        {
            Assert.IsInstanceOfType<AssertionFailureException>(this.ExceptionThrown);
        }

        /// <summary>
        /// Setup the collection with one NaN
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Collection = new[] { 1.0, double.NaN, 3, 8 };
        }

        /// <summary>
        /// Check not NaN
        /// </summary>
        protected override void WhenIRun()
        {
            Assert.AreNotNaN(this.Collection);
        }
    }
}