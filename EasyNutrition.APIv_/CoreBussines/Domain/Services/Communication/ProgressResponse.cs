using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.Shared.Domain.Services.Communication;

namespace EasyNutrition.APIv_.CoreBussines.Domain.Services.Communication
{
    public class ProgressResponse : BaseResponse<Progress>
    {
        public ProgressResponse(Progress resource) : base(resource)
        {
        }

        public ProgressResponse(string message) : base(message)
        {
        }
    }
}
