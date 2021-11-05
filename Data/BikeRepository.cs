using BikeRental.Data.Enums;
using BikeRental.Dtos;
using BikeRental.Entities;
using BikeRental.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.Data
{
    public class BikeRepository : IBikeRepository
    {
        private readonly DataContext _context;

        public BikeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBike(AddBikeDto addBikeDto)
        {
            var newBike = new Bike
            {
                Name = addBikeDto.Name,
                Type = addBikeDto.Type,
                Price = addBikeDto.Price,
                Status = BikeStatus.Free
            };

            _context.Bikes.Add(newBike);

            return await SaveAllAsync();
        }

        public async Task<bool> ChangeBikeStatus(int id)
        {
            var bike = await _context.Bikes.SingleOrDefaultAsync(b => b.Id == id);

            if (bike is null) return await Task.FromResult(false);

            bike.Status = bike.Status == BikeStatus.Free ? BikeStatus.Rented : BikeStatus.Free;

            return await SaveAllAsync();
        }

        public async Task<bool> DeleteBike(int id)
        {
            var bike = await _context.Bikes.SingleOrDefaultAsync(b => b.Id == id);

            if(bike is null) return await Task.FromResult(false);

            _context.Bikes.Remove(bike);

            return await SaveAllAsync();
        }

        public async Task<IEnumerable<Bike>> GetAllBikes()
        {
            return await _context.Bikes.ToListAsync();
        }

        public async Task<Bike> GetBikeById(int id)
        {
            var bike = await _context.Bikes.SingleOrDefaultAsync(b => b.Id == id);

            if (bike is null) return null;

            return bike;
        }

        public async Task<IEnumerable<Bike>> GetFreeBikes()
        {
            var freeBikes = await _context.Bikes.Where(b => b.Status == BikeStatus.Free).ToListAsync();

            if (freeBikes.Count == 0) return null;

            return freeBikes;
        }

        public async Task<IEnumerable<Bike>> GetRentedBikes()
        {
            var rentedBikes = await _context.Bikes.Where(b => b.Status == BikeStatus.Rented).ToListAsync();

            if (rentedBikes.Count == 0) return null;

            return rentedBikes;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateBike(int id, UpdateBikeDto updateBikeDto)
        {
            var updateBike = await _context.Bikes.Where(b => b.Id == id).SingleOrDefaultAsync();

            if (updateBike is null) return await Task.FromResult(false);

            updateBike.Name = updateBikeDto.Name;
            updateBike.Type = updateBikeDto.Type;
            updateBike.Price = updateBikeDto.Price;

            return await SaveAllAsync();
        }
    }
}
