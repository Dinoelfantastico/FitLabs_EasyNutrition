using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.Shared.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication
{
    public class DietResponse : BaseResponse<Diet>
    {
        public DietResponse(Diet resource) : base(resource)
        {
        }

        public DietResponse(string message) : base(message)
        {
        }
    }
}
