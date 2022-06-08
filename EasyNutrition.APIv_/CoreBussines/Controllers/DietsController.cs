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
    public class DietsController : ControllerBase
    {
        private readonly IDietService _dietService;
        private readonly IMapper _mapper;

        public DietsController(IDietService dietService, IMapper mapper)
        {
            _dietService = dietService;
            _mapper = mapper;
        }


        [SwaggerOperation(
         Summary = "List all diets",
         Description = "List of diets",
         OperationId = "ListAllDiets",
         Tags = new[] { "Diets" })]
        [SwaggerResponse(200, "List of Diets", typeof(IEnumerable<DietResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DietResource>), 200)]
        public async Task<IEnumerable<DietResource>> GetAllAsync()
        {
            var diets = await _dietService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Diet>, IEnumerable<DietResource>>(diets);
            return resources;
        }


        [SwaggerOperation(
              Summary = "Add Diets",
              Description = "Add new Diet",
              OperationId = "AddDiet",
              Tags = new[] { "Diets" })]
        [SwaggerResponse(200, "Add Diet", typeof(IEnumerable<DietResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<DietResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveDietResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var diets = _mapper.Map<SaveDietResource, Diet>(resource);
            var result = await _dietService.SaveAsync(diets);

            if (!result.Success)
                return BadRequest(result.Message);

            var dietResource = _mapper.Map<Diet, DietResource>(result.Resource);
            return Ok(dietResource);
        }



        [SwaggerOperation(
            Summary = "Update diet",
            Description = "Update a diet",
            OperationId = "UpdateDiet",
            Tags = new[] { "Diets" })]
        [SwaggerResponse(200, "Update Sessions", typeof(IEnumerable<DietResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<DietResource>), 200)]
        public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveDietResource resource)
        {
            var diet = _mapper.Map<SaveDietResource, Diet>(resource);
            var result = await _dietService.UpdateAsync(userId, diet);

            if (!result.Success)
                return BadRequest(result.Message);
            var dietResource = _mapper.Map<Diet, DietResource>(result.Resource);
            return Ok(dietResource);
        }

        [SwaggerOperation(
         Summary = "Delete Diet",
         Description = "Delete a Diet",
         OperationId = "DeleteDiet",
         Tags = new[] { "Diets" })]
        [SwaggerResponse(200, "Delete Diets", typeof(IEnumerable<DietResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<DietResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _dietService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var dietResource = _mapper.Map<Diet, DietResource>(result.Resource);
            return Ok(dietResource);
        }

        [SwaggerOperation(
            Summary = "List diets by session",
            Description = "List of diets for an specific Session",
            OperationId = "ListDietBySession",
            Tags = new[] { "Diets" })]
        [HttpGet("{sessionId}")]
        [ProducesResponseType(typeof(IEnumerable<DietResource>), 200)]
        public async Task<IEnumerable<DietResource>> GetDietsBySessionId(int sessionId)
        {
            var diets = await _dietService.ListBySessionIdAsync(sessionId);
            var resources = _mapper
                .Map<IEnumerable<Diet>, IEnumerable<DietResource>>(diets);
            return resources;
        }
    }
}
