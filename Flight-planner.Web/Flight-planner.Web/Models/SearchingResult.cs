using System.Collections.Generic;
using System.Linq;

namespace Flight_planner.Web.Models
{
    public class SearchingResult
    {
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public List<Flight> Items { get; set; }

        public SearchingResult(List<Flight> items)
        {
            Page = 0;
            TotalItems = items.Count();
            Items = items;
        }
    }
}