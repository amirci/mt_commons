using System;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Simple event handler subscription that creates the instance
    /// to handle the event when called
    /// </summary>
    public class TransientEventSubscription : BaseEventSubscription
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TransientEventSubscription"/> class.
        /// </summary>
        /// <param name="handlerType">Type of the handler to be instantiated</param>
        public TransientEventSubscription(Type handlerType)
            :base(handlerType)
        {
        }

        /// <summary>
        /// Creates the instance of the handler
        /// </summary>
        /// <returns>Instance of the handler to use</returns>
        protected override object CreateHandler()
        {
            return Activator.CreateInstance(this.HandlerType);
        }
    }
}