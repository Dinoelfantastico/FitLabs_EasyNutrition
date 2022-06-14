using Microsoft.AspNetCore.Mvc;
using EasyNutrition.APIv_.CoreBussines.Resources;
using EasyNutrition.APIv_.Shared.Extentions;
using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;
using EasyNutrition.APIv_.CoreBussines.Domain.Models;

namespace EasyNutrition.APIv_.CoreBussines.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        protected readonly AppDbContext _context;

        public AuthenticationController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context; 
        }
        [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthenticationResource resource)
        {
            User user = new User();
            try
            {
                var account = GetByUserandPassword(resource.UserName, resource.Password);
                user = _context.Users.Find(account.Id);
                if (user == null)
                {
                    throw new Exception("No se encontro esta cuenta");
                }

            }
            catch (Exception)
            {
                return BadRequest(new { message = "Invalid Username or Password" });
            }
            var usserResource = _mapper.Map<User, UserResource>(user);
            return Ok(usserResource);
        }

        [NonAction]
        public User GetByUserandPassword(string username, string password)=>
            _context.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
    }
}
