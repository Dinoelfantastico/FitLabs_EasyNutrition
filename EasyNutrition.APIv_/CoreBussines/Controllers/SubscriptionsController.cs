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
    public class SubscriptionsController : ControllerBase
    {

        private readonly ISubscriptionService _subscriptionService;
        private readonly IMapper _mapper;

        public SubscriptionsController(ISubscriptionService subscriptionService, IMapper mapper)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
        }

        [SwaggerOperation(
          Summary = "List all subscriptions",
          Description = "List of Subscriptions",
          OperationId = "ListAllSubscriptions",
          Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "List of Subscriptions", typeof(IEnumerable<SubscriptionResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IEnumerable<SubscriptionResource>> GetAllAsync()
        {
            var subscriptions = await _subscriptionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Subscription>, IEnumerable<SubscriptionResource>>(subscriptions);
            return resources;
        }


        [SwaggerOperation(
               Summary = "Add subscription",
               Description = "Add new subscription",
               OperationId = "AddSubscription",
               Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "Add Subscriptions", typeof(IEnumerable<SubscriptionResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var subscription = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.SaveAsync(subscription);

            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }



        [SwaggerOperation(
             Summary = "Update subscription by User",
             Description = "Update a subscription by User",
             OperationId = "UpdateSubscriptionbyUser",
             Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "Update Subscriptions by User", typeof(IEnumerable<SubscriptionResource>))]
        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveSubscriptionResource resource)
        {
            var subscription = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);
            var result = await _subscriptionService.UpdateAsync(userId, subscription);

            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }

        [SwaggerOperation(
      Summary = "Delete Subscriptions",
      Description = "Delete a Subscriptions",
      OperationId = "Deletesubscriptions",
      Tags = new[] { "Subscriptions" })]
        [SwaggerResponse(200, "Delete Subscriptions", typeof(IEnumerable<SubscriptionResource>))]
        [HttpDelete("{userId}")]
        [ProducesResponseType(typeof(IEnumerable<SubscriptionResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _subscriptionService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }
    }
}
