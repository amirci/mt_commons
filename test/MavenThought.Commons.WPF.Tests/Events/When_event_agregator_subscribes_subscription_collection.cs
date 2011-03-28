using System.Collections.Generic;
using MavenThought.Commons.Extensions;
using MavenThought.Commons.WPF.Events;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Specification when registering subscriptions
    /// </summary>
    [Specification]
    public class When_event_agregator_subscribes_subscription_collection : EventAggregatorSpecification
    {
        /// <summary>
        /// Subscriptions used
        /// </summary>
        private IEnumerable<IEventSubscription> _subscriptions;

        /// <summary>
        /// Checks that all the subscriptions are called
        /// </summary>
        [It]
        public void Should_call_all_the_subscriptions()
        {
            _subscriptions.ForEach(s => s.AssertWasCalled(sub => sub.Invoke(Arg<object>.Matches(ev => ev is IDontKnowEvent))));
        }

        /// <summary>
        /// Subscribes the handler
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this._subscriptions = 10.Times(() => Mock<IEventSubscription>());

            this.Sut.Subscribe(this._subscriptions);
        }

        /// <summary>
        /// Raise the event
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Raise<IDontKnowEvent>();
        }
    }
}