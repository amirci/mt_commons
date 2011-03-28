using System;
using MavenThought.Commons.WPF.Events;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Handles events of IDontKnow
    /// </summary>
    public interface IDontKnowHandler : IHandleEventsOfType<IDontKnow>
    {
        
    }
}