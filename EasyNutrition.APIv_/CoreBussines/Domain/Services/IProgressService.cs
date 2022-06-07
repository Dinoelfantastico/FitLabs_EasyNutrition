using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services
{
    public interface IProgressService
    {
        Task<IEnumerable<Progress>> ListAsync();
        Task<IEnumerable<Progress>> ListBySessionIdAsync(int sessionId);

        Task<ProgressResponse> GetByIdAsync(int id);
        Task<ProgressResponse> SaveAsync(Progress progress);
        Task<ProgressResponse> UpdateAsync(int id, Progress progress);

        Task<ProgressResponse> DeleteAsync(int id);
    }
}
