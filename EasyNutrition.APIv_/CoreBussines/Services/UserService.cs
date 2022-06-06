using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Repositories;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfwork _unitOfword;
        private readonly IRoleRepository roleRepository;

        public UserService(IUserRepository userRepository, IUnitOfwork unitOfword)
        {
            _userRepository = userRepository;
            _unitOfword = unitOfword;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<IEnumerable<User>> ListByRoleIdAsync(int roleId)
        {
            return await _userRepository.ListByRoleIdAsync(roleId);
        }


        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);
        }


        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfword.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error ocurred while saving role: {e.Message}");
            }

        }


        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
            if (existingUser == null)
                return new UserResponse("User not found");

            existingUser.Name = user.Name;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfword.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating user: {ex.Message}");
            }
        }



        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
                return new UserResponse("User not found");

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfword.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting user: {ex.Message}");
            }
        }

    }

}
