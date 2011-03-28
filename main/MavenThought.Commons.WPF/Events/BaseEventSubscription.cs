using System;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Base class for event subscription
    /// </summary>
    public abstract class BaseEventSubscription : IEventSubscription
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BaseEventSubscription"/> class
        /// </summary>
        /// <param name="handlerType">Type of the handler to call</param>
        protected BaseEventSubscription(Type handlerType)
        {
            this.HandlerType = handlerType;
        }

        /// <summary>
        /// Gets the type of the handler found for the subscription
        /// </summary>
        public Type HandlerType { get; private set; }

        /// <summary>
        /// Invoke the event
        /// </summary>
        /// <param name="event"></param>
        public virtual void Invoke(object @event)
        {
            // If can't tell the type of the event, return
            if (@event == null)
            {
                return;
            }

            var handler = CreateHandler();

            var method = this.HandlerType.GetMethod("Handle", new[] {@event.GetType()});

            if (method != null)
            {
                method.Invoke(handler, new[] {@event});
            }
        }

        /// <summary>
        /// Creates the instance of the handler
        /// </summary>
        /// <returns>Instance of the handler to use</returns>
        protected abstract object CreateHandler();
    }
}