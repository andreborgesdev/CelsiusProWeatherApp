﻿using CelsiusProWeatherApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelsiusProWeatherApp.Services.Interfaces
{
    public interface IStationsRepository
    {
        IEnumerable<Station> GetStations();
    }
}
