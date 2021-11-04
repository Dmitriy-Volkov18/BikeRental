using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.Entities
{
    public enum BikeType
    {
        Road,
        Mountain,
        Touring,
        Track,
        Bmx,
        Hybrid,
        Cruiser,
        Folding,
        Kids
    }

    public enum BikeStatus
    {
        Free,
        Rented
    }

    public class Bike
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BikeType Type { get; set; }
        public decimal Price { get; set; }
        public BikeStatus Status { get; set; }
    }
}
