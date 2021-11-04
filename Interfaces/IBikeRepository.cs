using BikeRental.Dtos;
using BikeRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.Interfaces
{
    interface IBikeRepository
    {
        Task<bool> AddBike(AddBikeDto addWeatherDto);
        Task<bool> UpdateBike(UpdateBikeDto updateWeatherDto);
        Task<bool> DeleteBike(int id);
        Task<ICollection<Bike>> GetAllBikes();
        Task<ICollection<Bike>> GetFreeBikes();
        Task<ICollection<Bike>> GetRentedBikes();
        Task<Bike> GetBikeById(int id);
        Task<bool> SaveAllAsync();
    }
}
