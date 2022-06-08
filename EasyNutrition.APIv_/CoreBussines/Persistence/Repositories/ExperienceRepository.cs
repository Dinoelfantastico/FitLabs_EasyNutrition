using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EasyNutrition.APIv_.CoreBussines.Persistence.Repositories
{
    public class ExperienceRepository : BaseRepository, IExperienceRepository
    {
        public ExperienceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Experience>> ListAsync()
        {
            return await _context.Experiences.Include(p => p.User).ToListAsync();
        }

        public async Task AddAsync(Experience experience)
        {
            await _context.Experiences.AddAsync(experience);
        }

        public async Task<Experience> FindById(int id)
        {
            return await _context.Experiences.FindAsync();
        }

        public void Update(Experience experience)
        {
            _context.Experiences.Update(experience);
        }

        public void Remove(Experience experience)
        {
            _context.Experiences.Remove(experience);
        }

    }
}
