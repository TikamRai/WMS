using System;
using WMS.Library;
using WMS.Library.Factory;
using WMS.Library.Observers;

namespace WMS.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        WeatherData weatherData = WeatherData.GetInstance();

        weatherData.RandomUpdate(5000);

        WeatherStation weatherStation = new WeatherStation(weatherData);

        var currentConditionsDisplay = weatherStation.CreateDisplay("CurrentConditions");
        var statisticsDisplay = weatherStation.CreateDisplay("Statistics");
        var forecastDisplay = weatherStation.CreateDisplay("Forecast");

        Task.Delay(2000).Wait();
        Console.WriteLine("Weather updates are ongping. Press any key to stop and exit...");
        Console.ReadKey();
    }
}
