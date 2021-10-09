using Flight_Planner.Core.Dto.Responses;
using Flight_Planner.Core.Models;
using System.Collections.Generic;

namespace Flight_Planner.Core.Services
{
    public interface ISearchFlightMapper
    {
        SearchFlightResponse MapSearchFlightDto(List<Flight> flight);
    }
}
