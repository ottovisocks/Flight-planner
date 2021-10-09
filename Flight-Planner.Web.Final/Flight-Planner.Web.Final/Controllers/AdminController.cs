using AutoMapper;
using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Dto.Responses;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Flight_Planner.Web.Final.Controllers
{
    [Authorize]
    [Route("admin-api")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private static readonly object _flightsLock = new object();
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IAddFlightValidator> _validators;

        public AdminController(IFlightService flightService, IMapper mapper, 
            IEnumerable<IAddFlightValidator> validators)
        {
            _flightService = flightService;
            _mapper = mapper;
            _validators = validators;
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult GetFlight(int id)
        {
            var flight = _flightService.GetFullFlightById(id);

            if (flight is null)
                return NotFound();

            var mapping = _mapper.Map<FlightResponse>(flight);

            return Ok(mapping);
        }

        [HttpPut]
        [Route("flights")]
        public IActionResult PutFlight(FlightRequest request)
        {
            lock (_flightsLock)
            {
                if (!_validators.All(item => item.IsValid(request)))
                    return BadRequest();

                var flight = _mapper.Map<Flight>(request);

                if (_flightService.Exists(flight))
                    return Conflict();

                _flightService.Create(flight);

                var mapping = _mapper.Map<FlightResponse>(flight);

                return Created("", mapping);
            }
        }

        [HttpDelete]
        [Route("flights/{id}")]
        public IActionResult DeleteFlight(int id)
        {
            lock (_flightsLock)
            {
                var flight = _flightService.GetFullFlightById(id);

                if (flight != null)
                    _flightService.Delete(flight);

                return Ok();
            }
        }
    }
}
