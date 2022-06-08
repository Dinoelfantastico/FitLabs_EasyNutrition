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
    [Route("api/[controller]")]
    public class UserSessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;


        public UserSessionsController(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }


        [SwaggerOperation(
         Summary = "List session by user",
         Description = "List of session by user",
         OperationId = "ListAllSessionsByUser",
         Tags = new[] { "Sessions" })]
        [SwaggerResponse(200, "List of Session", typeof(IEnumerable<SessionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SessionResource>), 200)]
        public async Task<IEnumerable<SessionResource>> GetAllByUserAsync(int userId)
        {
            var sessions = await _sessionService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionResource>>(sessions);
            return resources;
        }

    }
}
