namespace WMS.Library.Interfaces;

public interface IObserver
{
    void Update(float temperature, float humidity, float atmosPressure);
}