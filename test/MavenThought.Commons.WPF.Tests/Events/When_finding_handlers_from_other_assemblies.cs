using MavenThought.Commons.Testing;
using MavenThought.Commons.WPF.Events;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Specification when finding registrations in other assemblies
    /// </summary>
    [Specification]
    public class When_finding_handlers_from_other_assemblies 
        : EventHandlersSpecification
    {
        /// <summary>
        /// Get the handlers in the assembly
        /// </summary>
        protected override void WhenIRun()
        {
            base.WhenIRun();

            this.Actual = EventHandlers.From.AssemblyOf<IDontKnow>();
        }
    }
}