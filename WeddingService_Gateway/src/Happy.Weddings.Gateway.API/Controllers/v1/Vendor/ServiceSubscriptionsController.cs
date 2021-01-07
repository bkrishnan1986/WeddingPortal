using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceSubscription;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// Vendors Subcriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/vendor/servicesubscriptions")]
    [ApiController]
    public class ServiceSubscriptionsController : Controller
    {
        /// <summary>
        /// The service subscription service
        /// </summary>
        private readonly IServiceSubscriptionService serviceSubscriptionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceSubscriptionsController"/> class.
        /// </summary>
        /// <param name="serviceSubscriptionService">The service subscription.</param>
        public ServiceSubscriptionsController(
            IServiceSubscriptionService serviceSubscriptionService)
        {
            this.serviceSubscriptionService = serviceSubscriptionService;
        }

        /// <summary>
        /// Gets the Service Subcription 
        /// </summary>
        /// <param name="serviceSubscriptionsParameter">The Service subcription  Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetServiceSubscriptions([FromQuery] ServiceSubscriptionsParameter serviceSubscriptionsParameter)
        {
            var result = await serviceSubscriptionService.GetServiceSubscriptions(serviceSubscriptionsParameter);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Get the Service Subscription.
        /// </summary>
        /// <param name="serviceSubscriptionId">The Service Subscription identifier.</param>
        /// <returns></returns>
        [Route("{serviceSubscriptionId}")]
        [HttpGet]
        public async Task<IActionResult> GetServiceSubscriptionById(int serviceSubscriptionId)
        {
            var result = await serviceSubscriptionService.GetServiceSubscriptionById(serviceSubscriptionId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Service Subscription
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateServiceSubscription([FromBody] CreateServiceSubscriptionRequest request)
        {
            var result = await serviceSubscriptionService.CreateServiceSubscription(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the servicesubscription 
        /// </summary>
        /// <param name="servicesubscriptionId">The vendor subscription identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{servicesubscriptionId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateVendorSubscription(int servicesubscriptionId, [FromBody] UpdateServiceSubscriptionRequest request)
        {
            var result = await serviceSubscriptionService.UpdateVendorSubscription(servicesubscriptionId,request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the service subscription.
        /// </summary>
        /// <param name="servicesubscriptionId">The subcriptionbenefit identifier.</param>
        /// <returns></returns>
        [Route("{servicesubscriptionId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteServiceSubscription(int servicesubscriptionId)
        {
            var result = await serviceSubscriptionService.DeleteServiceSubscription(servicesubscriptionId);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}
