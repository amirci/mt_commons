using System;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Events
{
    /// <summary>
    /// Specification when NotifyPropertyChanged is called
    /// </summary>
    [Specification]
    [Row(typeof(int))]
    [Row(typeof(string))]
    [Row(typeof(DateTime))]
    public class When_property_change_notify_is_called_with_same_value<T> : AbstractNotifyPropertyChangedSpecification
    {
        /// <summary>
        /// Property to pass
        /// </summary>
        private T _property ;

        /// <summary>
        /// Indicates whether the value was changed
        /// </summary>
        private bool _wasChanged;

        /// <summary>
        /// Checks tha handler was not called
        /// </summary>
        [It]
        public void Should_not_raise_the_property_changed_event()
        {
            this.Handler.AssertPropertyChangedWasNotCalled(this.Sut, "CurrentProperty");
        }

        /// <summary>
        /// Checks the property was not changed
        /// </summary>
        [It]
        public void Should_return_false_because_the_property_did_not_change()
        {
            Assert.IsFalse(this._wasChanged);
        }

        /// <summary>
        /// Setup the values for property and new value
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            var generator = new RandomGenerator();

            this._property = generator.Generate<T>();
        }

        /// <summary>
        /// Call NotifyPropertyChanged
        /// </summary>
        protected override void WhenIRun()
        {
            var sut = ((SutNotifyPropertyChanged)this.Sut);

            this._wasChanged = sut.Notify("CurrentProperty", ref this._property, this._property);
        }
    }
}