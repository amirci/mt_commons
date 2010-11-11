using System;
using System.ComponentModel;
using MavenThought.Commons.Events;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Events
{
    /// <summary>
    /// Specification when the property change is raised
    /// </summary>
    [Specification]
    public class When_helper_listens_to_property_change_with_args : NotifyPropertyChangedHelperSpecification
    {
        /// <summary>
        /// Action to use
        /// </summary>
        private Action<PropertyChangedEventArgs> _action;

        /// <summary>
        /// Checks the action was called
        /// </summary>
        [It]
        public void Should_call_the_registered_handler()
        {
            this._action.AssertWasCalled(a => a(Arg<PropertyChangedEventArgs>.Matches(arg => arg.PropertyName == "AnyProperty")));
        }

        /// <summary>
        /// Setup the call
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._action = MockIt(this._action);

            this.Target.On(m => m.AnyProperty, this._action);
        }

        /// <summary>
        /// Raise property changed
        /// </summary>
        protected override void WhenIRun()
        {
            this.Target.RaisePropertyChanged(m => m.AnyProperty);
        }
    }
}