using EasyNutrition.APIv_.CoreBussines.Domain.Models;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Repositories
{
    public interface IProgressRepository
    {
        Task<IEnumerable<Progress>> ListAsync();
        Task<IEnumerable<Progress>> ListBySessionIdAsync(int sessionId);

        Task AddAsync(Progress progress);

        Task<Progress> FindById(int id);

        void Update(Progress progress);

        void Remove(Progress progress);
    }
}
