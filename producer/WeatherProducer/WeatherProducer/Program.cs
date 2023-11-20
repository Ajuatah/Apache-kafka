using Confluent.Kafka;
using Newtonsoft.Json;

// create configuration
var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092",

    //represent number of acknoledgement 

    //Acks = Acks.Leader

};

// create producer 
using var producer = new ProducerBuilder<Null, string>(config).Build();

try
{
    string? state;
    while ((state = Console.ReadLine()) !=null )
    {
        var response = await producer.ProduceAsync("weather-topic",

       new Message<Null, string> { Value = JsonConvert.SerializeObject(
           new Weather(state, 70)) });
        Console.WriteLine(response.Value);

    }
   
}
catch (ProduceException<Null, string >  ex)
{
    Console.WriteLine(ex.Message);
}

public record Weather ( string State , int Temparature );

