using Flight_planner.Web.Models;
using System;

namespace Flight_planner.Web.Validators
{
    public class InputDataValidator
    {
        public static bool IsValid(Flight flight)
        {
            return flight != null &&
                !string.IsNullOrEmpty(flight.Carrier) &&
                !string.IsNullOrEmpty(flight.DepartureTime) &&
                !string.IsNullOrEmpty(flight.ArrivalTime) &&
                IsValidAirport(flight.From) && IsValidAirport(flight.To) &&
                IsDifferentAirport(flight.From, flight.To) &&
                IsValidDate(flight.DepartureTime, flight.ArrivalTime);
        }

        public static bool IsValidAirport(Airport airport)
        {
            return airport != null &&
                !string.IsNullOrEmpty(airport.Country) &&
                !string.IsNullOrEmpty(airport.City) &&
                !string.IsNullOrEmpty(airport.AirportCode);
        }

        public static bool IsDifferentAirport(Airport from, Airport to)
        {
            return !from.AirportCode.Trim().ToLower().Equals(to.AirportCode.Trim().ToLower());
        }

        public static bool IsValidDate(string departureTime, string arrivalTime)
        {
            if (!string.IsNullOrEmpty(departureTime) && !string.IsNullOrEmpty(arrivalTime))
                return DateTime.Parse(arrivalTime) > DateTime.Parse(departureTime);

            return false;
        }

        public static bool IsValidSearchFlight(SearchFlight search)
        {
            return search != null &&
                !string.IsNullOrEmpty(search.From) ||
                !string.IsNullOrEmpty(search.To) ||
                !string.IsNullOrEmpty(search.DepartureDate);
        }
    }
}