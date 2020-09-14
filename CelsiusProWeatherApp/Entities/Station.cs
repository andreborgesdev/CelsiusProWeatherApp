using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CelsiusProWeatherApp.Entities
{
    public class Station
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Lon { get; set; }

        [Required]
        public string Lat { get; set; }

        public Station()
        {

        }
    }
}
