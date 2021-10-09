using AutoMapper;
using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Dto.Responses;
using Flight_Planner.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Flight_Planner.Web.Final.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;
        private readonly ISearchFlightMapper _searchFlightMapper;
        private readonly IEnumerable<ISearchFlightsValidator> _validators;

        public CustomerController(IFlightService flightService, IAirportService airportService, 
            IMapper mapper, ISearchFlightMapper searchFlightMapper, IEnumerable<ISearchFlightsValidator> validators)
        {
            _flightService = flightService;
            _airportService = airportService;
            _mapper = mapper;
            _searchFlightMapper = searchFlightMapper;
            _validators = validators;
        }

        [HttpGet]
        [Route("airports")]
        public IActionResult SearchAirports(string search)
        {
            var foundAirports = _airportService.FindAirports(search);
            var mapping = _mapper.Map<List<AirportResponse>>(foundAirports);

            return Ok(mapping);
        }

        [HttpPost]
        [Route("flights/search")]
        public IActionResult SearchFlights(SearchFlightRequest search)
        {
            if (!_validators.All(item => item.IsValid(search)))
                return BadRequest();

            var flights = _flightService.FindFlights(search);
            var mapping = _searchFlightMapper.MapSearchFlightDto(flights);

            return Ok(mapping);
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult ReturnFlightById(int id)
        {
            var flight = _flightService.GetFullFlightById(id);

            if (flight is null)
                return NotFound();

            var mapping = _mapper.Map<FlightResponse>(flight);
            return Ok(mapping);
        }
    }
}
