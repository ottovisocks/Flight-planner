using Flight_planner.Web.Storage;
using Microsoft.AspNetCore.Mvc;

namespace Flight_planner.Web.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            FlightStorage.ClearFlights();
            AirportsStorage.ClearAirports();

            return Ok();
        }
    }
}