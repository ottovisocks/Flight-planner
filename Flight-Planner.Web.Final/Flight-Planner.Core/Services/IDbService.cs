using Flight_Planner.Core.Models;
using System.Linq;

namespace Flight_Planner.Core.Services
{
    public interface IDbService
    {
        IQueryable<T> Query<T>() where T : Entity;

        T GetById<T>(int id) where T : Entity;

        void Create<T>(T entity) where T : Entity;

        void Update<T>(T entity) where T : Entity;

        void Delete<T>(T entity) where T : Entity;
    }
}
