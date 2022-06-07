using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Services
{
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;
        private readonly IUnitOfWork _unitOfWork;
        public Task<DietResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DietResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Diet>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Diet>> ListBySessionIdAsync(int sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<DietResponse> SaveAsync(Diet diet)
        {
            throw new NotImplementedException();
        }

        public Task<DietResponse> UpdateAsync(int id, Diet diet)
        {
            throw new NotImplementedException();
        }
    }
}
