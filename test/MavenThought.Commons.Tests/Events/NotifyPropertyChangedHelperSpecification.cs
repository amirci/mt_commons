using System.ComponentModel;
using MavenThought.Commons.Testing;

namespace MavenThought.Commons.Tests.Events
{
    /// <summary>
    /// Base specification for NotifyPropertyChangedHelper
    /// </summary>
    public abstract class NotifyPropertyChangedHelperSpecification
        : BaseSpecification
    {
        /// <summary>
        /// Target to use
        /// </summary>
        protected DummyPropertyChanged Target { get; private set; }

        /// <summary>
        /// Initialize the target
        /// </summary>
        protected override void GivenThat()
        {
            base.GivenThat();

            this.Target = Mock<DummyPropertyChanged>();
        }

        /// <summary>
        /// Dummy class to use
        /// </summary>
        public interface DummyPropertyChanged : INotifyPropertyChanged
        {
            /// <summary>
            /// Property to raise
            /// </summary>
            int AnyProperty { get; set; }

            /// <summary>
            /// Action to raise
            /// </summary>
            void AnyAction();

            /// <summary>
            /// Method to raise
            /// </summary>
            /// <returns>an int</returns>
            int AnyMethod();
        }
    }
}