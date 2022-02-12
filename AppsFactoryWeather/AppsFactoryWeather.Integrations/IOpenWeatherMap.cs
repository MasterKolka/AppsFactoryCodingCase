using AppsFactoryWeather.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppsFactoryWeather.Integrations
{
    public interface IOpenWeatherMap {
        /// <summary>
        /// Get weather forecast by search string
        /// </summary>
        /// <param name="searchStr">city or german zip code</param>
        /// <returns></returns>
        Task<CityModel> GetWeather(string searchStr);
    }
}