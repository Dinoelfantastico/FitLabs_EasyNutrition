using EasyNutrition.APIv_.CoreBussines.Domain.Models;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Repositories
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> LisAsync();
        Task<IEnumerable<Session>> ListByUserIdAsync(int userId);

        Task AddAsync(Session session);

        Task<Session> FindById(int userId);

        void Update(Session session);

        void Remove(Session session);
    }
}
