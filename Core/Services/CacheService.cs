using Domain.Contracts;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CacheService(ICacheRepository cacheRepository) : ICacheService
    {
        public async Task<string?> GetCachedValueAsync(string key)
        {
            return await cacheRepository.GetAsync(key);
        }

        public async Task SetCachedValueAsync(string key, object value, TimeSpan duration)
        {
             await cacheRepository.SetAsync(key,value,duration);
        }
    }
}
