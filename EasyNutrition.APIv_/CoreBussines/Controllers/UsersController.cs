using AutoMapper;
using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Resources;
using EasyNutrition.APIv_.Shared.Extentions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyNutrition.APIv_.CoreBussines.Controllers
{
    [ApiController]
    //[EnableCors("AnotherPolicy")]
    [Produces("application/json")]
    [Route("/api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [SwaggerOperation(
          Summary = "List all users",
          Description = "List of Users",
          OperationId = "ListAllUsers",
          Tags = new[] { "Users" })]
        [SwaggerResponse(200, "List of Users", typeof(IEnumerable<UserResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resources;
        }

        [SwaggerOperation(
              Summary = "Add user",
              Description = "Add new user",
              OperationId = "AddUser",
              Tags = new[] { "Users" })]
        [SwaggerResponse(200, "Add Users", typeof(IEnumerable<UserResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        [SwaggerOperation(
           Summary = "Update user",
           Description = "Update a user",
           OperationId = "UpdateUser",
           Tags = new[] { "Users" })]
        [SwaggerResponse(200, "Update Users", typeof(IEnumerable<UserResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.UpdateAsync(id, user);

            if (!result.Success)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        [SwaggerOperation(
        Summary = "Delete user",
        Description = "Delete a user",
        OperationId = "DeleteUser",
        Tags = new[] { "Users" })]
        [SwaggerResponse(200, "Delete Users", typeof(IEnumerable<UserResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
    }

}
