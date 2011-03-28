using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using MavenThought.Commons.Extensions;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Base class to provide fluid interface to find handlers
    /// </summary>
    public static class EventHandlers
    {
        /// <summary>
        /// Returns the source to get event handlers
        /// </summary>
        public static IEventHandlerSource From
        {
            get { return new EventHandlerSource(); }
        }

        /// <summary>
        /// Class to find event handlers
        /// </summary>
        private class EventHandlerSource : IEventHandlerSource
        {
            /// <summary>
            /// Gets the collection of registrations in current assembly
            /// </summary>
            public IEnumerable<IEventHandlerSubscription> CurrentAssembly()
            {
                return Assembly(System.Reflection.Assembly.GetCallingAssembly());
            }

            /// <summary>
            /// Finds event handlers in typeof(T).Assembly
            /// </summary>
            /// <typeparam name="T">Type to find the assembly</typeparam>
            /// <returns>A collection of event handlers that live in the assembly</returns>
            public IEnumerable<IEventHandlerSubscription> AssemblyOf<T>() where T : class
            {
                return AssemblyOf(typeof(T));
            }

            /// <summary>
            /// Finds event handlers in typ.Assembly
            /// </summary>
            /// <param name="type">Type to find the assembly</param>
            /// <returns>A collection of event handlers that live in the assembly</returns>
            public IEnumerable<IEventHandlerSubscription> AssemblyOf(Type type)
            {
                return Assembly(type.Assembly);
            }

            /// <summary>
            /// Finds event handlers in assembly
            /// </summary>
            /// <param name="assembly">Assembly to use</param>
            /// <returns>A collection of event handlers that live in the assembly</returns>
            public IEnumerable<IEventHandlerSubscription> Assembly(Assembly assembly)
            {
                Predicate<Type> canHandleEvents = t => typeof(IHandleEvents).IsAssignableFrom(t);

                Predicate<Type> canBeInstantiated = t =>
                                                    {
                                                        var ctrs = t.GetConstructors();

                                                        return t.IsClass &&
                                                               !t.IsAbstract &&
                                                               (ctrs.IsEmpty() ||
                                                                ctrs.Exists(c => c.GetParameters().IsEmpty()));
                                                    };

                return assembly
                    .GetTypes()
                    .Where(t => canHandleEvents(t) && canBeInstantiated(t))
                    .Select(t => new SimpleEventHandlerSubscription(t))
                    .Cast<IEventHandlerSubscription>();
            }
        }
    }
}