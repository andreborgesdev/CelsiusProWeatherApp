using CelsiusProWeatherApp.DataAccess;
using CelsiusProWeatherApp.Entities;
using CelsiusProWeatherApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelsiusProWeatherApp.Services
{
    public class StationRepository : IStationsRepository, IDisposable
    {
        private readonly WeatherContext _context;

        public StationRepository(WeatherContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Station> GetStations()
        {
            return _context.Stations.ToList<Station>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
