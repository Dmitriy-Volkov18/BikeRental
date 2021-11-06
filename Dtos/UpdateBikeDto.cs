using BikeRental.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.Dtos
{
    public class UpdateBikeDto
    {
        [MinLength(4)]
        public string Name { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
    }
}
