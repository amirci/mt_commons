namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Handler for particular events
    /// </summary>
    /// <typeparam name="T">Type of the event</typeparam>
    public interface IHandleEventsOfType<in T> where T : IEvent
    {
        /// <summary>
        /// Method to be called when the event is risen
        /// </summary>
        /// <param name="event">Event risen</param>
        void Handle(T @event);
    }
}