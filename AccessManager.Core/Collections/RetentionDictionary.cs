using System.Collections;
using System.Runtime.Caching;

namespace AccessManager.Core.Collections
{
    public class RetentionDictionary<T> : IEnumerable<KeyValuePair<string, T>>
    {
        public IEnumerable<string> Keys => this.Select(i => i.Key).ToArray();
        public IEnumerable<T> Values => this.Select(i => i.Value).ToArray();

        private MemoryCache _cache = new MemoryCache(Guid.NewGuid().ToString());
        private readonly TimeSpan _ttl;

        public RetentionDictionary(TimeSpan ttl)
        {
            _ttl = ttl;
        }

        public void Add(string key, T value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            var storeItem = new RetentionDictionaryItem<T>
            {
                Value = value,
                CreateDateTime = DateTimeOffset.Now
            };

            _cache.Add(key, storeItem, storeItem.CreateDateTime.Add(_ttl));
        }

        public void Add(T value)
        {
            Add(Guid.NewGuid().ToString(), value);
        }

        public T Get<T>(string key)
        {
            var item = _cache.Get(key);
            if (item == null)
                throw new KeyNotFoundException(key);

            return ((RetentionDictionaryItem<T>)item).Value;
        }

        public bool TryGet(string key, out T value)
        {
            var item = _cache.Get(key);
            if (item == null)
            {
                value = default;
                return false;
            }
            else
            {
                value = ((RetentionDictionaryItem<T>)item).Value;
                return true;
            }
        }

        public void Remove(string key)
        {
            var item = _cache.Remove(key);

            if (item == null)
                throw new KeyNotFoundException(key);
        }

        public void Reset()
        {
            foreach (var key in Keys.Reverse())
            {
                _cache.Remove(key);
            }
        }

        public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
        {
            return _cache
                .ToDictionary(i => i.Key, i => (RetentionDictionaryItem<T>)i.Value)
                .OrderBy(i => i.Value.CreateDateTime)
                .ToDictionary(i => i.Key, i => i.Value.Value)
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
