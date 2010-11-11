using System;
using MavenThought.Commons.Events;
using Rhino.Mocks;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Events
{
    /// <summary>
    /// Specification when the property change is raised
    /// </summary>
    [Specification]
    public class When_helper_listens_to_property_change : NotifyPropertyChangedHelperSpecification
    {
        /// <summary>
        /// Action to use
        /// </summary>
        private Action _action;

        /// <summary>
        /// Checks the action was called
        /// </summary>
        [It]
        public void Should_call_the_registered_handler()
        {
            this._action.AssertWasCalled(a => a());
        }

        /// <summary>
        /// Setup the call
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this._action = Mock<Action>();

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