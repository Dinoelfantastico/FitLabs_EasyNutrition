using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services
{
    public interface ISessionService
    {
        Task<IEnumerable<Session>> ListAsync();
        Task<IEnumerable<Session>> ListByUserIdAsync(int userId);

        Task<SessionResponce> GetByIdAsync(int id);
        Task<SessionResponce> SaveAsync(Session session);
        Task<SessionResponce> UpdateAsync(int id, Session session);
        Task<SessionResponce> DeleteAsync(int id);
    }
}
