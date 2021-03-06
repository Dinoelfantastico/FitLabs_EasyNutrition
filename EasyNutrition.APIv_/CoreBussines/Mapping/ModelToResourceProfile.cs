using AutoMapper;
using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Resources;

namespace EasyNutrition.APIv_.CoreBussines.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Role, RoleResource>();
            CreateMap<User, UserResource>();

            CreateMap<Session, SessionResource>();

            CreateMap<Progress, ProgressResource>();
            CreateMap<Diet, DietResource>();

            CreateMap<Experience, ExperienceResource>();
            CreateMap<Schedule, ScheduleResource>();
            CreateMap<Complaint, ComplaintResource>();

            CreateMap<Subscription, SubscriptionResource>();

        }

    }
}
