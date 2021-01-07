using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceBenefit;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// Vendors Subcriptions Benefits operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("subcriptionbenefits")]
    [ApiController]
    public class SubscriptionBenefitsController : Controller
    {
        /// <summary>
        /// The subscription benefit service
        /// </summary>
        private readonly ISubscriptionBenefitService subscriptionBenefitService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionBenefitsController"/> class.
        /// </summary>
        /// <param name="subscriptionBenefitService">The subscription benefit service.</param>
        public SubscriptionBenefitsController(
            ISubscriptionBenefitService subscriptionBenefitService)
        {
            this.subscriptionBenefitService = subscriptionBenefitService;
        }

        /// <summary>
        /// Gets the Subcription Benefits
        /// </summary>
        /// <param name="subscriptionBenefitsParameters">The subcription Plans Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionPlans([FromQuery] SubscriptionBenefitsParameter subscriptionBenefitsParameters)
        {
            var result = await subscriptionBenefitService.GetSubcriptionPlans(subscriptionBenefitsParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Subcription Benefits.
        /// </summary>
        /// <param name="subcriptionBenefitId">The SubcriptionBenefits identifier.</param>
        /// <returns></returns>
        [Route("{subcriptionBenefitId}")]
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionPlan(int subcriptionBenefitId)
        {
            var result = await subscriptionBenefitService.GetSubcriptionPlan(subcriptionBenefitId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Subcription Benefits.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSubcriptionBenefit([FromBody] CreateSubscriptionBenefitRequest request)
        {
            var result = await subscriptionBenefitService.CreateSubcriptionBenefit(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Subcription Benefit.
        /// </summary>
        /// <param name="subcriptionbenefitId">The subcriptionbenefit identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{subcriptionbenefitId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSubcriptionBenefit(int subcriptionbenefitId, [FromBody] UpdateSubscriptionBenefitRequest request)
        {
            var result = await subscriptionBenefitService.UpdateSubcriptionBenefit(subcriptionbenefitId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the Subcription Benefit.
        /// </summary>
        /// <param name="subcriptionbenefitId">The subcriptionbenefit identifier.</param>
        /// <returns></returns>
        [Route("{subcriptionbenefitId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubcriptionBenefit(int subcriptionbenefitId)
        {
            var result = await subscriptionBenefitService.DeleteSubcriptionBenefit(subcriptionbenefitId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
