using System;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Simple event handler subscription that creates the instance
    /// to handle the event when called
    /// </summary>
    public class TransientEventSubscription : BaseEventSubscription
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TransientEventSubscription"/> class.
        /// </summary>
        /// <param name="handlerType">Type of the handler to be instantiated</param>
        public TransientEventSubscription(Type handlerType)
        {
            this.HandlerType = handlerType;
        }

        /// <summary>
        /// Gets the type of the handler
        /// </summary>
        public Type HandlerType { get; private set; }

        /// <summary>
        /// Invoke the event
        /// </summary>
        /// <param name="event"></param>
        public override void Invoke(object @event)
        {
            // If can't tell the type of the event, return
            if (@event == null)
            {
                return;
            }

            var handler = Activator.CreateInstance(this.HandlerType);

            var method = this.HandlerType.GetMethod("Handle", new[] {@event.GetType()});

            if (method != null)
            {
                method.Invoke(handler, new[] {@event});
            }
        }
    }
}