using System;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace MavenThought.Commons.WPF.Windsor
{
    /// <summary>
    /// Extension methods for windsor container
    /// </summary>
    public static class WindsorContainerHelper
    {
        /// <summary>
        /// Returns whether a specified type has a type mapping registered in the container.
        /// </summary>
        /// <param name="container">
        /// The <see cref="IWindsorContainer"/> to check for the type mapping.
        /// </param>
        /// <param name="type">
        /// The type to check if there is a type mapping for.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if there is a type mapping registered for <paramref name="type"/>.
        /// </returns>
        /// <remarks>
        /// In order to use this extension method, you first need to add the
        /// </remarks>
        public static bool IsTypeRegistered(this IWindsorContainer container, Type type)
        {
            return container.Kernel.HasComponent(type);
        }

        /// <summary>
        /// Extension to check if a type is registered in the container
        /// </summary>
        /// <typeparam name="TType">
        /// Type to check
        /// </typeparam>
        /// <param name="container">
        /// Container to extend
        /// </param>
        /// <returns>
        /// The result of calling <see cref="IsTypeRegistered"/>
        /// </returns>
        public static bool IsTypeRegistered<TType>(this IWindsorContainer container)
        {
            var typeToCheck = typeof(TType);

            return IsTypeRegistered(container, typeToCheck);
        }

        /// <summary>
        /// Utility method to try to resolve a service from the container avoiding an exception if the container cannot build the type.
        /// </summary>
        /// <param name="container">
        /// The cointainer that will be used to resolve the type.
        /// </param>
        /// <typeparam name="T">
        /// The type to resolve.
        /// </typeparam>
        /// <returns>
        /// The instance of <typeparamref name="T"/> built up by the container.
        /// </returns>
        public static T TryResolve<T>(this IWindsorContainer container)
        {
            var result = TryResolve(container, typeof(T));

            if (result != null)
            {
                return (T) result;
            }

            return default(T);
        }

        /// <summary>
        /// Utility method to try to resolve a service from the container avoiding an exception if the container cannot build the type.
        /// </summary>
        /// <param name="container">
        /// The cointainer that will be used to resolve the type.
        /// </param>
        /// <param name="typeToResolve">
        /// The type to resolve.
        /// </param>
        /// <returns>
        /// The instance of <paramref name="typeToResolve"/> built up by the container.
        /// </returns>
        public static object TryResolve(this IWindsorContainer container, Type typeToResolve)
        {
            object resolved;

            try
            {
                resolved = Resolve(container, typeToResolve);
            }
            catch (Exception)
            {
                resolved = null;
            }

            return resolved;
        }

        /// <summary>
        /// Resolves a service from the container. If the type does not exist on the container, 
        /// first registers it with transient lifestyle.
        /// </summary>
        /// <param name="container">
        /// Container to extend
        /// </param>
        /// <param name="type">
        /// Type to resolve
        /// </param>
        /// <returns>
        /// The result of resolving the type in the container
        /// </returns>
        public static object Resolve2(this IWindsorContainer container, Type type)
        {
            if (type.IsClass && !container.Kernel.HasComponent(type))
            {
                var component = Component.For(type).Named(type.FullName).LifeStyle.Is(LifestyleType.Transient);

                container.Kernel.Register(component);
            }

            return container.Resolve(type);
        }

        /// <summary>
        /// Extension to resolve a type in the Windsor container
        /// </summary>
        /// <typeparam name="T">
        /// Type to resolve
        /// </typeparam>
        /// <param name="container">
        /// Container to use
        /// </param>
        /// <returns>
        /// The result of calling Resolve in the container
        /// </returns>
        public static T Resolve2<T>(this IWindsorContainer container) where T : class
        {
            var type = typeof(T);

            return (T) Resolve2(container, type);
        }

        /// <summary>
        /// Resolves a service from the container. If the type does not exist on the container, 
        /// first registers it with transient lifestyle.
        /// </summary>
        /// <param name="container">
        /// Container to extend
        /// </param>
        /// <param name="type">
        /// Type to resolve
        /// </param>
        /// <returns>
        /// The result of the container
        /// </returns>
        private static object Resolve(this IWindsorContainer container, Type type)
        {
            return Resolve2(container, type);
        }
    }
}