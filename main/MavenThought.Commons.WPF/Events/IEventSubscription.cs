namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Registration of an event handler
    /// </summary>
    public interface IEventSubscription
    {
        /// <summary>
        /// Invoke the event
        /// </summary>
        /// <param name="event">Event to notify</param>
        void Invoke(object @event);
    }
}