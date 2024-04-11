using System;
using System.Collections.Generic;
using System.Linq;
using WMS.Library.Interfaces;

namespace WMS.Library.Observers;

public class StatisticsDisplay : IDisplay, IObserver
{
    private List<float> tempList = new List<float>();
    private WeatherData weatherData;

    public StatisticsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.Subscribe(this);
    }

    public void Update(float temperature, float humidity, float atmosPressure)
    {
        tempList.Add(temperature);
        Display();
    }

    public void Display()
    {
        if (tempList.Count > 0)
        {
            float tempAvg = tempList.Average();
            float tempMax = tempList.Max();
            float tempMin = tempList.Min();

            Console.WriteLine($"Average Temperature: {tempAvg:F1}°C");
            Console.WriteLine($"Maximum Temperature: {tempMax:F1}°C");
            Console.WriteLine($"Minimum Temperature: {tempMin:F1}°C");
        }
    }

}