using CelsiusProWeatherApp.Entities;
using CelsiusProWeatherApp.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelsiusProWeatherApp.Controllers
{
    [ApiController]
    [Route("/stations")]
    public class StationsController : ControllerBase
    {
        private readonly ILogger<StationsController> _logger;
        private readonly IStationsRepository _stationRepository;

        public StationsController(ILogger<StationsController> logger, IStationsRepository stationRepository)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _stationRepository = stationRepository ??
                throw new ArgumentNullException(nameof(stationRepository));
        }

        //[Authorize]
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<Station>> GetStations()
        {
            var stationsFromRepo = _stationRepository.GetStations();

            // Normally we would use AutoMapper with a DTO here
            return Ok(stationsFromRepo);
        }
    }
}
