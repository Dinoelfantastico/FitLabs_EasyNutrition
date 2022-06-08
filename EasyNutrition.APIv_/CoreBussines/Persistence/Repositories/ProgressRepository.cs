using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EasyNutrition.APIv_.CoreBussines.Persistence.Repositories
{
    public class ProgressRepository : BaseRepository, IProgressRepository
    {
        public ProgressRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Progress>> ListAsync()
        {
            return await _context.Progresses.Include(p => p.Session).ToListAsync();
        }

        public async Task<IEnumerable<Progress>> ListBySessionIdAsync(int sessionId)
        {
            return await _context.Progresses
                .Where(p => p.SessionId == sessionId)
                .Include(p => p.Session)
                .ToListAsync();

        }

        public async Task AddAsync(Progress progress)
        {
            await _context.Progresses.AddAsync(progress);
        }

        public async Task<Progress> FindById(int id)
        {
            return await _context.Progresses.FindAsync(id);
        }


        public void Remove(Progress progress)
        {
            _context.Progresses.Remove(progress);
        }

        public void Update(Progress progress)
        {
            _context.Progresses.Update(progress);
        }
    }
}
