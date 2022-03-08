namespace RFQ.Workflow.Registries
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    internal abstract class CacheRegistry<TKey, TValue> : IEnumerable<TValue>
    {
        private readonly Func<TValue, TKey> _keySelector;
        private readonly ConcurrentDictionary<TKey, TValue> _registry;

        internal int Count
        {
            get { return _registry.Count; }
        }

        protected CacheRegistry(Func<TValue, TKey> keySelector)
        {
            _keySelector = keySelector;
            _registry = new ConcurrentDictionary<TKey, TValue>();
        }

        internal TValue GetById(TKey key)
        {
            TValue value;
            _registry.TryGetValue(key, out value);
            return value;
        }

        internal TValue GetFirst(Func<TValue, bool> selectPredicate)
        {
            return _registry.Values.FirstOrDefault(selectPredicate);
        }

        internal IEnumerable<TValue> Find(Func<TValue, bool> selectPredicate)
        {
            return _registry.Values.Where(selectPredicate);
        }

        internal bool Contains(TValue value)
        {
            var key = _keySelector(value);
            return _registry.ContainsKey(key);
        }

        internal bool TryAdd(TValue value)
        {
            var key = _keySelector(value);
            return _registry.TryAdd(key, value);
        }

        internal void AddOrUpdate(TValue newValue)
        {
            var newKey = _keySelector(newValue);
            _registry.AddOrUpdate(newKey, newValue, (key, old) => newValue);
        }

        internal bool TryRemove(TValue value)
        {
            var key = _keySelector(value);
            return _registry.TryRemove(key, out value);
        }

        internal void Clear()
        {
            _registry.Clear();
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return _registry.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
