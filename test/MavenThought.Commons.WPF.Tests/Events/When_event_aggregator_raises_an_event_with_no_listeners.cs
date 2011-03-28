using System;
using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.WPF.Events;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Specification when an event no on is listening to is raised
    /// </summary>
    [Specification]
    public class When_event_aggregator_raises_an_event_with_no_listeners : EventAggregatorSpecification
    {
        /// <summary>
        /// Handler to be registered
        /// </summary>
        private IEnumerable<Action<IDontKnowEvent>> _handlers;

        /// <summary>
        /// Checks that the handler is not called
        /// </summary>
        [It]
        public void Should_not_call_the_handler()
        {
            this._handlers
                .ForEach(h => h.AssertWasNotCalled(handler => handler(Arg<IDontKnowEvent>.Is.Anything)));
        }

        /// <summary>
        /// Setup the handler
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._handlers = 10.Times(() => Mock<Action<IDontKnowEvent>>());
        }

        /// <summary>
        /// Subscribes the handler
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this._handlers.ForEach(h => this.Sut.Subscribe(h));
        }        
        
        /// <summary>
        /// Raise the event
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Raise<IEvent>();
        }
    }
}