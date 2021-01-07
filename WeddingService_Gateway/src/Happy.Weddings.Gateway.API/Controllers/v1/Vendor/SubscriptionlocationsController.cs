using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionLocation;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// Subcriptions Locations operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("subscriptionlocations")]
    [ApiController]
    public class SubscriptionlocationsController : Controller
    {
        /// <summary>
        /// The subscriptionlocation service
        /// </summary>
        private readonly ISubscriptionLocationService subscriptionlocationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionlocationsController"/> class.
        /// </summary>
        /// <param name="subscriptionlocationService">The subscriptionlocation service.</param>
        public SubscriptionlocationsController(
            ISubscriptionLocationService subscriptionlocationService)
        {
            this.subscriptionlocationService = subscriptionlocationService;
        }

        /// <summary>
        /// Gets the subscriptionLocations
        /// </summary>
        /// <param name="subscriptionLocationsParameter">The subcription Plans Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionLocations([FromQuery] SubscriptionLocationsParameter subscriptionLocationsParameter)
        {
            var result = await subscriptionlocationService.GetSubcriptionLocations(subscriptionLocationsParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the subscription Location
        /// </summary>
        /// <param name="subscriptionLocationId">The subscriptionLocation identifier.</param>
        /// <returns></returns>
        [Route("{subscriptionLocationId}")]
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionPlan(int subscriptionLocationId)
        {
            var result = await subscriptionlocationService.GetSubcriptionPlan(subscriptionLocationId);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the subscriptionLocation
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSubcriptionLocation([FromBody] CreateSubscriptionLocationRequest request)
        {
            var result = await subscriptionlocationService.CreateSubcriptionLocation(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the subscriptionLocation
        /// </summary>
        /// <param name="subscriptionLocationId">The subscriptionLocation identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{subscriptionLocationId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSubcriptionPlan(int subscriptionLocationId, 
            [FromBody] UpdateSubscriptionLocationRequest request)
        {
            var result = await subscriptionlocationService.UpdateSubcriptionPlan(subscriptionLocationId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the subscriptionLocation.
        /// </summary>
        /// <param name="subscriptionLocationId">The subscriptionLocation identifier.</param>
        /// <returns></returns>
        [Route("{subscriptionLocationId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubcriptionPlan(int subscriptionLocationId)
        {
            var result = await subscriptionlocationService.DeleteSubcriptionPlan(subscriptionLocationId);
            return StatusCode((int)result.Code, result.Value);
        }


    }
}
