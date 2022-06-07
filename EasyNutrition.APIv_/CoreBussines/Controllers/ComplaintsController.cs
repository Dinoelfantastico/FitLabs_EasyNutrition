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
    //[EnableCors("AnotherPolicy")]
    [Produces("application/json")]
    [Route("/api/v1/[controller]")]
    public class ComplaintsController : ControllerBase
    {
        private readonly IComplaintService _complaintService;
        private readonly IMapper _mapper;

        public ComplaintsController(IComplaintService complaintService, IMapper mapper)
        {
            _complaintService = complaintService;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IEnumerable<ComplaintResources>> GetAllAsync()
        {
            var complaints = await _complaintService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Complaint>, IEnumerable<ComplaintResources>>(complaints);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveComplaintResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var complaint = _mapper.Map<SaveComplaintResource, Complaint>(resource);
            var result = await _complaintService.SaveAsync(complaint);

            if (!result.Success)
                return BadRequest(result.Message);

            var complaintResource = _mapper.Map<Complaint, ComplaintResources>(result.Resource);
            return Ok(complaintResource);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveComplaintResource resource)
        {
            var complaint = _mapper.Map<SaveComplaintResource, Complaint>(resource);
            var result = await _complaintService.UpdateAsync(id, complaint);

            if (!result.Success)
                return BadRequest(result.Message);
            var complaintResource = _mapper.Map<Complaint, ComplaintResources>(result.Resource);
            return Ok(complaintResource);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _complaintService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var complaintResource = _mapper.Map<Complaint, ComplaintResources>(result.Resource);
            return Ok(complaintResource);
        }



    }
}
