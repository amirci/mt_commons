using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests
{
    /// <summary>
    /// Specification when an element in the collection is null
    /// </summary>
    [ExceptionSpecification]
    [Row(typeof(string))]
    [Row(typeof(object))]
    public class When_assert_not_null_a_null_element<T> : AssertAreNotNullSpecification<T>
    {
        /// <summary>
        /// Checks the exception has been thrown
        /// </summary>
        [It]
        public void Should_throw_an_exception()
        {
            AssertExceptionThrown();
        }

        /// <summary>
        /// Creates a colleciton with null
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Collection = new[] { default(T) };
        }

        /// <summary>
        /// Runs the assertion
        /// </summary>
        protected override void WhenIRun()
        {
            Assert.AreNotNull(this.Collection);
        }
    }
}