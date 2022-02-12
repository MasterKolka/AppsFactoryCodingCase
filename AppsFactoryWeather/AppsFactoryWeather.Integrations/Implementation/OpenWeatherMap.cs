using AppsFactoryWeather.Integrations.Models;
using AppsFactoryWeather.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AppsFactoryWeather.Integrations.Implementation
{
    public class OpenWeatherMap: IOpenWeatherMap 
    {
        private readonly string _apiKey = null;
        private const string ConfigApiKey = "OpenWeatherApiKey";
        
        private static readonly string[] Directions = new string[] { "n", "nne", "ne", "ene", "e", "ese", "se", "sse", "s", "ssw", "sw", "wsw", "w", "wnw", "nw", "nnw", "n" };
     
        private HttpClient Client { get; }
        
        public OpenWeatherMap(IHttpClientFactory clientFactory, IConfiguration config) {
            Client = clientFactory.CreateClient();
            Client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");

            _apiKey = config[ConfigApiKey];
        }
        
        /// <summary>
        /// Get weather forecast by search string
        /// </summary>
        /// <param name="searchStr">city or german zip code</param>
        /// <returns></returns>
        public async Task<CityModel> GetWeather(string searchStr) {
            try
            {
                // if search string is a number and length == 5 => zip
                var isZip = int.TryParse(searchStr, out var zip) && searchStr.Length > 0;
                var query = HttpUtility.ParseQueryString(string.Empty);
                if (isZip)
                {
                    query["zip"] = $"{searchStr},DE";
                }
                else
                {
                    query["q"] = searchStr;
                }
                query["appid"] = _apiKey;
                string queryString = $"forecast?{query.ToString()}";

                var result = await Client.GetAsync(queryString);
                var content = await result.Content.ReadAsAsync<WeatherData>();
                
                return this.FromService(content);
            }
            catch {
                // log exception
                // throw some new exception
                return null;
            }
        }

        /// <summary>
        /// Map and convert data from API to our model
        /// </summary>
        /// <param name="weatherData"></param>
        /// <returns></returns>
        private CityModel FromService(WeatherData weatherData)
        {
            var result = new CityModel();
            if (weatherData != null && weatherData.Forecast?.Count > 0)
            {
                result.City = $"{weatherData?.City?.Name ?? ""}, {weatherData?.City?.Country ?? ""}";
                
                //converting to our model
                var converted = weatherData.Forecast.Select(f => new ForecastModel()
                {
                    AvgHumidity = f.Humidity,
                    AvgPressure = f.Pressure,
                    AvgTemperature = f.Temp,
                    Date = DateTimeOffset.FromUnixTimeSeconds(f.Dt).Date,
                    WeatherKind = GetWeatherKind(f.WeatherKindId),
                    WindDirection = GetWindDirection(f.WindDegree),
                    WindSpeed = f.WindSpeed
                }).ToList();

                // grouping by day and calculating average
                var grouped = converted.GroupBy(f => f.Date);

                result.Forecast = (from dayForecast in grouped
                let forecastList = dayForecast.ToList()
                select new ForecastModel()
                {
                    AvgHumidity = Math.Round(forecastList.Average(f => f.AvgHumidity)),
                    AvgPressure = Math.Round(forecastList.Average(f => f.AvgPressure)),
                    AvgTemperature = Math.Round(forecastList.Average(f => f.AvgTemperature)),
                    Date = dayForecast.Key,
                    WeatherKind = forecastList.GroupBy(f => f.WeatherKind).Select(fg => new {WeatherKind = fg.Key, Count = fg.Count()}).OrderByDescending(fg => fg.Count).First().WeatherKind,
                    WindDirection = forecastList.OrderByDescending(fg => fg.WindSpeed).First().WindDirection,
                    WindSpeed = Math.Round(forecastList.Average(f => f.WindSpeed), 1)
                })
                .ToList();
            }
            else
            {
                result.City = "City not found. Please, try again.";
            }
            return result;
        }

        /// <summary>
        /// Get formal direction of wind by degree to display it 
        /// </summary>
        /// <param name="degree">wind degree</param>
        /// <returns></returns>
        private string GetWindDirection(decimal degree)
        {
            var degreeNormalized = degree % 360;
            var index = (int)Math.Floor((degreeNormalized + 11.25m) / 22.5m);

            return Directions[index];
        }

        /// <summary>
        /// Get formal weather kind o display it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetWeatherKind(int id)
        {
            var groupNumber = id / 100;
            switch (@groupNumber)
            {
                case 2:
                    return "lightning";
                case 3:
                    return "showers";
                case 5:
                    return "rain";
                case 6:
                    return "snow";
                case 7:
                    return "fog";
                case 8:
                    return id == 800 ? "day-sunny" : "cloudy";
                default:
                    return null;
            }
        }
    }
}