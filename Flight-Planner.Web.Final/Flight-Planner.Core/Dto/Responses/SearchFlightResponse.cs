using Flight_Planner.Core.Models;
using System.Collections.Generic;

namespace Flight_Planner.Core.Dto.Responses
{
    public class SearchFlightResponse
    {
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public List<Flight> Items { get; set; }
    }
}
