using System;
using System.Collections;
using System.Collections.Generic;

namespace Majestic12
{
    public class Hashtable : IDictionary
    {
        private readonly Dictionary<object, object> _dict = new Dictionary<object, object>();

        public bool Contains(object key)
        {
            return _dict.ContainsKey(key);
        }

        public void Add(object key, object value)
        {
            _dict.Add(key, value);
        }

        public void Clear()
        {
            _dict.Clear();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

        public void Remove(object key)
        {
            _dict.Remove(key);
        }

        public object this[object key]
        {
            get { return _dict[key]; }
            set { _dict[key] = value; }
        }

        public ICollection Keys
        {
            get { return _dict.Keys; }
        }

        public ICollection Values
        {
            get { return _dict.Values; }
        }

        public bool IsReadOnly
        {
            get { return ((IDictionary) _dict).IsReadOnly; }
        }

        public bool IsFixedSize
        {
            get { return ((IDictionary) _dict).IsFixedSize; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            ((IDictionary) _dict).CopyTo(array, index);
        }

        public int Count
        {
            get { return _dict.Count; }
        }

        public object SyncRoot
        {
            get { return ((IDictionary) _dict).SyncRoot; }
        }

        public bool IsSynchronized
        {
            get { return ((IDictionary) _dict).IsSynchronized; }
        }
    }
}
