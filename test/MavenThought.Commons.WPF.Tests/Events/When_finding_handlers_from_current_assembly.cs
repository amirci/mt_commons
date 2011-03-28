using System.Linq;
using MavenThought.Commons.Testing;
using MavenThought.Commons.WPF.Events;
using SharpTestsEx;

namespace MavenThought.Commons.WPF.Tests.Events
{
    /// <summary>
    /// Specification when getting handlers from current assembly
    /// </summary>
    [Specification]
    public class When_finding_handlers_from_current_assembly 
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
                .SameSequenceAs(new[] {typeof (DontKnowHandlerImpl)});
        }

        /// <summary>
        /// Gets the handlers from current assembly
        /// </summary>
        protected override void WhenIRun()
        {
            this.Actual = EventHandlers.From.CurrentAssembly();
        }
    }
}