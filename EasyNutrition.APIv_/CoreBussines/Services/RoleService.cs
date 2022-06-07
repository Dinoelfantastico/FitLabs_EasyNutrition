using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfwork _unitOfwork;

        public RoleService(IRoleRepository roleRepository, IUnitOfwork unitOfwork)
        {
            _roleRepository = roleRepository;
            _unitOfwork = unitOfwork;
        }

        public async Task<IEnumerable<Role>> ListAsync()
        {
            return await _roleRepository.ListAsync();
        }

        public async Task<RoleResponse> SaveAsync(Role role)
        {
            try
            {
                await _roleRepository.AddAsync(role);
                await _unitOfwork.CompleteAsync();

                return new RoleResponse(role);
            }
            catch (Exception e)
            {
                return new RoleResponse($"An error ocurred while saving role: {e.Message}");
            }
        }

        public async Task<RoleResponse> UpdateAsync(int id, Role role)
        {
            var existingRole = await _roleRepository.FindByIdAsync(id);

            if (existingRole == null)
                return new RoleResponse("Role not found.");
            existingRole.Name = role.Name;

            try
            {
                _roleRepository.Update(existingRole);
                await _unitOfwork.CompleteAsync();

                return new RoleResponse(existingRole);
            }

            catch (Exception e)
            {
                return new RoleResponse($"An error ocurred while updating the role {e.Message}");
            }

        }

        public async Task<RoleResponse> DeleteAsync(int id)
        {
            var existingRole = await _roleRepository.FindByIdAsync(id);

            if (existingRole == null)
                return new RoleResponse("Role not found");

            try
            {
                _roleRepository.Remove(existingRole);
                await _unitOfwork.CompleteAsync();

                return new RoleResponse(existingRole);
            }
            catch (Exception ex)
            {
                return new RoleResponse($"An error ocurred while deleting role: {ex.Message}");
            }
        }
    }

}
