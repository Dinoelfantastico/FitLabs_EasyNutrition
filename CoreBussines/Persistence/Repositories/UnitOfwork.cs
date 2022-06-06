using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;

namespace EasyNutrition.APIv_.CoreBussines.Persistence.Repositories
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly AppDbContext _context;

        public UnitOfwork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
