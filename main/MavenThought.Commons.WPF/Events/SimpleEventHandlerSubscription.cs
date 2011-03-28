using System;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Simple event handler subscription
    /// </summary>
    public class SimpleEventHandlerSubscription : IEventHandlerSubscription
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SimpleEventHandlerSubscription"/> class.
        /// </summary>
        /// <param name="type">Type to subscribe</param>
        public SimpleEventHandlerSubscription(Type type)
        {
            this.Target = type;
        }

        /// <summary>
        /// Gets the target of the registration
        /// </summary>
        public Type Target { get; private set; }
    }
}