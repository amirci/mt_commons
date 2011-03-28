using System;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Subscription with an action
    /// </summary>
    /// <typeparam name="T">Type of the event</typeparam>
    internal class ActionEventSubscription<T> : BaseEventSubscription where T : IEvent
    {
        /// <summary>
        /// Handler to call
        /// </summary>
        private readonly Action<T> _handler;

        /// <summary>
        /// Initializes a 
        /// </summary>
        /// <param name="handler"></param>
        public ActionEventSubscription(Action<T> handler)
        {
            this._handler = handler;
        }

        /// <summary>
        /// Invoke the event
        /// </summary>
        /// <param name="event"></param>
        public override void Invoke(object @event)
        {
            if (@event is T)
            {
                this._handler((T)@event);
            }
        }
    }
}