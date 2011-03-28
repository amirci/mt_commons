using MavenThought.Commons.Testing;
using MavenThought.Commons.WPF.Events;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Base specification for ServiceLocatorEventSubscription
    /// </summary>
    public abstract class ServiceLocatorEventSubscriptionSpecification
        : AutoMockSpecificationWithNoContract<ServiceLocatorEventSubscription>
    {
    }
}