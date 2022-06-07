using EasyNutrition.APIv_.CoreBussines.Domain.Models;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Repositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> ListAsync();

        Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId);

        Task AddAsync(Schedule schedule);
        Task<Schedule> FindById(int userId);
        void Update(Schedule schedule);
        void Remove(Schedule schedule);
    }
}
