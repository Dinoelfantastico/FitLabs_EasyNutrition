using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> ListAsync();

        Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId);

        Task<ScheduleResponse> GetByIdAsync(int id);
        Task<ScheduleResponse> SaveAsync(Schedule schedule);
        Task<ScheduleResponse> UpdateAsync(int id, Schedule schedule);
    }
}
