using MavenThought.Commons.WPF.Events;

namespace MavenThought.Commons.WPF.DummyData
{
    public abstract class DummyEventHandlerBase
    {
        /// <summary>
        /// Method to be called when the event is risen
        /// </summary>
        /// <param name="event">Event risen</param>
        public void Handle(IDummyEvent @event)
        {
        }
    }

    /// <summary>
    /// Handler for tests
    /// </summary>
    public class DummyEventHandler : DummyEventHandlerBase, IHandleEventsOfType<IDummyEvent>
    {
    }
}
