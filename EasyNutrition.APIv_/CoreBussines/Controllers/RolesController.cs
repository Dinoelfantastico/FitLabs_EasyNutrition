using AutoMapper;
using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.CoreBussines.Domain.Services;
using EasyNutrition.APIv_.CoreBussines.Resources;
using EasyNutrition.APIv_.Shared.Extentions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EasyNutrition.APIv_.CoreBussines.Controllers
{
    [ApiController]
    //[EnableCors("AnotherPolicy")]
    [Produces("application/json")]
    [Route("/api/v1/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RoleResource>> GetAllAsync()
        {
            var roles = await _roleService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleResource>>(roles);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var role = _mapper.Map<SaveRoleResource, Role>(resource);
            var result = await _roleService.SaveAsync(role);

            if (!result.Success)
                return BadRequest(result.Message);

            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRoleResource resource)
        {
            var role = _mapper.Map<SaveRoleResource, Role>(resource);
            var result = await _roleService.UpdateAsync(id, role);

            if (!result.Success)
                return BadRequest(result.Message);
            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _roleService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);
            return Ok(roleResource);

        }
    }

}
