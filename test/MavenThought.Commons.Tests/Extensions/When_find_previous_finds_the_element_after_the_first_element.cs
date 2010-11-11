using MavenThought.Commons.Testing;


namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when the element found is after the first element
    /// </summary>
    [Specification]
    public class When_find_previous_finds_the_element_after_the_first_element 
        : FindPreviousSpecification<int>
    {
        /// <summary>
        /// Checks is not null
        /// </summary>
        [It]
        public void Should_not_be_null()
        {
            Assert.IsNotNull(this.Actual);
        }

        /// <summary>
        /// Checks that the Pair returned is a subsequence of the collection
        /// </summary>
        [It]
        public void Should_return_a_subsequence_of_the_collection()
        {
            Assert.Includes(this.Collection, new[] { this.Actual.First, this.Actual.Second });
        }

        /// <summary>
        /// Checks that the first element in the pair does not match the predicate
        /// </summary>
        [It]
        public void Should_return_a_first_element_that_does_not_match_the_predicate()
        {
            Assert.IsFalse(this.Predicate(this.Actual.First));
        }

        /// <summary>
        /// Checks that the secodn element in the pair matches the predicate
        /// </summary>
        [It]
        public void Should_return_a_second_element_that_matches_the_predicate()
        {
            Assert.IsTrue(this.Predicate(this.Actual.Second));
        }

        /// <summary>
        /// Checks that no other element matches the predicate
        /// </summary>
        [It]
        public void Should_return_the_first_element_that_matches_the_predicate()
        {
            Assert.AreEqual(new Pair<int, int>(3, 5), this.Actual);
        }

        /// <summary>
        /// Fill the collection
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Collection = new[] { 1, 3, 5, 8, 11, 10 };

            this.Predicate = x => x % 5 == 0;
        }
    }
}