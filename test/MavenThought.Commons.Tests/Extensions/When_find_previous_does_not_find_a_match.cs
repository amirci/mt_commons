using MavenThought.Commons.Testing;


namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when the element cannot be found
    /// </summary>
    [Specification]
    public class When_find_previous_does_not_find_a_match : FindPreviousSpecification<int>
    {
        /// <summary>
        /// Checks that returns null when element is not found
        /// </summary>
        [It]
        public void Should_return_null()
        {
            Assert.IsNull(this.Actual);
        }

        /// <summary>
        /// Fill the collection
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Collection = new[] { 1, 3, 5, 8 };

            this.Predicate = x => x > 10;
        }
    }
}