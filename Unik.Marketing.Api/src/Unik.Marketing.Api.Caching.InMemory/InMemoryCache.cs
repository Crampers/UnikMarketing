using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Unik.Marketing.Api.Caching.Configuration;

namespace Unik.Marketing.Api.Caching.InMemory
{
    public class InMemoryCache<TKey, TValue> : ICache<TKey, TValue>
    {
        private readonly CacheOptions _options;
        private readonly ConcurrentDictionary<TKey, CacheItem> _store = new ConcurrentDictionary<TKey, CacheItem>();

        public InMemoryCache(IOptions<CacheOptions> options)
        {
            _options = options.Value;
        }
        
        public async Task<TValue> Get(TKey key, Func<TKey, Task<TValue>> valueFactory)
        {
            if (_store.TryGetValue(key, out var item) && !item.IsStale)
            {
                return item.Value;
            }
            
            var value = await valueFactory(key);

            await Set(key, value);

            return value;
        }

        public Task Set(TKey key, TValue value)
        {
            return Task.Run(() => _store[key] = new CacheItem()
            {
                Expires = DateTime.Now.Add(_options.Lifespan),
                Value = value
            });
        }

        public Task Delete(TKey key)
        {
            return Task.Run(() => _store.TryRemove(key, out _));
        }

        private struct CacheItem
        {
            public TValue Value { get; set; }
            
            public DateTime Expires { get; set; }

            public bool IsStale => DateTime.Now > Expires;
        }
    }
}
