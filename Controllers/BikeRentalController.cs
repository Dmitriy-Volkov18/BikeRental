using BikeRental.Data;
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

        public BikeRentalController(DataContext context)
        {
            _context = context;
        }

       
    }
}
