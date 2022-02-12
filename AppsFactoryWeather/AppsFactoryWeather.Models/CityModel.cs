using System;
using System.Collections.Generic;

namespace AppsFactoryWeather.Models {
    public class CityModel {
        public string City { get;set; }
        public IList<ForecastModel> Forecast { get; set; }
    }
}