using System.Collections.Generic;
using System.Linq;

namespace AppsFactoryWeather.Processors.Implementation
{
    public class Cache: ICache
    {
        // PoC solution. We can use any other cache technology instead of this
        private readonly List<KeyValuePair<string, object>> _cache = new List<KeyValuePair<string, object>>(); 
        
        /// <summary>
        /// Caches or updates value by key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">calue</param>
        public void CacheOrUpdateValue(string key, object value)
        {
            _cache.RemoveAll(c => c.Key == key);
            _cache.Insert(0, new KeyValuePair<string, object>(key, value));
        }

        /// <summary>
        /// Receives all or some count of cached objects by type
        /// </summary>
        /// <param name="count">max returned count</param>
        /// <typeparam name="T">returned type</typeparam>
        /// <returns></returns>
        public IList<T> GetValues<T>(int count = 0)
        {
            var values = _cache.Select(c => c.Value).Where(x => x is T);
            if (count > 0)
            {
                values = values.Take(count);
            }
            return values.Cast<T>().ToList();
        }
    }
}