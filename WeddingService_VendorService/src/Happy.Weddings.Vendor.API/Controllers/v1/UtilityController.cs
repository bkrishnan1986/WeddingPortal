#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | VendorSubscriptionsController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Vendor.Core.DTO.Requests.Utility;
using Happy.Weddings.Vendor.Service.Queries.v1.Utility;
using Happy.Weddings.Vendor.Service.Commands.v1.Utility;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Vendors Subcriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("utility")]
    [ApiController]
    public class UtilityController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceSubscriptionsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public UtilityController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }


        /// <summary>
        /// Gets the subscription utility.
        /// </summary>
        /// <param name="subscriptionUtilityParameters">The subscription utility parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSubscriptionUtility([FromQuery] SubscriptionUtilityParameters subscriptionUtilityParameters)
        {
            var getAllserviceSubscriptionsQuery = new GetAllUtilityQuery(subscriptionUtilityParameters);
            var result = await mediator.Send(getAllserviceSubscriptionsQuery);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Gets the subscription utility by identifier.
        /// </summary>
        /// <param name="UtilityId">The utility identifier.</param>
        /// <returns></returns>
        [Route("{UtilityId}")]
        [HttpGet]
        public async Task<IActionResult> GetSubscriptionUtilityById(int UtilityId)
        {
            var getServiceSubscriptionIdQuery = new GetUtilityQuery(UtilityId);
            var result = await mediator.Send(getServiceSubscriptionIdQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the subscription utility.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSubscriptionUtility([FromBody] CreateUtilityRequest request)
        {
            var createserviceSubcriptionCommand = new CreateUtilityCommand(request);
            var result = await mediator.Send(createserviceSubcriptionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the subscription utility.
        /// </summary>
        /// <param name="SubscriptionUtilityId">The subscription utility identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{subscriptionutilityId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSubscriptionUtility(int SubscriptionUtilityId, [FromBody] UpdateUtilityRequest request)
        {
            var updateServiceSubscriptionCommand = new UpdateUtilityCommand(SubscriptionUtilityId, request);
            var result = await mediator.Send(updateServiceSubscriptionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the subscription utility.
        /// </summary>
        /// <param name="SubscriptionUtilityId">The subscription utility identifier.</param>
        /// <returns></returns>
        [Route("{subscriptionutilityId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubscriptionUtility(int SubscriptionUtilityId)
        {
            var deleteServiceSubscriptionCommand = new DeleteUtilityCommand(SubscriptionUtilityId);
            var result = await mediator.Send(deleteServiceSubscriptionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}