using System;
using System.Collections.Generic;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Base class for event subscription
    /// </summary>
    public abstract class BaseEventSubscription : IEventSubscription
    {
        /// <summary>
        /// Invoke the event
        /// </summary>
        /// <param name="event"></param>
        public abstract void Invoke(object @event);
    }
}