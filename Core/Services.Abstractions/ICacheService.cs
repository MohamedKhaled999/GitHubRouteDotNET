using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface ICacheService
    {
        public Task SetCachedValueAsync(string key, object value, TimeSpan duration);
        public Task<string?> GetCachedValueAsync(string key);
    }
}
