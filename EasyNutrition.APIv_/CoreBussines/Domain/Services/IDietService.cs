using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services
{
    public interface IDietService
    {
        Task<IEnumerable<Diet>> ListAsync();
        Task<IEnumerable<Diet>> ListBySessionIdAsync(int sessionId);

        Task<DietResponse> GetByIdAsync(int id);
        Task<DietResponse> SaveAsync(Diet diet);
        Task<DietResponse> UpdateAsync(int id, Diet diet);

        Task<DietResponse> DeleteAsync(int id);
    }
}
