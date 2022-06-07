using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.Shared.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication
{
    public class ScheduleResponse : BaseResponse<Schedule>
    {
        public ScheduleResponse(Schedule resource) : base(resource)
        {
        }

        public ScheduleResponse(string message) : base(message)
        {
        }
    }
}
