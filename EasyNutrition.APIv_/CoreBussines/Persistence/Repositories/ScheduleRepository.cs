using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EasyNutrition.APIv_.CoreBussines.Persistence.Repositories
{
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {

        public ScheduleRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Schedule>> ListAsync()
        {
            return await _context.Schedules.Include(p => p.User).ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> ListByUserIdAsync(int userId)
        {
            return await _context.Schedules
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task AddAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
        }

        public async Task<Schedule> FindById(int userId)
        {
            return await _context.Schedules.FindAsync(userId);
        }

        public void Remove(Schedule schedule)
        {
            _context.Schedules.Remove(schedule);
        }

        public void Update(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
        }
    }
}
