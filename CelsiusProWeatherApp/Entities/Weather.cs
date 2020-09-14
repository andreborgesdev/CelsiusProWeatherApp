using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CelsiusProWeatherApp.Entities
{
    public class Weather
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTimeOffset Date { get; set; }

        [Required]
        public Station Station { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string TypeOfIndicator { get; set; }
    }
}
