using EasyNutrition.APIv_.CoreBussines.Domain.Models;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Repositories
{
    public interface IExperienceRepository
    {
        Task<IEnumerable<Experience>> ListAsync();
        Task AddAsync(Experience experience);

        Task<Experience> FindById(int id);

        void Update(Experience experience);
        void Remove(Experience experience);
    }
}
