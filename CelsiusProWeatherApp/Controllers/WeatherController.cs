using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CelsiusProWeatherApp.Entities;
using CelsiusProWeatherApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CelsiusProWeatherApp.Controllers
{
    [ApiController]
    [Route("/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherRepository _weatherRepository;

        public WeatherController(ILogger<WeatherController> logger, IWeatherRepository weatherRepository)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _weatherRepository = weatherRepository ??
                throw new ArgumentNullException(nameof(weatherRepository));
        }

        //[Authorize]
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<Weather>> GetStations()
        {
            var weatherFromRepo = _weatherRepository.GetWeather();

            // Normally we would use AutoMapper with a DTO here
            return Ok(weatherFromRepo);
        }
    }
}
