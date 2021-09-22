using Flight_planner.Web.DataBaseContext;
using Flight_planner.Web.Models;
using Flight_planner.Web.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Flight_planner.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly FlightPlannerDbContext _context;

        public CustomerController(FlightPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("airports")]
        public IActionResult SearchAirports(string search)
        {
            var foundAirports = _context.Airports.Where(item =>
                item.Country.ToLower().Contains(search.ToLower().Trim()) ||
                item.City.ToLower().Contains(search.ToLower().Trim()) ||
                item.AirportCode.ToLower().Contains(search.ToLower().Trim())).ToList();

            return Ok(foundAirports);
        }

        [HttpPost]
        [Route("flights/search")]
        public IActionResult SearchFlights(SearchFlight search)
        {
            if (!InputDataValidator.IsValidSearchFlight(search) || search.To.Equals(search.From))
                return BadRequest();

            return Ok(SearchFlight.FindFlights(search, _context));
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult ReturnFlightById(int id)
        {
            var flight = _context.Flights
                .Include(item => item.From)
                .Include(item => item.To)
                .SingleOrDefault(item => item.Id == id);

            if (flight is null)
                return NotFound();

            return Ok(flight);
        }
    }
}