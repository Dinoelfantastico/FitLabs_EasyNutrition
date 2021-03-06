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
    public class ProgressesController : ControllerBase
    {
        private readonly IProgressService _progressService;
        private readonly IMapper _mapper;

        public ProgressesController(IProgressService progressService, IMapper mapper)
        {
            _progressService = progressService;
            _mapper = mapper;
        }

        [SwaggerOperation(
         Summary = "List all progresses",
         Description = "List of progresses",
         OperationId = "ListAllProgresses",
         Tags = new[] { "Progresses" })]
        [SwaggerResponse(200, "List of Progresses", typeof(IEnumerable<ProgressResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProgressResource>), 200)]
        public async Task<IEnumerable<ProgressResource>> GetAllAsync()
        {
            var progress = await _progressService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Progress>, IEnumerable<ProgressResource>>(progress);
            return resources;
        }


        [SwaggerOperation(
              Summary = "Add Progresses",
              Description = "Add new Progress",
              OperationId = "AddProgress",
              Tags = new[] { "Progresses" })]
        [SwaggerResponse(200, "Add Progress", typeof(IEnumerable<ProgressResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ProgressResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveProgressResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var progress = _mapper.Map<SaveProgressResource, Progress>(resource);
            var result = await _progressService.SaveAsync(progress);

            if (!result.Success)
                return BadRequest(result.Message);

            var progressResource = _mapper.Map<Progress, ProgressResource>(result.Resource);
            return Ok(progressResource);
        }



        [SwaggerOperation(
            Summary = "Update progress",
            Description = "Update a progress",
            OperationId = "UpdateProgress",
            Tags = new[] { "Progresses" })]
        [SwaggerResponse(200, "Update Progress", typeof(IEnumerable<ProgressResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ProgressResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProgressResource resource)
        {
            var progress = _mapper.Map<SaveProgressResource, Progress>(resource);
            var result = await _progressService.UpdateAsync(id, progress);

            if (!result.Success)
                return BadRequest(result.Message);
            var progressResource = _mapper.Map<Progress, ProgressResource>(result.Resource);
            return Ok(progressResource);
        }

        [SwaggerOperation(
         Summary = "Delete Progress",
         Description = "Delete a Progress",
         OperationId = "DeleteProgress",
         Tags = new[] { "Progresses" })]
        [SwaggerResponse(200, "Delete Progress", typeof(IEnumerable<ProgressResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ProgressResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _progressService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var progressResource = _mapper.Map<Progress, ProgressResource>(result.Resource);
            return Ok(progressResource);
        }
    }
}