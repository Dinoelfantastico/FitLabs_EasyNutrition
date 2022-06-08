using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EasyNutrition.APIv_.CoreBussines.Persistence.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Role>> ListAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task AddAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
        }

        public async Task<Role> FindByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }


        public void Update(Role role)
        {
            _context.Roles.Update(role);
        }

        public void Remove(Role role)
        {
            _context.Roles.Remove(role);
        }
    }

}
