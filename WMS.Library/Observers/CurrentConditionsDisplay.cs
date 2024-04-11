using WMS.Library.Interfaces;

namespace WMS.Library.Observers;

public class CurrentConditionsDisplay : IDisplay, IObserver
{
    private float temperature;
    private float humidity;
    private float atmosPressure;
    private WeatherData weatherData;

    public CurrentConditionsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.Subscribe(this);
    }

    public void Update(float temperature, float humidity, float atmosPressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.atmosPressure = atmosPressure;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Current weather condition right now at {DateTime.Now}: ");
        Console.WriteLine($"Temperature: {temperature}°C");
        Console.WriteLine($"Humidity: {humidity}% ");
        Console.WriteLine($"Atmospheric Pressure: {atmosPressure} hPa");
    }
}