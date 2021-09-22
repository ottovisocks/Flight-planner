using Flight_planner.Web.DataBaseContext;
using Flight_planner.Web.Models;
using Flight_planner.Web.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flight_planner.Web.Controllers
{
    [Authorize]
    [Route("admin-api")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private static readonly object _flightsLock = new object();
        private readonly FlightPlannerDbContext _context;

        public AdminController(FlightPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult GetFlight(int id)
        {
            var flight = _context.Flights
                .Include(item => item.From)
                .Include(item => item.To)
                .SingleOrDefault(item => item.Id == id);

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
                if (EqualsCheck.AreFlightsEqual(flight, _context))
                    return Conflict();

                if (!InputDataValidator.IsValid(flight))
                    return BadRequest();

                _context.Flights.Add(flight);
                _context.SaveChanges();
                
                return Created("", flight);
            }
        }

        [HttpDelete]
        [Route("flights/{id}")]
        public IActionResult DeleteFlight(int id)
        {
            lock (_flightsLock)
            {
                var flight = _context.Flights
                    .Include(item => item.From)
                    .Include(item => item.To)
                    .SingleOrDefault(item => item.Id == id);

                if (flight != null)
                {
                    _context.Airports.Remove(flight.From);
                    _context.Airports.Remove(flight.To);
                    _context.Flights.Remove(flight);
                    _context.SaveChanges();
                }

                return Ok();
            }
        }
    }
}