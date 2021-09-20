using Flight_planner.Web.Models;
using Flight_planner.Web.Validators;
using System.Collections.Generic;
using System.Linq;

namespace Flight_planner.Web.Storage
{
    public static class FlightStorage
    {
        private static readonly object _flightsLock = new object();
        private static List<Flight> _flights = new List<Flight>();
        private static int _flightId = 0;

        public static Flight GetById(int id)
        {
            return _flights.SingleOrDefault(item => item.Id == id);
        }

        public static void ClearFlights()
        {
            lock (_flightsLock)
            {
                _flights.Clear();
            }
        }

        public static Flight AddFlight(Flight flight)
        {
            lock (_flightsLock)
            {
                flight.Id = _flightId;
                _flights.Add(flight);
                _flightId += 1;

                if (!EqualsCheck.AreAirportsEqual(flight.From))
                    AirportsStorage.AddAirport(flight.From);

                if (!EqualsCheck.AreAirportsEqual(flight.To))
                    AirportsStorage.AddAirport(flight.To);

                return flight;
            }
        }

        public static List<Flight> GetFlightsList()
        {
            return _flights;
        }

        public static void DeleteFlightById(int id)
        {
            lock (_flightsLock)
            {
                var flight = _flights.SingleOrDefault(item => item.Id == id);

                if (flight != null)
                    _flights.Remove(flight);
            }
        }

        public static Flight GetFlightById(int id)
        {
            return _flights.SingleOrDefault(item => item.Id == id);
        }
    }
}