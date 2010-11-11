using System;
using System.ComponentModel;
using System.Linq.Expressions;
using MavenThought.Commons.Events;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Events
{
    /// <summary>
    /// Base specification for AbstractNotifyPropertyChanged
    /// </summary>
    public abstract class AbstractNotifyPropertyChangedSpecification
        : AutoMockSpecificationWithNoContract<AbstractNotifyPropertyChanged>
    {
        /// <summary>
        /// Gets the property changed event handler
        /// </summary>
        protected PropertyChangedEventHandler Handler { get; private set; }

        /// <summary>
        /// Setup the handler
        /// </summary>
        protected override void GivenThat()
        {
            this.Handler = MockIt(this.Handler);
        }

        /// <summary>
        /// Creates the SUt to test
        /// </summary>
        /// <returns>An instnace of <see cref="SutNotifyPropertyChanged"/></returns>
        protected override AbstractNotifyPropertyChanged CreateSut()
        {
            return new SutNotifyPropertyChanged();
        }

        /// <summary>
        /// Register the handler
        /// </summary>
        protected override void AndGivenThatAfterCreated()
        {
            this.Sut.PropertyChanged += this.Handler;
        }

        protected class SutNotifyPropertyChanged : AbstractNotifyPropertyChanged
        {
            public bool Notify<T>(string currentproperty, ref T property, T b)
            {
                return this.NotifyPropertyChanged(currentproperty, ref property, b);
            }

            public bool Notify<T>(Expression<Func<T>> expr, ref T field, T newValue)
            {
                return this.NotifyPropertyChanged(expr, ref field, newValue);
            }
        }
    }
}