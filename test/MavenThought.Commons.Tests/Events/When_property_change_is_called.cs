using MavenThought.Commons.Testing;
using MbUnit.Framework;

namespace MavenThought.Commons.Tests.Events
{
    /// <summary>
    /// Specification when OnPropertyChanged is called
    /// </summary>
    [Specification]
    public class When_property_change_is_called : AbstractNotifyPropertyChangedSpecification
    {
        /// <summary>
        /// Checks the handler was called
        /// </summary>
        [It]
        public void Should_invoke_the_property_changed_handler()
        {
            this.Handler.AssertPropertyChangedWasCalled(this.Sut, "CurrentTest");
        }

        /// <summary>
        /// Call on property changed
        /// </summary>
        protected override void WhenIRun()
        {
            var mirror = Mirror.ForObject(this.Sut);

            mirror["OnPropertyChanged"].Invoke("CurrentTest");
        }
    }
}