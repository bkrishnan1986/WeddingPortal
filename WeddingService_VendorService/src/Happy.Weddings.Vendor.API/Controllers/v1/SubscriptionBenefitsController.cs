#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionBenefitsController --Controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionBenefits;
using Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionBenefits;

namespace Happy.Weddings.Vendor.API.Controllers.v1
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
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionBenefitsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public SubscriptionBenefitsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the Subcription Benefits
        /// </summary>
        /// <param name="subscriptionBenefitsParameters">The subcription Plans Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionPlans([FromQuery] SubscriptionBenefitsParameter subscriptionBenefitsParameters)
        {
            var getAllSubscriptionBenefitsQuery = new GetAllSubscriptionBenefitsQuery(subscriptionBenefitsParameters);
            var result = await mediator.Send(getAllSubscriptionBenefitsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

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
            var getSubcriptionPlanQuery = new GetSubscriptionBenefitQuery(subcriptionBenefitId);
            var result = await mediator.Send(getSubcriptionPlanQuery);
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
            var createSubcriptionBenefitCommand = new CreateSubscriptionBenefitCommand(request);
            var result = await mediator.Send(createSubcriptionBenefitCommand);
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
            var updateSubcriptionBenefitCommand = new UpdateSubscriptionBenefitCommand(subcriptionbenefitId, request);
            var result = await mediator.Send(updateSubcriptionBenefitCommand);
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
            var deleteSubcriptionBenefitCommand = new DeleteSubscriptionBenefitCommand(subcriptionbenefitId);
            var result = await mediator.Send(deleteSubcriptionBenefitCommand);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}