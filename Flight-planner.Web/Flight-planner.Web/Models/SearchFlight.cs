using Flight_planner.Web.Storage;
using System.Linq;

namespace Flight_planner.Web.Models
{
    public class SearchFlight
    {
        public string From { get; set; }
        public string To { get; set; }
        public string DepartureDate { get; set; }

        public static SearchingResult FindFlights(SearchFlight search)
        {
            var flight = FlightStorage.GetFlightsList()
                .Where(item => item.From.AirportCode == search.From ||
                    item.To.AirportCode == search.To ||
                    item.DepartureTime == search.DepartureDate).ToList();

            return new SearchingResult(flight);
        }
    }
}