using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MavenThought.Commons.Events
{
    /// <summary>
    /// Extension methods for <see cref="PropertyChangedEventArgs"/> and <see cref="INotifyPropertyChanged"/>
    /// </summary>
    public static class NotifyPropertyChangedHelper
    {
        /// <summary>
        /// Extension method to apply an action when the specified property has changed
        /// </summary>
        /// <param name="arguments">Arguments for the event with the property name </param>
        /// <param name="propertyName">Name of the property</param>
        /// <param name="action">Action to run</param>
        public static void On(this PropertyChangedEventArgs arguments, string propertyName, Action<PropertyChangedEventArgs> action)
        {
            On(arguments, propertyName, () => action(arguments));
        }

        /// <summary>
        /// Extension method to apply an action when the specified property has changed
        /// </summary>
        /// <param name="arguments"> Arguments for the event with the property name </param>
        /// <param name="property">Property expression to use</param>
        /// <param name="action">Action to run</param>
        public static void On<TSource, TResult>(this PropertyChangedEventArgs arguments, Expression<Func<TSource, TResult>> property, Action<PropertyChangedEventArgs> action)
            where TSource : INotifyPropertyChanged
        {
            On(arguments, property, () => action(arguments));
        }

        /// <summary>
        /// Extension method to apply an action when the specified property has changed
        /// </summary>
        /// <param name="arguments"> Arguments for the event with the property name </param>
        /// <param name="propertyName">Name of the property</param>
        /// <param name="action">Action to run</param>
        public static void On(this PropertyChangedEventArgs arguments, string propertyName, Action action)
        {
            if (arguments.PropertyName == propertyName)
            {
                action();
            }
        }

        /// <summary>
        /// Extension method to apply an action when the specified property has changed
        /// </summary>
        /// <param name="arguments"> Arguments for the event with the property name </param>
        /// <param name="property">Property expression to get the name from</param>
        /// <param name="action">Action to run</param>
        public static void On<TSource, TResult>(this PropertyChangedEventArgs arguments, Expression<Func<TSource, TResult>> property, Action action)
            where TSource : INotifyPropertyChanged
        {
            var expression = (MemberExpression)property.Body;
            var member = expression.Member;
            On(arguments, member.Name, action);
        }

        /// <summary>
        /// Extension method to call an action when the INotifyPropertyChanged raises a property change
        /// </summary>
        /// <param name="source">The instance of <see cref="INotifyPropertyChanged"/> </param>
        /// <param name="propertyName">Name of the property </param>
        /// <param name="action">Action that takes the arguments of the event as arguments</param>
        public static INotifyPropertyChanged On(this INotifyPropertyChanged source, string propertyName, Action<PropertyChangedEventArgs> action)
        {
            source.PropertyChanged += (x, args) => args.On(propertyName, action);
            return source;
        }

       /// <summary>
        /// Extension method to call an action when the INotifyPropertyChanged raises a property change
        /// </summary>
        /// <param name="source">The instance of <see cref="INotifyPropertyChanged"/> </param>
        /// <param name="propertyName">Name of the property </param>
        /// <param name="action">Action that takes the arguments of the event as arguments</param>
        public static T On<T>(this T source, string propertyName, Action<T> action) where T : class, INotifyPropertyChanged
        {
            source.PropertyChanged += (x, args) => args.On(propertyName, () => action(source));
            return source;
        }

        /// <summary>
        /// Registers to the property changed only for the property specified
        /// </summary>
        /// <typeparam name="TSource">Type of the source</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="source">Source instance</param>
        /// <param name="property">Property expression</param>
        /// <param name="action">Action to do when the event is raised</param>
        /// <returns>The same source instance</returns>
        public static INotifyPropertyChanged On<TSource, TResult>(this TSource source, Expression<Func<TSource, TResult>> property, Action<PropertyChangedEventArgs> action)
            where TSource : INotifyPropertyChanged
        {
            source.PropertyChanged += (x, args) => args.On(property, action);
            return source;
        }

        /// <summary>
        /// Extension method to call an action when the INotifyPropertyChanged raises a property change
        /// </summary>
        /// <param name="source">The instance of INotifyPropertyChanged </param>
        /// <param name="propertyName">Name of the property </param>
        /// <param name="action">Action to run </param>
        public static INotifyPropertyChanged On(this INotifyPropertyChanged source, string propertyName, Action action)
        {
            source.PropertyChanged += (x, args) => args.On(propertyName, action);
            return source;
        }

        /// <summary>
        /// Registers to the property changed only for the property specified
        /// </summary>
        /// <typeparam name="TSource">Type of the source</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="source">Source instance</param>
        /// <param name="property">Property expression</param>
        /// <param name="action">Action to do when the event is raised</param>
        /// <returns>The same source instance</returns>
        public static INotifyPropertyChanged On<TSource, TResult>(this TSource source, Expression<Func<TSource, TResult>> property, Action action)
            where TSource : INotifyPropertyChanged
        {
            source.PropertyChanged += (x, args) => args.On(property, action);
            return source;
        }

        /// <summary>
        /// Registers to the property changed only for the property specified
        /// </summary>
        /// <typeparam name="TSource">Type of the source</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="source">Source instance</param>
        /// <param name="property">Property expression</param>
        /// <param name="action">Action to do when the event is raised</param>
        /// <returns>The same source instance</returns>
        public static INotifyPropertyChanged On<TSource, TResult>(this TSource source, Expression<Func<TSource, TResult>> property, Action<TSource> action)
           where TSource : INotifyPropertyChanged
        {
            On(source, property, () => action(source));
            return source;
        }
    }
}