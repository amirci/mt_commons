using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;

namespace MavenThought.Commons.WPF.Events
{
    public class TransientSubscriptionCollection : IEventSubscriptionCollection
    {
        private readonly IEnumerable<Type> _types;

        public TransientSubscriptionCollection(IEnumerable<Type> types)
        {
            _types = types;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<IEventSubscription> GetEnumerator()
        {
            return _types.Select(t => new TransientEventSubscription(t))
                .Cast<IEventSubscription>()
                .GetEnumerator();
        }

        /// <summary>
        /// Gets the collection using the service locator as factory
        /// </summary>
        /// <param name="serviceLocator">Factory to create the handlers</param>
        /// <returns>The collection of subscriptions</returns>
        public IEnumerable<IEventSubscription> Factory(IServiceLocator serviceLocator)
        {
            return _types
                .Select(t => new ServiceLocatorEventSubscription(t, serviceLocator))
                .Cast<IEventSubscription>();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}