using EasyNutrition.APIv_.CoreBussines.Domain.Models;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Repositories
{
    public interface IComplaintRepository
    {
        Task<IEnumerable<Complaint>> ListAsync();

        Task AddAsync(Complaint complaint);
        Task<Complaint> FindById(int id);
        void Update(Complaint complaint);

        void Remove(Complaint complaint);

    }
}
