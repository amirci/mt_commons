using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Events
{
    /// <summary>
    /// Specification when NotifyPropertyChanged is called
    /// </summary>
    [Specification]
    public class When_property_change_notify_is_called : AbstractNotifyPropertyChangedSpecification
    {
        /// <summary>
        /// Property to pass
        /// </summary>
        private bool _property;

        /// <summary>
        /// Actual value obtained
        /// </summary>
        private bool _actual;

        /// <summary>
        /// Checks tha handler is called
        /// </summary>
        [It]
        public void Should_raise_the_property_changed_event()
        {
            this.Handler.AssertPropertyChangedWasCalled("CurrentProperty");
        }

        /// <summary>
        /// Checks the property was changed
        /// </summary>
        [It]
        public void Should_return_true_because_the_property_has_been_changed()
        {
            Assert.IsTrue(this._actual);
        }

        /// <summary>
        /// Set the property to false
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            base.AndGivenThatAfterCreated();

            this._property = false;
        }

        /// <summary>
        /// Call NotifyPropertyChanged
        /// </summary>
        protected override void WhenIRun()
        {
            var sut = ((SutNotifyPropertyChanged)this.Sut);

            this._actual = sut.Notify("CurrentProperty", ref this._property, true);
        }
    }
}