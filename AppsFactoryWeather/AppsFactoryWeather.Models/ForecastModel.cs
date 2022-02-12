using System;

namespace AppsFactoryWeather.Models
{
    public class ForecastModel
    {
        public DateTime Date { get;set; }
        public decimal AvgTemperature { get;set; }
        public decimal AvgHumidity { get;set; }
        public decimal AvgPressure { get; set; }
        public string WindDirection { get;set; }
        public decimal WindSpeed { get;set; }
        public string WeatherKind { get;set; }
    }
}