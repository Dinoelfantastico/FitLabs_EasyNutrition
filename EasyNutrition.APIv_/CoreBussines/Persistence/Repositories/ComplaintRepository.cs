using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EasyNutrition.APIv_.CoreBussines.Persistence.Repositories
{
    public class ComplaintRepository : BaseRepository, IComplaintRepository
    {
        public ComplaintRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Complaint>> ListAsync()
        {
            return await _context.Complaints.Include(p => p.User).ToListAsync();

        }

        public async Task AddAsync(Complaint complaint)
        {
            await _context.Complaints.AddAsync(complaint);
        }

        public async Task<Complaint> FindById(int id)
        {
            return await _context.Complaints.FindAsync(id);
        }

        public void Update(Complaint complaint)
        {
            _context.Complaints.Update(complaint);
        }

        public void Remove(Complaint complaint)
        {
            _context.Complaints.Remove(complaint);
        }
    }
}
