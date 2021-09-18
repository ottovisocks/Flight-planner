using Flight_planner.Web.Models;
using Flight_planner.Web.Storage;
using System.Linq;

namespace Flight_planner.Web.Validators
{
    public class EqualsCheck
    {
        public static bool EqualFlightCheck(Flight flight)
        {
            return FlightStorage.GetFlightsList().Any(item =>
                item.Carrier.Equals(flight.Carrier) &&
                item.DepartureTime.Equals(flight.DepartureTime) &&
                item.ArrivalTime.Equals(flight.ArrivalTime)) &&
                EqualAirportCheck(flight.From) && EqualAirportCheck(flight.To);
        }

        public static bool EqualAirportCheck(Airport airport)
        {
            return AirportsStorage.GetAirportsList().Any(item =>
                item.Country.Equals(airport.Country) &&
                item.City.Equals(airport.City) &&
                item.AirportCode.Equals(airport.AirportCode)
                );
        }
    }
}