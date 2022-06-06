using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.Shared.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication
{
    public class RoleResponse : BaseResponse<Role>
    {
        public RoleResponse(Role resource) : base(resource)
        {
        }

        public RoleResponse(string message) : base(message)
        {
        }

    }
}


