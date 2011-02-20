using System.Collections.Generic;
using MavenThought.Commons.Extensions;

namespace MavenThought.Commons.Collections
{
    /// <summary>
    /// Dictionary that has multiple values for one key
    /// </summary>
    /// <typeparam name="TKey">Type of the key</typeparam>
    /// <typeparam name="TValue">Type of the value</typeparam>
    public partial class MultiDictionary<TKey, TValue> : IMultiDictionary<TKey, TValue>
    {
        /// <summary>
        /// Dictionary to use as backing collection
        /// </summary>
        private readonly IDictionary<TKey, ICollection<TValue>> _dictionary = new Dictionary<TKey, ICollection<TValue>>();

        /// <summary>
        /// Adds an element to the collection associated to the key
        /// </summary>
        /// <param name="key">Key to use</param>
        /// <param name="value">Element to add to the collection</param>
        /// <returns></returns>
        public void Add(TKey key, TValue value)
        {
            ICollection<TValue> collection;

            _dictionary.TryGetValue(key, out collection);

            if (collection == null)
            {
                collection = new List<TValue>();
                _dictionary[key] = collection;
            }

            collection.Add(value);
        }

        /// <summary>
        /// Removes the element from the collection associated to the key
        /// </summary>
        /// <param name="key">Key to use</param>
        /// <param name="value">Value to remove</param>
        /// <returns><c>True</c> if the value was removed, <c>false</c> otherwise</returns>
        public bool Remove(TKey key, TValue value)
        {
            ICollection<TValue> collection;

            this._dictionary.TryGetValue(key, out collection);

            var removed = collection != null && collection.Remove(value);

            if (removed && collection.IsEmpty())
            {
                this._dictionary.Remove(key);
            }

            return removed;
        }
    }
}