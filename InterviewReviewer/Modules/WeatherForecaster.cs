using InterviewReviewer.Interfaces;

namespace InterviewReviewer.Modules
{
    internal class WeatherForecaster : IModule
    {
        public string Name { get; set; } = "Weather Forecaster";


        public string DescribeModule()
        {
            return "Enter a zip code, and this program will tell you the current weather.";
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
