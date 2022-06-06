using EasyNutrition.APIv_.CoreBussines.Domain.Models;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListByRoleIdAsync(int roleId);
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        void Update(User user);
        void Remove(User user);

    }
}
