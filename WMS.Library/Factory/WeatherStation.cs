using WMS.Library.Factory;

namespace WMS.Library.Factory
{
    public class WeatherStation
    {
        public IDsiplay CreateDisplay(string typeOfDisplay)
        {
            switch (typeOfDisplay)
            {
                case "CurrentConditions":
                    return new CurrentConditionsDisplay();
                case "Statistics":
                    return new StaticsDsiplay();
                case "Forecast":
                    return new ForecastDisplay();
                default:
                    throw new ArguementException("Type of display you provided is not found or invlaid!", nameof(typeOfDisplay));
            }
        }
    }
}