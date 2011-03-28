using MavenThought.Commons.Testing;
using MavenThought.Commons.WPF.Events;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Base specification for TransientEventSubscription
    /// </summary>
    public abstract class TransientEventSubscriptionSpecification
        : AutoMockSpecificationWithNoContract<TransientEventSubscription>
    {
    }
}