using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.Shared.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication
{
    public class ExperienceResponse : BaseResponse<Experience>
    {
        public ExperienceResponse(Experience resource) : base(resource)
        {

        }

        public ExperienceResponse(string message) : base(message)
        {
        }
    }
}
