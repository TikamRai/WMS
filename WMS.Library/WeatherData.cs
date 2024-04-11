using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WMS.Library.Observers;
using WMS.Library.Interfaces;

namespace WMS.Library; 

public class WeatherData
{
    private static WeatherData? instance;

    private List<IObserver> subscribers;

    private float temperature;
    private float humidity;
    private float atmosPressure;

    private WeatherData()
    {
        subscribers = new List<IObserver>();
    }

    public static WeatherData GetInstance()
    {
        if (instance == null)
        {
            instance = new WeatherData();
        }
        return instance;
    }

    public void Subscribe(IObserver subscriber)
    {
        if(!subscribers.Contains(subscriber))
        {
            subscribers.Add(subscriber);
        }   
    }

    public void Unsubscribe(IObserver subscriber)
    {
        if(subscribers.Contains(subscriber))
        {
            subscribers.Remove(subscriber);
        }   
    }

    private void Notify()
    {
        foreach(var subscriber in subscribers)
        {
            subscriber.Update(temperature, humidity, atmosPressure);
        }
    }

    public void RandomUpdate(int updateInMiliseconds)
    {
        Task.Run(async () =>
        {
            Random shuffle = new Random();
            
            while (true)
            {
                float temperature = shuffle.Next(-50, 50);
                float humidity = shuffle.Next(30, 70);
                float atmosPressure = shuffle.Next(101, 1013);

                SetValues(temperature, humidity, atmosPressure);

                await Task.Delay(updateInMiliseconds);
            }
        });
    }

    public void SetValues(float temperature, float humidity, float atmosPressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.atmosPressure = atmosPressure;
        Notify();
    }
}
