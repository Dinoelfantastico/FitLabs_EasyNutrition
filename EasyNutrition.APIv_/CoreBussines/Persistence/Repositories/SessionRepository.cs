using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EasyNutrition.APIv_.CoreBussines.Persistence.Repositories
{
    public class SessionRepository : BaseRepository, ISessionRepository
    {
        public SessionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Session>> LisAsync()
        {
            return await _context.Sessions.Include(p => p.User).ToListAsync();
        }

        public async Task<IEnumerable<Session>> ListByUserIdAsync(int userId)
        {
            return await _context.Sessions
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();

        }

        public async Task AddAsync(Session session)
        {
            await _context.Sessions.AddAsync(session);
        }

        public async Task<Session> FindById(int userId)
        {
            return await _context.Sessions.FindAsync(userId);
        }


        public void Remove(Session session)
        {
            _context.Sessions.Remove(session);
        }

        public void Update(Session session)
        {
            _context.Sessions.Update(session);
        }
    }
}
