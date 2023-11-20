namespace Sensor.Publisher.Data
{
    public interface IWeatherDataPublisher
    {
        Task ProduceAsync(Weather weather);
    }
}
