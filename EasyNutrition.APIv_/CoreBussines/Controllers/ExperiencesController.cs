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
    public class ExperiencesController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        private readonly IMapper _mapper;


        public ExperiencesController(IExperienceService experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }

        [SwaggerOperation(
        Summary = "List all experiences",
        Description = "List of expriences",
        OperationId = "ListAllExperiences",
        Tags = new[] { "Experiences" })]
        [SwaggerResponse(200, "List of experiences", typeof(IEnumerable<ExperienceResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExperienceResource>), 200)]
        public async Task<IEnumerable<ExperienceResource>> GetAllAsync()
        {
            var experience = await _experienceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Experience>, IEnumerable<ExperienceResource>>(experience);
            return resources;
        }

        [SwaggerOperation(
               Summary = "Add experience",
               Description = "Add new experience",
               OperationId = "AddExperience",
               Tags = new[] { "Experiences" })]
        [SwaggerResponse(200, "Add Experience", typeof(IEnumerable<ExperienceResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ExperienceResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveExperienceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var experience = _mapper.Map<SaveExperienceResource, Experience>(resource);
            var result = await _experienceService.SaveAsync(experience);

            if (!result.Success)
                return BadRequest(result.Message);

            var experienceResource = _mapper.Map<Experience, ExperienceResource>(result.Resource);
            return Ok(experienceResource);

        }

        [SwaggerOperation(
            Summary = "Update Experience",
            Description = "Update a experience",
            OperationId = "UpdateExperience",
            Tags = new[] { "Experiences" })]
        [SwaggerResponse(200, "Update Experience", typeof(IEnumerable<ExperienceResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ExperienceResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveExperienceResource resource)
        {
            var experience = _mapper.Map<SaveExperienceResource, Experience>(resource);
            var result = await _experienceService.UpdateAsync(id, experience);

            if (!result.Success)
                return BadRequest(result.Message);
            var experienceResource = _mapper.Map<Experience, ExperienceResource>(result.Resource);
            return Ok(experienceResource);
        }


        [SwaggerOperation(
        Summary = "Delete experience",
        Description = "Delete a experience",
        OperationId = "DeleteExperience",
        Tags = new[] { "Experiences" })]
        [SwaggerResponse(200, "Delete Experience", typeof(IEnumerable<ExperienceResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ExperienceResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _experienceService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var experienceResource = _mapper.Map<Experience, ExperienceResource>(result.Resource);
            return Ok(experienceResource);
        }

    }
}
