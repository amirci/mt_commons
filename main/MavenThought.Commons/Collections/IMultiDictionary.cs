using System.Collections.Generic;

namespace MavenThought.Commons.Collections
{
    /// <summary>
    /// Base interface for multi dictionary
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IMultiDictionary<TKey, TValue>
        : IDictionary<TKey, ICollection<TValue>>
    {
        /// <summary>
        /// Adds an element to the collection associated to the key
        /// </summary>
        /// <param name="key">Key to use</param>
        /// <param name="value">Element to add to the collection</param>
        /// <returns></returns>
        void Add(TKey key, TValue value);

        /// <summary>
        /// Removes the element from the collection associated to the key
        /// </summary>
        /// <param name="key">Key to use</param>
        /// <param name="value">Value to remove</param>
        /// <returns><c>True</c> if the value was removed, <c>false</c> otherwise</returns>
        bool Remove(TKey key, TValue value);
    }
}