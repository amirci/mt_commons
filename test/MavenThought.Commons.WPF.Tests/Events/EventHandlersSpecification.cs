using System.Collections.Generic;
using MavenThought.Commons.Testing;
using MavenThought.Commons.WPF.Events;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Base specification for EventHandlerRegistration
    /// </summary>
    public abstract class EventHandlersSpecification
        : BaseSpecification
    {
        protected IEnumerable<IEventSubscription> Actual { get; set; }
    }
}