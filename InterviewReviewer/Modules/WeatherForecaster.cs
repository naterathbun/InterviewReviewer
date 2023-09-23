using Microsoft.Extensions.Configuration;
using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Modules
{
    internal class WeatherForecaster : IModule
    {
        public string Name { get; set; } = "Weather Forecaster";
        private readonly string _apiKey;

        public WeatherForecaster()
        {
            var directory = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                .Build();

            _apiKey = config["OpenWeatherMapApiKey"] ?? "";
        }

        public string DescribeModule()
        {
            return "Enter a zip code, and this module will tell you the current weather using the OpenWeatherMap.org web API.";
        }

        public void Run()
        {
            // take in a zip code
            // verify validity
            // Call openweathermap.org API
            // display the weather

        }
    }
}
