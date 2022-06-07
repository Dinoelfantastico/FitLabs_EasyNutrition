using AutoMapper;
using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Resources;

namespace EasyNutrition.APIv_.CoreBussines.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveRoleResource, Role>();
            CreateMap<SaveUserResource, User>();

            CreateMap<SaveSessionResource, Session>();
            CreateMap<SaveProgressResource, ProgressResource>();
            CreateMap<SaveDietResource, Diet>();
           
        }

    }
}
