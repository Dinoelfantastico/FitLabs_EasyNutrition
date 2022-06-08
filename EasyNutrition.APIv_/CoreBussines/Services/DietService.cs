using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Services
{
    public class DietService : IDietService
    {
        private readonly IDietRepository _dietRepository;
        private readonly IUnitOfwork _unitOfWork;

        public DietService(IDietRepository dietRepository, IUnitOfwork unitOfWork)
        {
            _dietRepository = dietRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Diet>> ListAsync()
        {
            return await _dietRepository.ListAsync();
        }

        public async Task<IEnumerable<Diet>> ListBySessionIdAsync(int sessionId)
        {
            return await _dietRepository.ListBySessionIdAsync(sessionId);
        }


        public async Task<DietResponse> GetByIdAsync(int id)
        {
            var existingDiet = await _dietRepository.FindById(id);

            if (existingDiet == null)
                return new DietResponse("Diet not found");
            return new DietResponse(existingDiet);
        }


        public async Task<DietResponse> SaveAsync(Diet diet)
        {
            try
            {
                await _dietRepository.AddAsync(diet);
                await _unitOfWork.CompleteAsync();

                return new DietResponse(diet);
            }
            catch (Exception ex)
            {
                return new DietResponse($"An error ocurred while saving diet: {ex.Message}");
            }
        }

        public async Task<DietResponse> UpdateAsync(int id, Diet diet)
        {
            var existingDiet = await _dietRepository.FindById(id);
            if (existingDiet == null)
                return new DietResponse("Diet not found");

            existingDiet.Description = diet.Description;

            try
            {
                _dietRepository.Update(existingDiet);
                await _unitOfWork.CompleteAsync();

                return new DietResponse(existingDiet);
            }
            catch (Exception ex)
            {
                return new DietResponse($"An error ocurred while updating Diet: {ex.Message}");
            }
        }


        public async Task<DietResponse> DeleteAsync(int id)
        {
            var existingDiet = await _dietRepository.FindById(id);

            if (existingDiet == null)
                return new DietResponse("Diet not found");

            try
            {
                _dietRepository.Remove(existingDiet);
                await _unitOfWork.CompleteAsync();

                return new DietResponse(existingDiet);
            }
            catch (Exception ex)
            {
                return new DietResponse($"An error ocurred while deleting diet: {ex.Message}");
            }
        }
    }
}
