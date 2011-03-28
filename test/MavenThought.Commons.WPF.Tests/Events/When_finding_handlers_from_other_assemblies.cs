using System.Linq;
using MavenThought.Commons.Testing;
using MavenThought.Commons.WPF.DummyData;
using MavenThought.Commons.WPF.Events;
using SharpTestsEx;

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
        /// Checks that all the handlers are found
        /// </summary>
        [It]
        public void Should_find_all_the_handlers_with_default_constructor_in_the_assembly()
        {
            this.Actual
                .Select(sub => sub.Target)
                .Should()
                .Have
                .SameSequenceAs(new[] { typeof(DummyEventHandler) });
        }
        
        /// <summary>
        /// Get the handlers in the assembly
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = EventHandlers.From.AssemblyOf<IDummyEvent>();
        }
    }
}