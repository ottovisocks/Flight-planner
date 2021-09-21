using Flight_planner.Web.Models;
using Flight_planner.Web.Storage;
using Flight_planner.Web.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Flight_planner.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [Route("airports")]
        public IActionResult SearchAirports(string search)
        {
            return Ok(AirportsStorage.ReturnFoundAirports(search));
        }

        [HttpPost]
        [Route("flights/search")]
        public IActionResult SearchFlights(SearchFlight search)
        {
            if (!InputDataValidator.IsValidSearchFlight(search) || search.To.Equals(search.From))
                return BadRequest();

            return Ok(SearchFlight.FindFlights(search));
        }

        [HttpGet]
        [Route("flights/{id}")]
        public ActionResult<Flight> ReturnFlightById(int id)
        {
            var flight = FlightStorage.GetFlightById(id);

            if (flight != null)
                return flight;

            return NotFound();
        }
    }
}