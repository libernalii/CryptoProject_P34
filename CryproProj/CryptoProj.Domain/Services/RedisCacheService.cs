using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProj.Domain.Services
{
    public class RedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string> GetTestValue()
        {
            var cached = await _cache.GetStringAsync("test_key");

            if (cached != null)
            {
                return cached;
            }

            var value = "Hello from Redis";

            await _cache.SetStringAsync(
                "test_key",
                value,
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                });

            return value;
        }
    }
}
