using AutoMapper;
using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Resources;
using EasyNutrition.APIv_.Shared.Extentions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyNutrition.APIv_.CoreBussines.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SchedulesController : ControllerBase
    {

        private readonly IScheduleService _scheduleService;
        private readonly IMapper _mapper;

        public SchedulesController(IScheduleService scheduleService, IMapper mapper)
        {
            _scheduleService = scheduleService;
            _mapper = mapper;
        }

        [SwaggerOperation(
         Summary = "List all schedules",
         Description = "List of Schedules",
         OperationId = "ListAllSchedules",
         Tags = new[] { "Schedules" })]
        [SwaggerResponse(200, "List of Schedules", typeof(IEnumerable<ScheduleResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ScheduleResource>), 200)]
        public async Task<IEnumerable<ScheduleResource>> GetAllAsync()
        {
            var schedules = await _scheduleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleResource>>(schedules);
            return resources;
        }

        [SwaggerOperation(
               Summary = "Add schedule",
               Description = "Add new schedule",
               OperationId = "AddSchedule",
               Tags = new[] { "Schedules" })]
        [SwaggerResponse(200, "Add Schedules", typeof(IEnumerable<ScheduleResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ScheduleResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveScheduleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var schedule = _mapper.Map<SaveScheduleResource, Schedule>(resource);
            var result = await _scheduleService.SaveAsync(schedule);

            if (!result.Success)
                return BadRequest(result.Message);

            var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);
            return Ok(scheduleResource);
        }



        [SwaggerOperation(
             Summary = "Update schedule by User",
             Description = "Update a schedule by User",
             OperationId = "UpdateSchedulebyUser",
             Tags = new[] { "Schedules" })]
        [SwaggerResponse(200, "Update Schedules by User", typeof(IEnumerable<ScheduleResource>))]
        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(IEnumerable<ScheduleResource>), 200)]
        public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveScheduleResource resource)
        {
            var schedule = _mapper.Map<SaveScheduleResource, Schedule>(resource);
            var result = await _scheduleService.UpdateAsync(userId, schedule);

            if (!result.Success)
                return BadRequest(result.Message);
            var scheduleResource = _mapper.Map<Schedule, ScheduleResource>(result.Resource);
            return Ok(scheduleResource);
        }


    }
}
