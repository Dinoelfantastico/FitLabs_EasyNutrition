using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EasyNutrition.APIv_.CoreBussines.Persistence.Repositories
{
    public class DietRepository : BaseRepository, IDietRepository
    {
        public DietRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Diet>> ListAsync()
        {
            return await _context.Diets.Include(p => p.Session).ToListAsync();
        }

        public async Task<IEnumerable<Diet>> ListBySessionIdAsync(int sessionId)
        {
            return await _context.Diets
                .Where(p => p.SessionId == sessionId)
                .Include(p => p.Session)
                .ToListAsync();

        }

        public async Task AddAsync(Diet diet)
        {
            await _context.Diets.AddAsync(diet);
        }

        public async Task<Diet> FindById(int id)
        {
            return await _context.Diets.FindAsync(id);
        }


        public void Remove(Diet diet)
        {
            _context.Diets.Remove(diet);
        }

        public void Update(Diet diet)
        {
            _context.Diets.Update(diet);
        }
    }
}
