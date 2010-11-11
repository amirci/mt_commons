using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Events
{
    /// <summary>
    /// Specification when notifying using an expression
    /// </summary>
    [Specification]
    public class When_property_change_notify_is_called_with_expression : AbstractNotifyPropertyChangedSpecification
    {
        /// <summary>
        /// String property backing field
        /// </summary>
        private string _stringProperty;

        /// <summary>
        /// Checks tha handler is called
        /// </summary>
        [It]
        public void Should_raise_the_property_changed_event()
        {
            this.Handler.AssertPropertyChangedWasCalled("StringProperty");
        }

        /// <summary>
        /// Checks the property was changed
        /// </summary>
        [It]
        public void Should_return_true_because_the_property_has_been_changed()
        {
            Assert.AreEqual("New value", this._stringProperty);
        }
    
        /// <summary>
        /// Call NotifyPropertyChanged
        /// </summary>
        protected override void WhenIRun()
        {
            var sut = ((SutNotifyPropertyChanged)this.Sut);

            sut.Notify(() => this.StringProperty, ref this._stringProperty, "New value");
        }

        protected string StringProperty { get; set; }
    }
}