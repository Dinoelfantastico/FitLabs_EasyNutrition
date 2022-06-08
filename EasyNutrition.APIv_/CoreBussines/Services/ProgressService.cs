using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Services
{
    public class ProgressService : IProgressService
    {
        private readonly IProgressRepository _progressRepository;
        private readonly IUnitOfwork _unitOfWork;

        public ProgressService(IProgressRepository progressRepository, IUnitOfwork unitOfWork)
        {
            _progressRepository = progressRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Progress>> ListAsync()
        {
            return await _progressRepository.ListAsync();
        }

        public async Task<IEnumerable<Progress>> ListBySessionIdAsync(int sessionId)
        {
            return await _progressRepository.ListBySessionIdAsync(sessionId);
        }


        public async Task<ProgressResponse> GetByIdAsync(int id)
        {
            var existingProgress = await _progressRepository.FindById(id);

            if (existingProgress == null)
                return new ProgressResponse("Progress not found");
            return new ProgressResponse(existingProgress);
        }


        public async Task<ProgressResponse> SaveAsync(Progress progress)
        {
            try
            {
                await _progressRepository.AddAsync(progress);
                await _unitOfWork.CompleteAsync();

                return new ProgressResponse(progress);
            }
            catch (Exception ex)
            {
                return new ProgressResponse($"An error ocurred while saving progress: {ex.Message}");
            }
        }

        public async Task<ProgressResponse> UpdateAsync(int id, Progress progress)
        {
            var existingProgress = await _progressRepository.FindById(id);
            if (existingProgress == null)
                return new ProgressResponse("Progress not found");

            existingProgress.Description = progress.Description;

            try
            {
                _progressRepository.Update(existingProgress);
                await _unitOfWork.CompleteAsync();

                return new ProgressResponse(existingProgress);
            }
            catch (Exception ex)
            {
                return new ProgressResponse($"An error ocurred while updating Progress: {ex.Message}");
            }
        }


        public async Task<ProgressResponse> DeleteAsync(int id)
        {
            var existingProgress = await _progressRepository.FindById(id);

            if (existingProgress == null)
                return new ProgressResponse("Progress not found");

            try
            {
                _progressRepository.Remove(existingProgress);
                await _unitOfWork.CompleteAsync();

                return new ProgressResponse(existingProgress);
            }
            catch (Exception ex)
            {
                return new ProgressResponse($"An error ocurred while deleting progress: {ex.Message}");
            }
        }
    }
}
