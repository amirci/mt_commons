using MavenThought.Commons.Testing;
using MavenThought.Commons.WPF.Events;
using SharpTestsEx;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Specification when invoking the handler in a transient subscription
    /// </summary>
    [Specification]
    public class When_transient_event_subscription_invokes_handler : TransientEventSubscriptionSpecification
    {
        /// <summary>
        /// Checks that the counter got increased
        /// </summary>
        [It]
        public void Should_call_the_handler()
        {
            MockHandler.Count.Should().Be(1);
        }

        /// <summary>
        /// Setup the count
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            MockHandler.Count = 0;
        }

        /// <summary>
        /// Create the subscription
        /// </summary>
        /// <returns></returns>
        protected override TransientEventSubscription CreateSut()
        {
            return new TransientEventSubscription(typeof(MockHandler));
        }

        /// <summary>
        /// Invoke the handler
        /// </summary>
        protected override void WhenIRun()
        {
            this.Sut.Invoke(Mock<IDontKnowEvent>());
        }
    }

    public class MockHandler : IHandleEventsOfType<IDontKnowEvent>
    {
        public static int Count { get; set; }

        /// <summary>
        /// Method to be called when the event is risen
        /// </summary>
        /// <param name="event">Event risen</param>
        public void Handle(IDontKnowEvent @event)
        {
            Count++;
        }
    }
}