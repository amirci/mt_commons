using System;
using Microsoft.Practices.ServiceLocation;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Subscription that uses the service locator to find the handler
    /// </summary>
    public class ServiceLocatorEventSubscription : BaseEventSubscription
    {
        /// <summary>
        /// Backing field of the service locator
        /// </summary>
        private readonly IServiceLocator _serviceLocator;

        /// <summary>
        /// Initializes a new instance of <see cref="ServiceLocatorEventSubscription"/> class
        /// </summary>
        /// <param name="handlerType">Type of the handler to use</param>
        /// <param name="serviceLocator">Class to find the instance of the handler</param>
        public ServiceLocatorEventSubscription(Type handlerType, IServiceLocator serviceLocator)
            :base(handlerType)
        {
            _serviceLocator = serviceLocator;
        }

        /// <summary>
        /// Creates the instance of the handler
        /// </summary>
        /// <returns>Instance of the handler to use</returns>
        protected override object CreateHandler()
        {
            return null;
        }
    }
}