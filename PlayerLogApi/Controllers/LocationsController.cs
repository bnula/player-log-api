using MediatR;
using Microsoft.AspNetCore.Mvc;
using PlayerLogApi.Data.Models;
using PlayerLogApi.Handlers.Locations.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerLogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : Controller
    {
        private readonly ISender _sender;

        public LocationsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<LocationsResult> FindLocations()
        {
            var request = new FindLocationsQueryRequest();
            var result = await _sender.Send(request);
            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLocation(int id)
        {
            var request = new GetLocationQueryRequest { Id = id };
            var result = await _sender.Send(request);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
