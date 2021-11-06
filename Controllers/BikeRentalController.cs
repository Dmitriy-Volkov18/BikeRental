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
        private readonly IBikeRepository _bikeRepository;

        public BikeRentalController(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

       [HttpPost]
       public async Task<ActionResult<Bike>> AddBike(AddBikeDto addBikeDto)
        {
            var bike = await _bikeRepository.AddBike(addBikeDto);

            if (bike != null) return Ok(bike);

            return BadRequest("Something went wrong");
        }

        [HttpGet("all-bikes")]
        public async Task<ActionResult<IEnumerable<Bike>>> GellAllBikes()
        {
            var bikes = await _bikeRepository.GetAllBikes();

            return Ok(bikes);
        }

        [HttpGet("free-bikes")]
        public async Task<ActionResult<IEnumerable<Bike>>> GellFreeBikes()
        {
            var freeBikes = await _bikeRepository.GetFreeBikes();

            return Ok(freeBikes);
        }

        [HttpGet("rented-bikes")]
        public async Task<ActionResult<IEnumerable<Bike>>> GellRentedBikes()
        {
            var rentedBikes = await _bikeRepository.GetRentedBikes();

            return Ok(rentedBikes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bike>> GetBikeById(int id)
        {
            var bike = await _bikeRepository.GetBikeById(id);

            if (bike is null) return NotFound("There are no bike with such id");

            return Ok(bike);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Bike>> UpdateBike(int id, UpdateBikeDto updateBikeDto)
        {
            var bike = await _bikeRepository.UpdateBike(id, updateBikeDto);

            if (bike != null) return Ok(bike);

            return BadRequest("Something went wrong");
        }

        [HttpPut("change-bike-status/{id}")]
        public async Task<ActionResult<Bike>> ChangeBikeStatus(int id)
        {
            var bike = await _bikeRepository.ChangeBikeStatus(id);

            if (bike != null) return Ok(bike);

            return BadRequest("Something went wrong");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Bike>> DeleteBike(int id)
        {
            var bike = await _bikeRepository.DeleteBike(id);

            if (bike != null) return Ok(bike);

            return BadRequest("Something went wrong");
        }
    }
}
