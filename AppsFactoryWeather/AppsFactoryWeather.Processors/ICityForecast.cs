using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppsFactoryWeather.Models;

namespace AppsFactoryWeather.Processors
{
    public interface ICityForecast
    {
        /// <summary>
        /// Get weather and weather history by search string
        /// </summary>
        /// <param name="searchString">city or german zip code</param>
        /// <returns></returns>
        Task<(CityModel Forecast, IList<CityModel> History)> GetForecastWithHistory(string searchString);
    }
}