using Microsoft.Extensions.Configuration;
using InterviewReviewer.Interfaces;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using InterviewReviewer.Modules.Models;

namespace InterviewReviewer.Modules
{
    internal class WeatherForecaster : IModule
    {
        public string Name { get; set; } = "Weather Forecaster";
        private readonly string _apiKey;
        private readonly string _apiHost = "weatherapi-com.p.rapidapi.com";
        private readonly string _uriBase = "https://weatherapi-com.p.rapidapi.com/current.json?q=";

        public WeatherForecaster()
        {
            var directory = Directory.GetCurrentDirectory();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                .Build();

            _apiKey = config["weatherApiKey"] ?? "";
        }

        public string DescribeModule()
        {
            return "Enter a zip code, and this module will show the current weather using the WeatherAPI.com web API.";
        }

        public void Run()
        {
            var zipCode = "";
            var isValidZipCode = false;

            while (isValidZipCode == false)
            {
                Console.Write("Please enter a five digit US Zip Code: ");
                zipCode = Console.ReadLine() ?? "";
                isValidZipCode = ValidateZipCode(zipCode);
            }

            Task.Run(async () =>
            {
                await QueryWeather(zipCode);
            }).Wait();
        }

        private async Task QueryWeather(string zipCode)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = GetUri(zipCode),
                    Headers =
                    {
                        { "X-RapidAPI-Key", _apiKey },
                        { "X-RapidAPI-Host", _apiHost },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var weatherData = Deserialize(body);
                    DisplayWeather(weatherData);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Oops, an error occurred: {0}", exception.Message);
                // To Do: Logging
            }
        }

        private bool ValidateZipCode(string zipCode)
        {
            return Regex.IsMatch(zipCode, @"^\d{5}$"); // Validates zipCode is a 5 digit number
        }

        private Uri GetUri(string zipCode)
        {
            var uri = String.Format("{0}{1}", _uriBase, zipCode);
            return new Uri(uri);
        }

        private WeatherData Deserialize(string json)
        {
            var data = JsonConvert.DeserializeObject<WeatherData>(json);
            return data != null ? data : new WeatherData();
        }

        private void DisplayWeather(WeatherData weatherData)
        {
            Console.WriteLine("\n\nThe weather in {0}, {1}, {2} is as follows:", weatherData.location.name, weatherData.location.region, weatherData.location.country);
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Conditions: {0}", weatherData.current.condition.text);
            Console.WriteLine("Temperature: {0} Degrees F, but feels like {1} Degrees F.", weatherData.current.temp_f, weatherData.current.feelslike_f);
            Console.WriteLine("Humidity: {0}%", weatherData.current.humidity);
            Console.WriteLine("Winds: {0} MPH out of the {1} with gusts up to {2} MPH.", weatherData.current.wind_mph, weatherData.current.wind_dir, weatherData.current.gust_mph);
            Console.WriteLine("Barometric Pressure: {0} in.", weatherData.current.pressure_in);
        }
    }
}