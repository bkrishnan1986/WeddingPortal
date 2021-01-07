#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionsController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionPlans;
using Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionPlans;

namespace Happy.Weddings.Vendor.API.Controllers.v1
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
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public SubscriptionsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the Subcription Plans
        /// </summary>
        /// <param name="subscriptionPlansParameters">The subcription Plans Parameters.</param>
        /// <returns></returns>
        [HttpGet]  
        public async Task<IActionResult> GetSubcriptionPlans([FromQuery] SubscriptionPlansParameter subscriptionPlansParameters)
        {
            var getAllSubscriptionPlansQuery = new GetAllSubscriptionPlansQuery(subscriptionPlansParameters);
            var result = await mediator.Send(getAllSubscriptionPlansQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

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
            var getSubcriptionPlanQuery = new GetSubscriptionPlanQuery(subscriptionPlanId);
            var result = await mediator.Send(getSubcriptionPlanQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Subcription Plan.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateSubcriptionPlan([FromBody] CreateSubscriptionPlanRequest request )
        {
            // var createSubcriptionPlanCommand = new CreateSubscriptionPlanCommand(request,request1);
            var createSubcriptionPlanCommand = new CreateSubscriptionPlanCommand(request);
             var result = await mediator.Send(createSubcriptionPlanCommand);
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
            var updateSubcriptionPlanCommand = new UpdateSubscriptionPlanCommand(subscriptionplanId, request);
            var result = await mediator.Send(updateSubcriptionPlanCommand);
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
            var deleteSubcriptionPlanCommand = new DeleteSubscriptionPlanCommand(subscriptionplanId);
            var result = await mediator.Send(deleteSubcriptionPlanCommand);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}