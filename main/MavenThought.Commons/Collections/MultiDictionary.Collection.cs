using System.Collections.Generic;

namespace MavenThought.Commons.Collections
{
    /// <summary>
    /// Multi dictionary class
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public partial class MultiDictionary<TKey, TValue>
    {
        /// <summary>
        /// Count of the dictionary
        /// </summary>
        public int Count
        {
            get { return _dictionary.Count; }
        }

        /// <summary>
        /// Readonly property
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Adds to the dictionary
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<TKey, ICollection<TValue>> item)
        {
            _dictionary.Add(item);
        }

        /// <summary>
        /// Clears the dictionary
        /// </summary>
        public void Clear()
        {
            _dictionary.Clear();
        }

        /// <summary>
        /// Checks to see if the dictionary contains the requested item
        /// </summary>
        /// <param name="item">Item to check in dictionary</param>
        /// <returns>If item exists in dictionary</returns>
        public bool Contains(KeyValuePair<TKey, ICollection<TValue>> item)
        {
            return _dictionary.Contains(item);
        }

        /// <summary>
        /// Copies dictionary to array
        /// </summary>
        /// <param name="array">Target array</param>
        /// <param name="arrayIndex">Array size</param>
        public void CopyTo(KeyValuePair<TKey, ICollection<TValue>>[] array, int arrayIndex)
        {
            _dictionary.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes item from dictionary
        /// </summary>
        /// <param name="item">Item to be removed</param>
        /// <returns>If item was successfully removed</returns>
        public bool Remove(KeyValuePair<TKey, ICollection<TValue>> item)
        {
            return _dictionary.Remove(item);
        }
    }
}