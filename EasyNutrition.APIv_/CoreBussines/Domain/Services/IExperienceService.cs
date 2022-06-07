using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services
{
    public interface IExperienceService
    {
        Task<IEnumerable<Experience>> ListAsync();
        Task<ExperienceResponse> SaveAsync(Experience experience);

        Task<ExperienceResponse> UpdateAsync(int id, Experience experience);

        Task<ExperienceResponse> DeleteAsync(int id);
    }
}
