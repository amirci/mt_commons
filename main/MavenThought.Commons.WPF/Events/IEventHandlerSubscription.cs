using System;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Registration of an event handler
    /// </summary>
    public interface IEventHandlerSubscription
    {
        /// <summary>
        /// Target of the registration
        /// </summary>
        Type Target { get; }
    }
}