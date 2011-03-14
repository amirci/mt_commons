namespace MavenThought.Commons.Tests.Extensions
{
    using System;
    using Commons.Extensions;
    using Rhino.Mocks;
    using Testing;
    using System.Linq;

    /// <summary>
    /// Specification when functor is called for matching elements
    /// </summary>
    /// <typeparam name="T">Type of the collection</typeparam>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_for_each_element_that_matches_apply_functor_is_called<T> 
        : ForEachSpecification<T>
    {
        /// <summary>
        /// Checks the functor is called
        /// </summary>
        [It]
        public void Should_call_the_functor_for_each_element()
        {
            foreach (var e in this.Collection.Where(x => this.Predicate(x)))
            {
                var local = e;

                this.Functor.AssertWasCalled(f => f(local));
            }
        }

        /// <summary>
        /// Setup a tautology
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Predicate = x => true;
        }

        /// <summary>
        /// Call the action for each element
        /// </summary>
        protected override void WhenIRun()
        {
            this.Collection.ForEach(this.Predicate, this.Functor);
        }
    }
}