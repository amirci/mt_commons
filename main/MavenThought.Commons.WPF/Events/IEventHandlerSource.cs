using System;
using System.Reflection;

namespace MavenThought.Commons.WPF.Events
{
    /// <summary>
    /// Source for event handlers
    /// </summary>
    public interface IEventHandlerSource
    {
        /// <summary>
        /// Gets the collection of registrations in current assembly
        /// </summary>
        IEventSubscriptionCollection CurrentAssembly();

        /// <summary>
        /// Finds event handlers in typeof(T).Assembly
        /// </summary>
        /// <typeparam name="T">Type to find the assembly</typeparam>
        /// <returns>A collection of event handlers that live in the assembly</returns>
        IEventSubscriptionCollection AssemblyOf<T>() where T : class;

        /// <summary>
        /// Finds event handlers in typ.Assembly
        /// </summary>
        /// <param name="type">Type to find the assembly</param>
        /// <returns>A collection of event handlers that live in the assembly</returns>
        IEventSubscriptionCollection AssemblyOf(Type type);

        /// <summary>
        /// Finds event handlers in assembly
        /// </summary>
        /// <param name="assembly">Assembly to use</param>
        /// <returns>A collection of event handlers that live in the assembly</returns>
        IEventSubscriptionCollection Assembly(Assembly assembly);
    }
}