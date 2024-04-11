using WMS.Library.Interfaces;

namespace WMS.Library.Observers;

public class ForecastDisplay : IDisplay, IObserver
{
    private float currentAtmosP = 1013.25f;
    private float lastAtmosP;
    private WeatherData weatherData;

    public ForecastDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.Subscribe(this);
    }

    public void Update(float temperature, float humidity, float atmospressure)
    {
        lastAtmosP = currentAtmosP;
        currentAtmosP = atmospressure;
        Display();
    }

    public void Display()
    {
        Console.Write("Upcoming Weather Forecast: ");
        if (currentAtmosP > lastAtmosP)
        {
            Console.WriteLine("The weather will improve. Yay!");
        } else if (currentAtmosP == lastAtmosP)
        {
            Console.WriteLine("The weather is going to continue the same.");
        } else if (currentAtmosP < lastAtmosP)
        {
            Console.WriteLine("Expect adverse weather conditions.");
        }
    }
}