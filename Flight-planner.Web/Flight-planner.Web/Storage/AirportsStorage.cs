using Flight_planner.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Flight_planner.Web.Storage
{
    public static class AirportsStorage
    {
        private static readonly object _flightsLock = new object();
        private static List<Airport> _airports = new List<Airport>();

        public static void AddAirport(Airport airport)
        {
            lock (_flightsLock)
            {
                _airports.Add(airport);
            }
        }

        public static void ClearAirports()
        {
            lock (_flightsLock)
            {
                _airports.Clear();
            }
        }

        public static List<Airport> GetAirportsList()
        {
            return _airports;
        }

        public static List<Airport> ReturnFoundAirports(string search)
        {
            return _airports.Where(item =>
                item.Country.ToLower().Contains(search.ToLower().Trim()) ||
                item.City.ToLower().Contains(search.ToLower().Trim()) ||
                item.AirportCode.ToLower().Contains(search.ToLower().Trim())).ToList();
        }
    }
}