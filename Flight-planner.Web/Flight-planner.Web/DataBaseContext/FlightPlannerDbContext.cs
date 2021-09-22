using Flight_planner.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Flight_planner.Web.DataBaseContext
{
    public class FlightPlannerDbContext : DbContext
    {
        public FlightPlannerDbContext(DbContextOptions<FlightPlannerDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
    }
}
