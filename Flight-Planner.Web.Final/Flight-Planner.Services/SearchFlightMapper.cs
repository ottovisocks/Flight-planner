using Flight_Planner.Core.Dto.Responses;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using System.Collections.Generic;

namespace Flight_Planner.Web.Final.Mappings
{
    public class SearchFlightMapper : ISearchFlightMapper
    {
        public SearchFlightResponse MapSearchFlightDto(List<Flight> flight)
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
