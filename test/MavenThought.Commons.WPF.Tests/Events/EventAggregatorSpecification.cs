using MavenThought.Commons.Testing;
using MavenThought.Commons.WPF.Events;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Base specification for EventAggregator
    /// </summary>
    public abstract class EventAggregatorSpecification
        : AutoMockSpecification<EventAggregator, IEventAggregator>
    {
    }   
}