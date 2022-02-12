using System.Collections.Generic;
using System.Threading.Tasks;
using AppsFactoryWeather.Integrations;
using AppsFactoryWeather.Models;

namespace AppsFactoryWeather.Processors.Implementation
{
    public class CityForecast: ICityForecast
    {
        private readonly IOpenWeatherMap _openWeatherMap = null;
        private readonly ICache _cache = null;

        public CityForecast(IOpenWeatherMap openWeatherMap, ICache cache)
        {
            _openWeatherMap = openWeatherMap;
            _cache = cache;
        }
        
        /// <summary>
        /// Get weather and weather history by search string
        /// </summary>
        /// <param name="searchString">city or german zip code</param>
        /// <returns></returns>
        public async Task<(CityModel Forecast, IList<CityModel> History)> GetForecastWithHistory(string searchString)
        {
            var forecast = _openWeatherMap == null ? null : await _openWeatherMap.GetWeather(searchString);
            IList<CityModel> history = _cache?.GetValues<CityModel>(12);
            
            if (forecast?.Forecast?.Count > 0)
            {
                _cache?.CacheOrUpdateValue(forecast.City, forecast);
            }

            return (forecast, history);
        }
    }
}