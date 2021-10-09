using Flight_Planner.Core.Models;

namespace Flight_Planner.Core.Services
{
    public interface IDbServiceExtended : IDbService
    {
        void DeleteAll<T>() where T : Entity;
    }
}
