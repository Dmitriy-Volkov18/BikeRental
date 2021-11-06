using BikeRental.Dtos;
using BikeRental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.Interfaces
{
    public interface IBikeRepository
    {
        Task<Bike> AddBike(AddBikeDto addBikeDto);
        Task<Bike> UpdateBike(int id, UpdateBikeDto updateBikeDto);
        Task<Bike> DeleteBike(int id);
        Task<IEnumerable<Bike>> GetAllBikes();
        Task<IEnumerable<Bike>> GetFreeBikes();
        Task<IEnumerable<Bike>> GetRentedBikes();
        Task<Bike> GetBikeById(int id);
        Task<Bike> ChangeBikeStatus(int id);
        Task<bool> SaveAllAsync();
    }
}
