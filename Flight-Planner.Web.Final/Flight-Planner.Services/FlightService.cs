using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Dto.Responses;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Flight_Planner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public Flight GetFullFlightById(int id)
        {
            return _context.Flights
                .Include(item => item.From)
                .Include(item => item.To)
                .SingleOrDefault(item => item.Id == id);
        }

        public List<Flight> FindFlights(SearchFlightRequest search)
        {
            return _context.Flights.Where(item => item.From.AirportCode == search.From ||
                item.To.AirportCode == search.To ||
                item.DepartureTime == search.DepartureDate).ToList();
        }

        public bool Exists(Flight flight)
        {
            return _context.Flights.Any(item => item.ArrivalTime == flight.ArrivalTime
                && item.DepartureTime == flight.DepartureTime
                && item.Carrier == flight.Carrier
                && item.From.AirportCode == flight.From.AirportCode
                && item.To.AirportCode == flight.To.AirportCode);
        }

        public SearchFlightResponse MapFromDto(List<Flight> flight)
        {
            return new SearchFlightResponse
            {
                Page = 0,
                TotalItems = flight.Count,
                Items = flight
            };
        }
    }
}
