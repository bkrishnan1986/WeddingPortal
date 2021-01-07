#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  28-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionlocationsController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionLocation;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionLocation;
using Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionLocation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.API.Controllers.v1
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
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionlocationsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public SubscriptionlocationsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the subscriptionLocations
        /// </summary>
        /// <param name="subscriptionLocationsParameter">The subcription Plans Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionLocations([FromQuery] SubscriptionLocationsParameter subscriptionLocationsParameter)
        {
            var getAllSubscriptionPlansQuery = new GetAllSubscriptionLocationsQuery(subscriptionLocationsParameter);
            var result = await mediator.Send(getAllSubscriptionPlansQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the subscription Location
        /// </summary>
        /// <param name="locationParameters">The subscriptionLocation identifier.</param>
        /// <returns></returns>
        [Route("locationParameters")]
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionPlan([FromQuery] LocationParameters locationParameters)
        {
            var getSubcriptionLocationQuery = new GetSubscriptionLocationQuery(locationParameters);
            var result = await mediator.Send(getSubcriptionLocationQuery);
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
            // var createSubcriptionPlanCommand = new CreateSubscriptionPlanCommand(request,request1);
            var createSubcriptionLocationCommand = new CreateSubscriptionLocationCommand(request);
            var result = await mediator.Send(createSubcriptionLocationCommand);
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
        public async Task<IActionResult> UpdateSubcriptionPlan(int subscriptionLocationId, [FromBody] UpdateSubscriptionLocationRequest request)
        {
            var updateSubcriptionLocationCommand = new UpdateSubscriptionLocationCommand(subscriptionLocationId, request);
            var result = await mediator.Send(updateSubcriptionLocationCommand);
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
            var deleteSubcriptionLocationCommand = new DeleteSubscriptionLocationCommand(subscriptionLocationId);
            var result = await mediator.Send(deleteSubcriptionLocationCommand);
            return StatusCode((int)result.Code, result.Value);
        }


    }
}