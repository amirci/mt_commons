using MavenThought.Commons.WPF.Events;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Event to use
    /// </summary>
    public interface IDontKnow : IEvent
    {
        string Name { get; set; }

        int Id { get; set; }
    }
}