using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;

namespace EasyNutrition.APIv_.CoreBussines.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

    }
}
