using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using MavenThought.Commons.Collections;
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
        private readonly IMultiDictionary<Type, EventSubscription> _eventHandlers = new MultiDictionary<Type, EventSubscription>();

        /// <summary>
        /// Generator of proxies
        /// </summary>
        private readonly ProxyGenerator _generator = new ProxyGenerator();

        /// <summary>
        /// Subscribe a handler to be notified when the event is raised
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <param name="handler">Handler to use</param>
        public void Subscribe<T>(IHandleEventsOfType<T> handler) where T : IEvent
        {
        }

        /// <summary>
        /// Subscribes a handler to be notified when the event is raised
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <param name="handler">Handler to use</param>
        /// <returns>The actual handler for the test</returns>
        public IHandleEventsOfType<T> Subscribe<T>(Action<T> handler) where T : IEvent
        {
            var subscription = new ActionEventSubscription<T>(handler);

            this._eventHandlers.Add(typeof(T), subscription);

            return subscription;
        }

        /// <summary>
        /// Unsubscribe the event so no events will be notified
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Unsubscribe<T>(IHandleEventsOfType<T> handler) where T : IEvent
        {
        }

        /// <summary>
        /// Raises an event and notified to all the subscribers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configure"></param>
        public void Raise<T>(Action<T> configure) where T : IEvent
        {
            var listeners = this.FindListenersFor<T>();

            if (listeners.IsEmpty())
            {
                return;
            }

            var proxy = CreateProxy<T>();

            configure(proxy);

            listeners.ForEach(s => s.Invoke(proxy));
        }

        /// <summary>
        /// Raises an event
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        public void Raise<T>() where T : IEvent
        {
            this.FindListenersFor<T>().ForEach(s => s.Invoke(null));
        }

        /// <summary>
        /// Finds all the listeners to the event
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <returns>A collection of listeners or an empty collection if no one was found</returns>
        private IEnumerable<EventSubscription> FindListenersFor<T>()
        {
            ICollection<EventSubscription> listeners;

            this._eventHandlers.TryGetValue(typeof(T), out listeners);

            return listeners ?? System.Linq.Enumerable.Empty<EventSubscription>();
        }

        /// <summary>
        /// Creates a proxy of the event
        /// </summary>
        /// <typeparam name="T">Type of the event</typeparam>
        /// <returns>A new proxy for the event</returns>
        private T CreateProxy<T>()
        {
            return (T) _generator
                           .CreateInterfaceProxyWithoutTarget(typeof (T),
                                                              new IInterceptor[]
                                                                  {
                                                                      new AutoPropertyStub()
                                                                  });
        }
        
        /// <summary>
        /// Base subscription
        /// </summary>
        internal interface EventSubscription : IHandleEvents
        {
            /// <summary>
            /// Invoke the event
            /// </summary>
            /// <param name="event"></param>
            void Invoke(object @event);
        }

        /// <summary>
        /// Subscription with an action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        internal class ActionEventSubscription<T> : EventSubscription, IHandleEventsOfType<T> where T : IEvent
        {
            private readonly Action<T> _handler;

            public ActionEventSubscription(Action<T> handler)
            {
                _handler = handler;
            }

            /// <summary>
            /// Method to be called when the event is risen
            /// </summary>
            /// <param name="event">Event risen</param>
            public void Handle(T @event)
            {
                this._handler(@event);
            }

            /// <summary>
            /// Invoke the event
            /// </summary>
            /// <param name="event"></param>
            public void Invoke(object @event)
            {
                Handle((T)@event);
            }
        }
    }
}