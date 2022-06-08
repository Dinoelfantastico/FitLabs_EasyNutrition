using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services
{
    public interface IComplaintService
    {
        Task<IEnumerable<Complaint>> ListAsync();
        Task<ComplaintResponse> SaveAsync(Complaint complaint);

        Task<ComplaintResponse> UpdateAsync(int id, Complaint complaint);

        Task<ComplaintResponse> DeleteAsync(int id);
    }
}
