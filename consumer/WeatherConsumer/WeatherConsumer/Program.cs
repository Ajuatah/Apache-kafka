using Confluent.Kafka;
using Newtonsoft.Json;

//configuration of consumer

var config = new ConsumerConfig
{
    GroupId = "weather-consumer-group",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

//creating consumer 
var consumer = new ConsumerBuilder<Null, string >(config).Build();

consumer.Subscribe("weather-topic");

CancellationTokenSource token = new();

try
{
    while (true)
    {
        var  response  = consumer.Consume(token.Token);
        if (response.Message != null)
        {
            var weather = JsonConvert.DeserializeObject<Weather>(response.Message.Value);
            Console.WriteLine($" State : {weather.State} " +
                $"Temperature as now : {weather.Temperature} F");

        }
    }

}

catch (Exception)
{

}

public record Weather(string State, int Temperature);
