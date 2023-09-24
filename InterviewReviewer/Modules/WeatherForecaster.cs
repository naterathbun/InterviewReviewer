using Microsoft.Extensions.Configuration;
using InterviewReviewer.Interfaces;
using InterviewReviewer.Weather;
using Newtonsoft.Json;

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
            return "Enter a zip code, and this module will tell you the current weather using the WeatherAPI.com web API.";
        }

        public void Run()
        {
            Console.Write("Please enter a US Zip Code: ");
            var zipCode = Console.ReadLine() ?? "";

            // To Do: Zip code validation

            Task.Run(async () =>
            {
                await RunAsync(zipCode);
            }).Wait();
        }

        private async Task RunAsync(string zipCode)
        {
            // To Do: Try/Catch

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

        private Uri GetUri(string zipCode)
        {
            var uri = String.Format("{0}{1}", _uriBase, zipCode);
            return new Uri(uri);
        }

        private WeatherData Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<WeatherData>(json);
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