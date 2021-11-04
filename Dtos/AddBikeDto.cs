using BikeRental.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.Dtos
{
    public class AddBikeDto
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        [Required]
        public BikeType Type { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
