using BikeRental.Data;
using BikeRental.Dtos;
using BikeRental.Entities;
using BikeRental.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikeRentalController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IBikeRepository _bikeRepository;

        public BikeRentalController(DataContext context, IBikeRepository bikeRepository)
        {
            _context = context;
            _bikeRepository = bikeRepository;
        }

       [HttpPost]
       public async Task<ActionResult> AddBike(AddBikeDto addBikeDto)
        {
            var result = await _bikeRepository.AddBike(addBikeDto);

            if (result) return Created("msg", "New bike has been created successfully");

            return BadRequest("Something went wrong");
        }

        [HttpGet("all-bikes")]
        public async Task<ActionResult<IEnumerable<Bike>>> GellAllBikes()
        {
            var bikes = await _bikeRepository.GetAllBikes();

            if (bikes is null) return NotFound("There are no any bikes");

            return Ok(bikes);
        }

        [HttpGet("free-bikes")]
        public async Task<ActionResult<IEnumerable<Bike>>> GellFreeBikes()
        {
            var freeBikes = await _bikeRepository.GetFreeBikes();

            if (freeBikes is null) return NotFound("There are no free bikes");

            return Ok(freeBikes);
        }

        [HttpGet("rented-bikes")]
        public async Task<ActionResult<IEnumerable<Bike>>> GellRentedBikes()
        {
            var rentedBikes = await _bikeRepository.GetRentedBikes();

            if (rentedBikes is null) return NotFound("There are no rented bikes");

            return Ok(rentedBikes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBikeById(int id)
        {
            var bike = await _bikeRepository.GetBikeById(id);

            if (bike is null) return NotFound("There are no bike with such id");

            return Ok(bike);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBike(int id, UpdateBikeDto updateBikeDto)
        {
            var result = await _bikeRepository.UpdateBike(id, updateBikeDto);

            if (result) return Ok("The bike has been updated successfully");

            return BadRequest("Something went wrong");
        }

        [HttpPut("change-bike-status/{id}")]
        public async Task<ActionResult> UpdateBike(int id)
        {
            var result = await _bikeRepository.ChangeBikeStatus(id);

            if (result) return Ok("The bike status has been changed successfully");

            return BadRequest("Something went wrong");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBike(int id)
        {
            var result = await _bikeRepository.DeleteBike(id);

            if (result) return Ok("The bike has been deleted successfully");

            return BadRequest("Something went wrong");
        }
    }
}
