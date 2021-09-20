using Flight_planner.Web.Models;
using Flight_planner.Web.Storage;
using System.Linq;

namespace Flight_planner.Web.Validators
{
    public class EqualsCheck
    {
        public static bool AreFlightsEqual(Flight flight)
        {
            return FlightStorage.GetFlightsList().Any(item =>
                item.Carrier.Equals(flight.Carrier) &&
                item.DepartureTime.Equals(flight.DepartureTime) &&
                item.ArrivalTime.Equals(flight.ArrivalTime)) &&
                AreAirportsEqual(flight.From) && AreAirportsEqual(flight.To);
        }

        public static bool AreAirportsEqual(Airport airport)
        {
            return AirportsStorage.GetAirportsList().Any(item =>
                item.Country.Equals(airport.Country) &&
                item.City.Equals(airport.City) &&
                item.AirportCode.Equals(airport.AirportCode)
                );
        }
    }
}