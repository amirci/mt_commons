using System;
using MavenThought.Commons.Delegates;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Delegates
{
    /// <summary>
    /// Specification for binding the first argument
    /// </summary>
    /// <typeparam name="TFirst">Type of the first argument</typeparam>
    /// <typeparam name="TSecond">Type of the second argument</typeparam>
    [Specification]
    [Row(typeof (int), typeof (string))]
    [Row(typeof (DateTime), typeof (object))]
    [Row(typeof (Double), typeof (Boolean))]
    public class When_binding_first_argument<TFirst, TSecond>
        : ActionBindSpecification<TFirst, TSecond>
    {
        /// <summary>
        /// Bind with the first and call with the second
        /// </summary>
        protected override void WhenIRun()
        {
            // Bind it
            var bound = _action.Bind(_first);
            
            // call the bound
            bound(_second);
        }
    }
}