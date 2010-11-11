using System;
using MavenThought.Commons.Extensions;
using Rhino.Mocks;
using MavenThought.Commons.Testing;


namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when times is called with an action
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_times_is_called_with_an_action<T> : TimesSpecification<T>
    {
        /// <summary>
        /// Checks the action is called X amount of times
        /// </summary>
        [It]
        public void Should_call_the_action_the_amount_of_times_specified()
        {
            this.Action.VerifyAllExpectations();
        }

        protected override void GivenThat()
        {
            base.GivenThat();

            this.Action.Expect(a => a()).Repeat.Times(this.Amount);
        }

        /// <summary>
        /// Call times with a function
        /// </summary>
        protected override void WhenIRun()
        {
            this.Amount.Times(this.Action);
        }
    }
}