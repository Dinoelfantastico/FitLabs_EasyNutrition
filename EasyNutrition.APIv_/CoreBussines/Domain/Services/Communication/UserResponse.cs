using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.Shared.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication
{
    public class UserResponse: BaseResponse<User>
    {
        public UserResponse(User resource) : base(resource)
        {
        }

        public UserResponse(string message) : base(message)
        {
        }

    }
}


