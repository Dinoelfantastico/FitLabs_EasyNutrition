using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.Shared.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication
{
    public class ComplaintResponse : BaseResponse<Complaint>
    {
        public ComplaintResponse(Complaint resource) : base(resource)
        {

        }

        public ComplaintResponse(string message) : base(message)
        {
        }

    }

}
