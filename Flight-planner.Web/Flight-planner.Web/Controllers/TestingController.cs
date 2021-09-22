using Flight_planner.Web.DataBaseContext;
using Microsoft.AspNetCore.Mvc;

namespace Flight_planner.Web.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private static readonly object _flightsLock = new object();
        private readonly FlightPlannerDbContext _context;

        public TestingController(FlightPlannerDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            lock (_flightsLock)
            {
                _context.Flights.RemoveRange(_context.Flights);
                _context.Airports.RemoveRange(_context.Airports);
                _context.SaveChanges();

                return Ok();
            }
        }
    }
}