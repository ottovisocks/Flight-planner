using Flight_planner.Web.Models;
using Flight_planner.Web.Storage;
using Flight_planner.Web.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flight_planner.Web.Controllers
{
    [Authorize]
    [Route("admin-api")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private static readonly object _flightsLock = new object();

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult GetFlight(int id)
        {
            var flight = FlightStorage.GetById(id);
            if (flight is null)
                return NotFound();

            return Ok(flight);
        }

        [HttpPut]
        [Route("flights")]
        public IActionResult PutFlight(Flight flight)
        {
            lock (_flightsLock)
            {
                if (EqualsCheck.AreFlightsEqual(flight))
                    return Conflict();

                if (!InputDataValidator.IsValid(flight))
                    return BadRequest();

                var addFlight = FlightStorage.AddFlight(flight);

                return Created("", addFlight);
            }
        }

        [HttpDelete]
        [Route("flights/{id}")]
        public IActionResult DeleteFlight(int id)
        {
            lock (_flightsLock)
            {
                FlightStorage.DeleteFlightById(id);

                return Ok();
            }
        }
    }
}