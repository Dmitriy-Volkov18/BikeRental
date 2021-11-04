using BikeRental.Dtos;
using BikeRental.Entities;
using BikeRental.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.Data
{
    public class BikeRepository : IBikeRepository
    {
        public Task<bool> AddBike(AddBikeDto addWeatherDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBike(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Bike>> GetAllBikes()
        {
            throw new NotImplementedException();
        }

        public Task<Bike> GetBikeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Bike>> GetFreeBikes()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Bike>> GetRentedBikes()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBike(UpdateBikeDto updateWeatherDto)
        {
            throw new NotImplementedException();
        }
    }
}
