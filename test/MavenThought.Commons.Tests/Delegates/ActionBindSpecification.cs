using System;
using MavenThought.Commons.Testing;
using Rhino.Mocks;

namespace MavenThought.Commons.Tests.Delegates
{
    /// <summary>
    /// Base specification for bind
    /// </summary>
    /// <typeparam name="TFirst">Type of the first argument</typeparam>
    /// <typeparam name="TSecond">Type of the second argument</typeparam>
    public abstract class ActionBindSpecification<TFirst, TSecond>: BaseSpecification
    {
        /// <summary>
        /// Action to call
        /// </summary>
        protected readonly Action<TFirst, TSecond> _action = Mock<Action<TFirst, TSecond>>();

        /// <summary>
        /// First argument
        /// </summary>
        protected TFirst _first ;
        
        /// <summary>
        /// Second argument
        /// </summary>
        protected TSecond _second ;

        /// <summary>
        /// The action should be called with first and second
        /// </summary>
        [It]
        [MbUnit.Framework.Ignore]
        public void Should_be_called_with_first_and_second()
        {
            //_action.AssertWasCalled(a => a(_first, _second));
        }

    }
}