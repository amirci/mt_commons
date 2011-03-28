using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Collection of results of finding subscriptions
    /// </summary>
    public interface IEventSubscriptionCollection : IEnumerable<IEventSubscription>
    {
        /// <summary>
        /// Gets the collection using the service locator as factory
        /// </summary>
        /// <param name="serviceLocator">Factory to create the handlers</param>
        /// <returns>The collection of subscriptions</returns>
        IEnumerable<IEventSubscription> Factory(IServiceLocator serviceLocator);
    }
}