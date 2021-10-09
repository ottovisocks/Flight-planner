using Flight_Planner.Core.Models;
using System.Collections.Generic;

namespace Flight_Planner.Core.Services
{
    public interface IAirportService : IEntityService<Airport>
    {
        List<Airport> FindAirports(string search);
    }
}
