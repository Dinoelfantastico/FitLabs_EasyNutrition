using EasyNutrition.APIv_.CoreBussines.Domain.Models;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Repositories
{
    public interface IDietRepository
    {
        Task<IEnumerable<Diet>> ListAsync();
        Task<IEnumerable<Diet>> ListBySessionIdAsync(int sessionId);

        Task AddAsync(Diet diet);

        Task<Diet> FindById(int id);

        void Update(Diet diet);

        void Remove(Diet diet);
    }
}
