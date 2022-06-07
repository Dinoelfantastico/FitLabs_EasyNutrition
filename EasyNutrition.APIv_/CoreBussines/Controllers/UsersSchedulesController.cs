using AutoMapper;
using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyNutrition.APIv_.CoreBussines.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [Route("/api/users/{userId}/schedule")]
    public class UserSchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        private readonly IMapper _mapper;

        public UserSchedulesController(IScheduleService scheduleService, IMapper mapper)
        {
            _scheduleService = scheduleService;
            _mapper = mapper;
        }

        [SwaggerOperation(
          Summary = "List Schedule by User",
          Description = "List of Schedule by User",
          OperationId = "ListScheduleByUser",
          Tags = new[] { "Schedules" })]
        [SwaggerResponse(200, "List of Users", typeof(IEnumerable<ScheduleResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ScheduleResource>), 200)]
        public async Task<IEnumerable<ScheduleResource>> GetAllByScheduleAsync(int userId)
        {
            var schedules = await _scheduleService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleResource>>(schedules);
            return resources;
        }

    }
}
