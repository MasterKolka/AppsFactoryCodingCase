using System.Collections.Generic;

namespace AppsFactoryWeather.Processors
{
    public interface ICache
    {
        /// <summary>
        /// Caches or updates value by key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">calue</param>
        void CacheOrUpdateValue(string key, object value);

        IList<T> GetValues<T>(int count = 0);
    }
}