using System;
using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.WPF.Events;
using MbUnit.Framework;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Specification when subscribing an action
    /// </summary>
    [Specification]
    public class When_event_aggregator_subscribes_an_action : EventAggregatorSpecification
    {
        /// <summary>
        /// Handler to be registered
        /// </summary>
        private IEnumerable<Action<IEvent>> _handlers;

        /// <summary>
        /// Checks that the handler is called
        /// </summary>
        [Test]
        public void Should_call_the_handler()
        {
            this._handlers
                .ForEach(h => h.AssertWasCalled(handler => handler(Arg<IEvent>.Is.Anything)));
        }

        /// <summary>
        /// Setup the handler
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._handlers = 10.Times(() => Mock<Action<IEvent>>());
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
        /// Raises the event to call the handler
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Raise<IEvent>();
        }
    }
}