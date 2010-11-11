using System;
using System.Collections.Generic;
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
    public class When_times_is_called_with_a_functor<T> : TimesSpecification<T>
    {
        /// <summary>
        /// Actual value obtained
        /// </summary>
        private IEnumerable<T> _actual;

        /// <summary>
        /// Checks the functor is called X amount of times
        /// </summary>
        [It]
        public void Should_call_the_functor_the_amount_of_times_specified()
        {
            this.Action.VerifyAllExpectations();
        }

        /// <summary>
        /// Checks the collection obtained
        /// </summary>
        [It]
        public void Should_return_the_collection_of_the_result_of_the_functor()
        {
            Assert.ForAll(this._actual, e => Equals(e, default(T)));
        }

        /// <summary>
        /// Add expected for the functor
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Functor
                .Expect(a => a())
                .Return(default(T))
                .Repeat.Times(this.Amount);
        }

        /// <summary>
        /// Call times with a function
        /// </summary>
        protected override void WhenIRun()
        {
            this._actual = this.Amount.Times(this.Functor);
        }
    }
}