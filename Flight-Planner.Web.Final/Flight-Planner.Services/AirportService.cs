using Flight_Planner.Core.Dto;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;
using System.Collections.Generic;
using System.Linq;

namespace Flight_Planner.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        public AirportService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public List<Airport> FindAirports(string search)
        {
            return _context.Airports.Where(item =>
                item.Country.ToLower().Contains(search.ToLower().Trim()) ||
                item.City.ToLower().Contains(search.ToLower().Trim()) ||
                item.AirportCode.ToLower().Contains(search.ToLower().Trim())).ToList();
        }
    }
}
