using Flight_Planner.Core.Dto.Requests;
using Flight_Planner.Core.Models;
using System.Collections.Generic;

namespace Flight_Planner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Flight GetFullFlightById(int id);
        List<Flight> FindFlights(SearchFlightRequest search);
        bool Exists(Flight flight);
    }
}
