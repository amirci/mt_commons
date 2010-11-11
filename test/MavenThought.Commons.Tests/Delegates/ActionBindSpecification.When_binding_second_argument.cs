using System;
using MavenThought.Commons.Delegates;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Delegates
{
    /// <summary>
    /// Test to check the Bind extension method for Algorithm
    /// </summary>
    [Specification]
    [Row(typeof(int), typeof(string))]
    [Row(typeof(DateTime), typeof(object))]
    [Row(typeof(Double), typeof(Boolean))]
    public class When_binding_second_argument<TFirst, TSecond>
        : ActionBindSpecification<TFirst, TSecond>
    {
        /// <summary>
        /// Bind the action to the second and then call with the first
        /// </summary>
        protected override void WhenIRun()
        {
            // Bind the second argument
            var bound = _action.Bind(_second);
            
            // Call the bound
            bound(_first);
        }


    }
}