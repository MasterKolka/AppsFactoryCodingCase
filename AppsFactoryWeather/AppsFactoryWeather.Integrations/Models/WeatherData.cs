using AppsFactoryWeather.Integrations.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AppsFactoryWeather.Integrations.Models
{
    [JsonObject]
    public class WeatherData
    {
        [JsonProperty("city")]
        public CityData City { get; set; }

        [JsonProperty("list")]
        public List<ForecastData> Forecast { get; set; }
    }

    [JsonObject]
    public class CityData
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }

    [JsonConverter(typeof(JsonPathConverter))]
    [JsonObject]
    public class ForecastData
    {
        [JsonProperty("dt")]
        public long Dt { get; set; }
        [JsonProperty("main.temp")]
        public decimal Temp { get; set; }
        [JsonProperty("main.pressure")]
        public decimal Pressure { get; set; }
        [JsonProperty("main.humidity")]
        public decimal Humidity { get; set; }
        [JsonProperty("weather[0].id")]
        public int WeatherKindId { get; set; }
        [JsonProperty("wind.speed")]
        public decimal WindSpeed { get; set; }
        [JsonProperty("wind.deg")]
        public decimal WindDegree { get; set; }
    }
}
