namespace MavenThought.Commons.WPF.Tests.Events
{
    public abstract class AbstractDontKnowHandler : IDontKnowHandler
    {
        /// <summary>
        /// Method to be called when the event is risen
        /// </summary>
        /// <param name="event">Event risen</param>
        public void Handle(IDontKnow @event)
        {
        }
    }
}