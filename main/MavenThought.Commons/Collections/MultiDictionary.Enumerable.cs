using System.Collections;
using System.Collections.Generic;

namespace MavenThought.Commons.Collections
{
    /// <summary>
    /// Implementation of Enumerable interface
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public partial class MultiDictionary<TKey, TValue>
    {
        public IEnumerator<KeyValuePair<TKey, ICollection<TValue>>> GetEnumerator()
        {
            return this._dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}