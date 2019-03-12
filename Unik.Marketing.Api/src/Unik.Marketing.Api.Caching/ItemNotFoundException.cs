using System;

namespace Unik.Marketing.Api.Caching
{
    public class ItemNotFoundException<TKey> : Exception
    {
        public ItemNotFoundException(TKey key)
        {
            Key = key;
        }

        public TKey Key { get; }
    }
}
