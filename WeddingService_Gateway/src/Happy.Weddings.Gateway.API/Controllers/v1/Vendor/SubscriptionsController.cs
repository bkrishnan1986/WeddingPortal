using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionPlan;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("subscriptions")]
    [ApiController]
    public class SubscriptionsController : Controller
    {
        /// <summary>
        /// The subscription service
        /// </summary>
        private readonly ISubscriptionService subscriptionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsController"/> class.
        /// </summary>
        /// <param name="subscriptionService">The subscription service.</param>
        public SubscriptionsController(
            ISubscriptionService subscriptionService)
        {
            this.subscriptionService = subscriptionService;
        }

        /// <summary>
        /// Gets the Subcription Plans
        /// </summary>
        /// <param name="subscriptionPlansParameters">The subcription Plans Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionPlans([FromQuery] SubscriptionPlansParameter subscriptionPlansParameters)
        {
            var result = await subscriptionService.GetSubcriptionPlans(subscriptionPlansParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Subcription Plan.
        /// </summary>
        /// <param name="subscriptionPlanId">The SubcriptionPlan identifier.</param>
        /// <returns></returns>
        [Route("{subscriptionPlanId}")]
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionPlan(int subscriptionPlanId)
        {
            var result = await subscriptionService.GetSubcriptionPlan(subscriptionPlanId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Subcription Plan.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSubcriptionPlan([FromBody] CreateSubscriptionPlanRequest request)
        {
            var result = await subscriptionService.CreateSubcriptionPlan(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Subcription Plan.
        /// </summary>
        /// <param name="subscriptionplanId">The subcriptionplan identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{subscriptionplanId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSubcriptionPlan(int subscriptionplanId, [FromBody] UpdateSubscriptionPlanRequest request)
        {
            var result = await subscriptionService.UpdateSubcriptionPlan(subscriptionplanId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the Subcription Plan.
        /// </summary>
        /// <param name="subscriptionplanId">The subcriptionplan identifier.</param>
        /// <returns></returns>
        [Route("{subscriptionplanId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubcriptionPlan(int subscriptionplanId)
        {
            var result = await subscriptionService.DeleteSubcriptionPlan(subscriptionplanId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
