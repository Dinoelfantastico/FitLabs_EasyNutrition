using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IUnitOfwork _unitOfwork;

        public async Task<IEnumerable<Schedule>> ListAsync()
        {
            return await _scheduleRepository.ListAsync();
        }
        public ScheduleService(IScheduleRepository scheduleRepository, IUnitOfwork unitOfWork)
        {
            _scheduleRepository = scheduleRepository;
            _unitOfwork = unitOfWork;
        }

        public async Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId)
        {
            return await _scheduleRepository.ListByUserIdAsync(userId);
        }

        public async Task<ScheduleResponse> GetByIdAsync(int id)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);

            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");
            return new ScheduleResponse(existingSchedule);
        }

        public async Task<ScheduleResponse> SaveAsync(Schedule schedule)
        {
            try
            {
                await _scheduleRepository.AddAsync(schedule);
                await _unitOfwork.CompleteAsync();

                return new ScheduleResponse(schedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while saving schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> UpdateAsync(int userId, Schedule schedule)
        {
            var existingSchedule = await _scheduleRepository.FindById(userId);
            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");

            existingSchedule.State = schedule.State;

            try
            {
                _scheduleRepository.Update(existingSchedule);
                await _unitOfwork.CompleteAsync();

                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while updating schedule: {ex.Message}");
            }
        }

        public async Task<ScheduleResponse> DeleteAsync(int id)
        {
            var existingSchedule = await _scheduleRepository.FindById(id);

            if (existingSchedule == null)
                return new ScheduleResponse("Schedule not found");

            try
            {
                _scheduleRepository.Remove(existingSchedule);
                await _unitOfwork.CompleteAsync();

                return new ScheduleResponse(existingSchedule);
            }
            catch (Exception ex)
            {
                return new ScheduleResponse($"An error ocurred while deleting schedule: {ex.Message}");
            }
        }


    }
}
