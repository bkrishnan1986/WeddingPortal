#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | TopUpController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Vendor.Core.DTO.Requests.TopUp;
using Happy.Weddings.Vendor.Service.Queries.v1.TopUp;
using Happy.Weddings.Vendor.Core.DTO.Requests.TopUpBenefit;
using Happy.Weddings.Vendor.Service.Commands.v1.TopUp;
using Happy.Weddings.Vendor.Service.Queries.v1.TopUpBenefits;
using Happy.Weddings.Vendor.Service.Commands.v1.TopUpBenefit;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// TopUp operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("topups")]
    [ApiController]
    public class TopUpController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TopUpController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public TopUpController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the Top Up 
        /// </summary>
        /// <param name="topupsParameters">The Vendor subcription  Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTopUps([FromQuery] TopUpParameter topupsParameters)
        {
            var getAllTopUpsQuery = new GetAllTopUpQuery(topupsParameters);
            var result = await mediator.Send(getAllTopUpsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Gets the top up by identifier.
        /// </summary>
        /// <param name="topupId">The topup identifier.</param>
        /// <returns></returns>
        [Route("{topupId}")]
        [HttpGet]
        public async Task<IActionResult> GetTopUpById(int topupId)
        {
            var getTopUpQuery = new GetTopUpQuery(topupId);
            var result = await mediator.Send(getTopUpQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Top Up
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTopUp([FromBody] CreateTopUpRequest request)
        {
            var createTopUpCommand = new CreateTopUpcommand(request);
            var result = await mediator.Send(createTopUpCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Top Up
        /// </summary>
        /// <param name="topupId">The topup identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{topupId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTopUp(int topupId, [FromBody] UpdateTopUpRequest request)
        {
            var updateTopUpCommand = new UpdateTopUpCommand(topupId, request);
            var result = await mediator.Send(updateTopUpCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the Top up
        /// </summary>
        /// <param name="topupId">The topup identifier.</param>
        /// <returns></returns>
        [Route("{topupId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTopUp(int topupId)
        {
            var deleteTopUpCommand = new DeleteTopUpCommand(topupId);
            var result = await mediator.Send(deleteTopUpCommand);
            return StatusCode((int)result.Code, result.Value);
        }


        /// <summary>
        /// Gets the Top Up Benefit
        /// </summary>
        /// <param name="topupBenefitsParameters">The Vendor subcription  Parameters.</param>
        /// <returns></returns>
        [Route("topupbenefit")]
        [HttpGet]
        public async Task<IActionResult> GetTopUpBenefits([FromQuery] TopUpBenefitParameter topupBenefitsParameters)
        {
            var getAllTopUpBenefitsQuery = new GetAllTopUpBenefitsQuery(topupBenefitsParameters);
            var result = await mediator.Send(getAllTopUpBenefitsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Gets the top up Benefit by identifier.
        /// </summary>
        /// <param name="topupbenefitId">The topup identifier.</param>
        /// <returns></returns>
        [Route("{topupId}/topupbenefit/{topupbenefitId}")]
        [HttpGet]
        public async Task<IActionResult> GetTopupBenefitById(int topupbenefitId)
        {
            var getTopupBenefitQuery = new GetTopUpBenefitQuery(topupbenefitId);
            var result = await mediator.Send(getTopupBenefitQuery);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Create the Top Up Benefit
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// 
        [Route("{topupId}/topupbenefit")]
        [HttpPost]
        public async Task<IActionResult> CreateTopUpBenefit([FromBody] CreateTopUpBenefitRequest request)
        {
            var createTopUpBenefitCommand = new CreateTopUpBenefitCommand(request);
            var result = await mediator.Send(createTopUpBenefitCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Top Up Benefit
        /// </summary>
        /// <param name="topupId">The topup Benefit identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{topupId}/topupbenefit/{topupbenefitId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTopUpBenefit(int topupId, [FromBody] UpdateTopUpBenefitRequest request)
        {
            var updateTopUpBenefitCommand = new UpdateTopUpBenefitCommand(topupId, request);
            var result = await mediator.Send(updateTopUpBenefitCommand);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}