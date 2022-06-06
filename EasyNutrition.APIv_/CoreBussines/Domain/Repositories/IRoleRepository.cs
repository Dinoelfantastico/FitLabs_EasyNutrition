using EasyNutrition.APIv_.CoreBussines.Domain.Models;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> ListAsync();
        Task AddAsync(Role role);
        Task<Role> FindByIdAsync(int id);
        void Update(Role role);
        void Remove(Role role);

    }
}
