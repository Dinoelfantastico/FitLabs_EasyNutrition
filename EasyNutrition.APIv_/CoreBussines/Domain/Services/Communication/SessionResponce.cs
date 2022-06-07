using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.Shared.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication
{
    public class SessionResponce : BaseResponse<Session>
    {
        public SessionResponce(Session resource) : base(resource)
        {
        }

        public SessionResponce(string message) : base(message)
        {
        }
    }
}
