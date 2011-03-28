using System.Linq;
using MavenThought.Commons.WPF.Events;
using Microsoft.Practices.ServiceLocation;
using MavenThought.Commons.Testing;
using SharpTestsEx;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Specification when finding handlers that use the service locator
    /// </summary>
    [Specification]
    public class When_finding_handlers_with_service_locator : EventHandlersSpecification
    {
        /// <summary>
        /// Checks that all the handlers are found
        /// </summary>
        [It]
        public void Should_find_all_the_handlers_with_default_constructor_in_the_assembly()
        {
            this.Actual
                .Cast<ServiceLocatorEventSubscription>()
                .Select(sub => sub.HandlerType)
                .Should()
                .Have
                .SameValuesAs(new[] { typeof(MockHandler), typeof(DontKnowHandlerImpl) });
        }
        
        /// <summary>
        /// Gets the event handlers using the IoC factory
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = EventHandlers.From.CurrentAssembly().Factory(Mock<IServiceLocator>());
        }
    }
}