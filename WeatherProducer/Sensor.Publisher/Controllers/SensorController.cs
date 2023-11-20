using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sensor.Publisher.Data;

namespace Sensor.Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly IWeatherDataPublisher _weatherDataPublisher;
        public SensorController(IWeatherDataPublisher weatherDataPublisher)
        {
            _weatherDataPublisher = weatherDataPublisher;
            
        }
        [HttpPost]
        public  async Task Post([FromBody] Weather  weather)
        {
            await _weatherDataPublisher.ProduceAsync(weather);

        }

    }
}
