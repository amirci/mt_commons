using MavenThought.Commons.WPF.Events;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Event to use
    /// </summary>
    public interface IDontKnowEvent : IEvent
    {
        string Name { get; set; }

        int Id { get; set; }
    }
}