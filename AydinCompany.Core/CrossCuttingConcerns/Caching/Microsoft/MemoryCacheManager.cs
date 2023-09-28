using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;
using NHibernate.Util;

namespace AydinCompany.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache => MemoryCache.Default;
        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public void Add(string key, object data, int cacheTime = 60)
        {
            if (data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime)
            };
            Cache.Add(key, data, policy);
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = Cache.Where(d => regex.IsMatch(d.Key)).Select(d => d.Key).ToList();
            keysToRemove.ForEach(key =>
            {
                Remove(key);
            });
        }

        public void Clear()
        {
            Cache.ForEach(item =>
            {
                Remove(item.Key);
            });
        }
    }
}
