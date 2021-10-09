using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Data;

namespace Flight_Planner.Services
{
    public class DbServiceExtended : DbService, IDbServiceExtended
    {
        private static readonly object _deleteLock = new object();

        public DbServiceExtended(IFlightPlannerDbContext context) : base(context)
        {
        }

        public void DeleteAll<T>() where T : Entity
        {
            lock (_deleteLock)
            {
                _context.Set<T>().RemoveRange(_context.Set<T>());
                _context.SaveChanges();
            }
        }
    }
}
