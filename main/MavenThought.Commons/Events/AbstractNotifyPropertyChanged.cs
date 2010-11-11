using System;
using System.ComponentModel;
using System.Linq.Expressions;
using MavenThought.Commons.Extensions;

namespace MavenThought.Commons.Events
{
    /// <summary>
    /// Implementation of notify property changed
    /// </summary>
    public abstract class AbstractNotifyPropertyChanged : INotifyPropertyChanged
    {
        /// <summary>
        /// Notify property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
        /// <summary>
        /// Raises the event
        /// </summary>
        /// <param name="propertyName">
        /// the property name to check
        /// </param>
        internal protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        internal protected void OnPropertyChanged<T>(Expression<Func<T>> property)
        {
            this.PropertyChanged(this, property.CreateChangeEventArgs());
        }

        /// <summary>
        /// Notify the property has changed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <param name="field">Field to store the value</param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        internal protected bool NotifyPropertyChanged<T>(Expression<Func<T>> property, ref T field, T newValue)
        {
            var changed = typeof(T).IsValueType ? !Equals(field, newValue) : !ReferenceEquals(field, newValue);

            if (changed)
            {
                field = newValue;

                this.OnPropertyChanged(property);
            }

            return changed;
        }

        /// <summary>
        /// Checks if the new value is different, assigns the new value and raises the event
        /// </summary>
        /// <typeparam name="T">Type of the property</typeparam>
        /// <param name="propertyName">
        /// Name of the property
        /// </param>
        /// <param name="property">
        /// Instance of the property
        /// </param>
        /// <param name="newValue">
        /// New value for the property
        /// </param>
        internal protected bool NotifyPropertyChanged<T>(string propertyName, ref T property, T newValue)
        {
            var changed = typeof(T).IsValueType ? !Equals(property, newValue) : !ReferenceEquals(property, newValue);

            if (changed)
            {
                property = newValue;

                this.OnPropertyChanged(propertyName);
            }

            return changed;
        }
    }
}