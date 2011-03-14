using System;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Base interface for an event aggregator
    /// </summary>
    public interface IEventAggregator
    {
        /// <summary>
        /// Subscribe a handler to an event using an action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        IHandleEventsOfType<T> Subscribe<T>(Action<T> action) where T : IEvent;

        /// <summary>
        /// Raises an event and notified to all the subscribers
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <param name="configure">Action to configure the event</param>
        void Raise<T>(Action<T> configure) where T : IEvent;

        /// <summary>
        /// Raises an event
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        void Raise<T>() where T : IEvent;
    }
}