using EasyNutrition.APIv_.CoreBussines.Domain.Models;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task<IEnumerable<Subscription>> ListByUserIdAsync(int userId);

        Task AddAsync(Subscription subscription);
        Task<Subscription> FindById(int userId);
        void Update(Subscription subscription);
        void Remove(Subscription subscription);
    }
}
