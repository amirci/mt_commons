using System;
using MavenThought.Commons.WPF.Events;
using Microsoft.Practices.ServiceLocation;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Specification when invoking the handler
    /// </summary>
    [Specification]
    public class When_service_locator_event_subscription_invokes_handler 
        : ServiceLocatorEventSubscriptionSpecification
    {
        /// <summary>
        /// Handler for the event
        /// </summary>
        private IHandleEventsOfType<IDontKnowEvent> _handler;

        /// <summary>
        /// Checks that the handler from the service locator is called
        /// </summary>
        [It]
        public void Should_call_the_handler_returned_by_the_service_locator()
        {
            this._handler.AssertWasCalled(h => h.Handle(Dep<IDontKnowEvent>()));
        }

        /// <summary>
        /// Setup the service locator
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._handler = MockIt(this._handler);

            Dep<IServiceLocator>()
                .Stub(sl => sl.GetInstance(this._handler.GetType()))
                .Return(this._handler);
        }

        protected override ServiceLocatorEventSubscription CreateSut()
        {
            return new ServiceLocatorEventSubscription(this._handler.GetType(), Dep<IServiceLocator>());
        }

        /// <summary>
        /// Invoke the handler
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Invoke(Dep<IDontKnowEvent>());
        }
    }
}