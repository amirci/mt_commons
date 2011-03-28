namespace MavenThought.Commons.WPF.Events
{
    public interface IFromEventHandlerSource
    {
        /// <summary>
        /// Gets the source from event handlers
        /// </summary>
        IEventHandlerSource From { get; }
    }
}