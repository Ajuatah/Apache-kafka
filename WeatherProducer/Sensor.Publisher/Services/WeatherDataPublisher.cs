using Confluent.Kafka;
using Newtonsoft.Json;

namespace Sensor.Publisher.Data
{
    public class WeatherDataPublisher : IWeatherDataPublisher 
    {
        private readonly IProducer<Null, string> _producer;
        public WeatherDataPublisher(IProducer<Null, string> producer)
        {
                _producer = producer;
        }


        public async Task ProduceAsync(Weather weather) =>
            await _producer.ProduceAsync("weather-topic",
                new Message<Null, string>
                {
                    Value = JsonConvert.SerializeObject(weather)

                });


    }

    public record Weather (string state, int Temperature);
}
