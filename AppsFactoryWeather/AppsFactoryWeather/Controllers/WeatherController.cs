using AppsFactoryWeather.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppsFactoryWeather.Processors;
using Microsoft.AspNetCore.Cors;

namespace AppsFactoryWeather.Controllers
{
    [EnableCors]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly ICityForecast _cityForecast = null;

        public WeatherController(ICityForecast cityForecast)
        {
            _cityForecast = cityForecast;
        }

        [HttpGet]
        public async Task<ActionResult<WeatherResponseModel>> Forecast(string s)
        {
            var weather = await _cityForecast.GetForecastWithHistory(s);
            return new WeatherResponseModel()
            {
                Forecast = weather.Forecast,
                History = weather.History
            };
        }
    }
}
