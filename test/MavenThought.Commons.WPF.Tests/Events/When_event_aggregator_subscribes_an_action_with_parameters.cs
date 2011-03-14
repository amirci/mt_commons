using System;
using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Specification when subscribing an event with parameters
    /// </summary>
    [Specification]
    public class When_event_aggregator_subscribes_an_action_with_parameters 
        : EventAggregatorSpecification
    {
        /// <summary>
        /// Handler to be registered
        /// </summary>
        private IEnumerable<Action<IDontKnow>> _handlers;

        /// <summary>
        /// Checks that the handler is called
        /// </summary>
        [It]
        public void Should_call_the_handler()
        {
            var sameIdk = new Func<IDontKnow, bool>(idk => idk.Name == "Test" && idk.Id == 504);

            this._handlers
                .ForEach(h => h.AssertWasCalled(handler => handler(Arg<IDontKnow>.Matches(x => sameIdk(x)))));
        }
        
        /// <summary>
        /// Subscribes the handler
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this._handlers = 10.Times(() => Mock<Action<IDontKnow>>());

            this._handlers.ForEach(h => this.Sut.Subscribe(h));
        }
        
        /// <summary>
        /// Raise the event
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Raise<IDontKnow>(ev =>
                                           {
                                               ev.Name = "Test";
                                               ev.Id = 504;
                                           });
        }
    }
}