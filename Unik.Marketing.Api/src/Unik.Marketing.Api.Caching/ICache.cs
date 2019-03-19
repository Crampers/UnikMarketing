using System;
using System.Threading.Tasks;

namespace Unik.Marketing.Api.Caching
{
    public interface ICache<TKey, TValue>
    {
        Task<TValue> Get(TKey key, Func<TKey, Task<TValue>> valueFactory);

        Task Set(TKey key, TValue value);

        Task Delete(TKey key);
    }
}
