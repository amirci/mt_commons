using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using MavenThought.Commons.Extensions;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Event aggregator implementation
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        /// <summary>
        /// Multi dictionary to store all the handlers byt type
        /// </summary>
        private readonly ICollection<IEventSubscription> _subscriptions = new List<IEventSubscription>();

        /// <summary>
        /// Generator of proxies
        /// </summary>
        private readonly ProxyGenerator _generator = new ProxyGenerator();

        /// <summary>
        /// Subscribes a handler to be notified when the event is raised
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <param name="handler">Handler to use</param>
        /// <returns>The actual handler for the test</returns>
        public IEventSubscription Subscribe<T>(Action<T> handler) where T : IEvent
        {
            var subscription = new ActionEventSubscription<T>(handler);

            this._subscriptions.Add(subscription);

            return subscription;
        }

        /// <summary>
        /// Register event subcriptions
        /// </summary>
        /// <param name="subscriptions">The subscriptions to register</param>
        public void Subscribe(IEnumerable<IEventSubscription> subscriptions)
        {
            subscriptions.Copy(this._subscriptions);
        }

        /// <summary>
        /// Raises an event and notified to all the subscribers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configure"></param>
        public void Raise<T>(Action<T> configure) where T : IEvent
        {
            var proxy = CreateProxy<T>();

            configure(proxy);

            this._subscriptions.ForEach(s => s.Invoke(proxy));
        }

        /// <summary>
        /// Raises an event
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        public void Raise<T>() where T : IEvent
        {
            // Call with empty configure action
            Raise<T>(ev => { });
        }

        /// <summary>
        /// Creates a proxy of the event
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <returns>A new proxy for the event</returns>
        private T CreateProxy<T>()
        {
            var interceptors = new IInterceptor[]
                                   {
                                       new AutoPropertyStub()
                                   };

            return (T) _generator.CreateInterfaceProxyWithoutTarget(typeof(T), interceptors);
        }
    }
}