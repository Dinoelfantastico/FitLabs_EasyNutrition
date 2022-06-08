using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Services
{
    public class ComplaintService : IComplaintService
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IUnitOfwork _unitOfWork;

        public ComplaintService(IComplaintRepository complaintRepository, IUnitOfwork unitOfWork)
        {
            _complaintRepository = complaintRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<IEnumerable<Complaint>> ListAsync()
        {
            return await _complaintRepository.ListAsync();
        }

        public async Task<ComplaintResponse> SaveAsync(Complaint complaint)
        {
            try
            {
                await _complaintRepository.AddAsync(complaint);
                await _unitOfWork.CompleteAsync();

                return new ComplaintResponse(complaint);
            }
            catch (Exception ex)
            {
                return new ComplaintResponse($"An error ocurred while saving complaint: {ex.Message}");
            }
        }

        public async Task<ComplaintResponse> UpdateAsync(int id, Complaint complaint)
        {
            var existingComplaint = await _complaintRepository.FindById(id);

            if (existingComplaint == null)
                return new ComplaintResponse("Complaint not found");

            existingComplaint.Description = complaint.Description;

            try
            {
                _complaintRepository.Update(existingComplaint);
                await _unitOfWork.CompleteAsync();

                return new ComplaintResponse(existingComplaint);
            }
            catch (Exception ex)
            {
                return new ComplaintResponse($"An error ocurred while updating complaint: {ex.Message}");
            }

        }

        public async Task<ComplaintResponse> DeleteAsync(int id)
        {
            var existingComplaint = await _complaintRepository.FindById(id);

            if (existingComplaint == null)
                return new ComplaintResponse("Complaint not found");

            try
            {
                _complaintRepository.Remove(existingComplaint);
                await _unitOfWork.CompleteAsync();

                return new ComplaintResponse(existingComplaint);
            }
            catch (Exception ex)
            {
                return new ComplaintResponse($"An error ocurred while deleting complaint:{ex.Message}");
            }

        }

    }
}
