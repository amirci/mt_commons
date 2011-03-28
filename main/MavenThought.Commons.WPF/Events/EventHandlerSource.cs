using System;
using System.Linq;
using System.Reflection;
using MavenThought.Commons.Extensions;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Base class to find event handlers
    /// </summary>
    public class EventHandlerSource : IEventHandlerSource
    {
        /// <summary>
        /// Gets the collection of registrations in current assembly
        /// </summary>
        public IEventSubscriptionCollection CurrentAssembly()
        {
            return Assembly(System.Reflection.Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// Finds event handlers in typeof(T).Assembly
        /// </summary>
        /// <typeparam name="T">Type to find the assembly</typeparam>
        /// <returns>A collection of event handlers that live in the assembly</returns>
        public IEventSubscriptionCollection AssemblyOf<T>() where T : class
        {
            return AssemblyOf(typeof(T));
        }

        /// <summary>
        /// Finds event handlers in typ.Assembly
        /// </summary>
        /// <param name="type">Type to find the assembly</param>
        /// <returns>A collection of event handlers that live in the assembly</returns>
        public IEventSubscriptionCollection AssemblyOf(Type type)
        {
            return Assembly(type.Assembly);
        }

        /// <summary>
        /// Finds event handlers in assembly
        /// </summary>
        /// <param name="assembly">Assembly to use</param>
        /// <returns>A collection of event handlers that live in the assembly</returns>
        public IEventSubscriptionCollection Assembly(Assembly assembly)
        {
            Predicate<Type> canHandleEvents = t => t.GetInterfaces().Exists(i => i.Name.StartsWith("IHandleEventsOfType"));

            Predicate<Type> canBeInstantiated = t =>
                                                    {
                                                        var ctrs = t.GetConstructors();

                                                        return t.IsClass &&
                                                               !t.IsAbstract &&
                                                               (ctrs.IsEmpty() ||
                                                                ctrs.Exists(c => c.GetParameters().IsEmpty()));
                                                    };

            return new TransientSubscriptionCollection(assembly
                                        .GetTypes()
                                        .Where(t => canHandleEvents(t) && canBeInstantiated(t)));
        }
    }
}