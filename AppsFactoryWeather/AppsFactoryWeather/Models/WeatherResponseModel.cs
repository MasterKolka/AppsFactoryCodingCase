using System.Collections.Generic;

namespace AppsFactoryWeather.Models
{
    public class WeatherResponseModel
    {
        public CityModel Forecast { get; set; }
        public IList<CityModel> History { get; set; }
    }
}