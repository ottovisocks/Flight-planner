using Flight_planner.Web.DataBaseContext;
using Flight_planner.Web.Models;
using System.Linq;

namespace Flight_planner.Web.Validators
{
    public class EqualsCheck
    {
        public static bool AreFlightsEqual(Flight flight, FlightPlannerDbContext context)
        {
            return context.Flights.Any(item =>
                item.Carrier.Equals(flight.Carrier) &&
                item.DepartureTime.Equals(flight.DepartureTime) &&
                item.ArrivalTime.Equals(flight.ArrivalTime)) &&
                AreAirportsEqual(flight.From, context) && AreAirportsEqual(flight.To, context);
        }

        public static bool AreAirportsEqual(Airport airport, FlightPlannerDbContext context)
        {
            return context.Airports.Any(item =>
                item.Country.Equals(airport.Country) &&
                item.City.Equals(airport.City) &&
                item.AirportCode.Equals(airport.AirportCode)
                );
        }
    }
}