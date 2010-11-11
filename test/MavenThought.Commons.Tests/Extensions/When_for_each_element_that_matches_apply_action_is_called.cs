using System;
using MavenThought.Commons.Extensions;
using Rhino.Mocks;
using MavenThought.Commons.Testing;


namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when for each match is called
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_for_each_element_that_matches_apply_action_is_called<T> : ForEachSpecification<T>
    {
        /// <summary>
        /// Checks the action is called
        /// </summary>
        [It]
        public void Should_call_the_action_for_each_element()
        {
            foreach (var e in this.Collection)
            {
                var local = e;

                if (this.Predicate(e))
                {
                    this.Action.AssertWasCalled(a => a(local));
                }
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
            this.Collection.ForEach(this.Predicate, this.Action);
        }
    }
}