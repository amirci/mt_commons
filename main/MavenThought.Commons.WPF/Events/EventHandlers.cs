namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Base class to provide fluid interface to find handlers
    /// </summary>
    public static class EventHandlers
    {
        /// <summary>
        /// Returns the source to get event handlers
        /// </summary>
        public static IEventHandlerSource From
        {
            get { return new EventHandlerSource(); }
        }
    }
}