using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Planner.Web.Final.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private static readonly object _flightsLock = new object();
        private readonly IDbServiceExtended _service;

        public TestingController(IDbServiceExtended service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            lock (_flightsLock)
            {
                _service.DeleteAll<Flight>();
                _service.DeleteAll<Airport>();

                return Ok();
            }
        }
    }
}
