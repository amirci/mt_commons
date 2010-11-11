using System;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.Testing;
using Rhino.Mocks;


namespace MavenThought.Commons.Tests.Extensions
{
    /// <summary>
    /// Specification when for each is called with a functor
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_for_each_element_apply_functor_is_called<T> : ForEachSpecification<T>
    {
        /// <summary>
        /// Checks the functor is called
        /// </summary>
        [It]
        public void Should_call_the_functor_for_each_element()
        {
            foreach (var e in this.Collection)
            {
                var local = e;

                this.Functor.AssertWasCalled(f => f(local));
            }
        }

        /// <summary>
        /// Call the action for each element
        /// </summary>
        protected override void WhenIRun()
        {
            this.Collection.ForEach(this.Functor);
        }
    }
}