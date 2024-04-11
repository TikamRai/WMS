using WMS.Library.Interfaces;
using WMS.Library.Observers;

namespace WMS.Library.Factory;

public class WeatherStation
{
    private WeatherData weatherData;

    public WeatherStation(WeatherData weatherData)
    {
        this.weatherData = weatherData;
    }

    public IDisplay CreateDisplay(string typeOfDisplay)
    {
        switch (typeOfDisplay)
        {
            case "CurrentConditions":
                return new CurrentConditionsDisplay(weatherData);
            case "Statistics":
                return new StatisticsDisplay(weatherData);
            case "Forecast":
                return new ForecastDisplay(weatherData);
            default:
                throw new ArgumentException("Type of display you provided is not found or invalid!", nameof(typeOfDisplay));
        }
    }
}
