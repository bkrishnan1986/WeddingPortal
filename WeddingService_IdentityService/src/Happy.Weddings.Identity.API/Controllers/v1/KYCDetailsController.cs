#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | KYCDetailsController class
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Identity.Core.DTO.Requests.KYCDetail;
using Happy.Weddings.Identity.Service.Commands.v1.KYCDetail;
using Happy.Weddings.Identity.Service.Queries.v1.KYCDetail;

#endregion

namespace Happy.Weddings.Identity.API.Controllers.v1
{
    /// <summary>
    /// KYCDetailsController
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("profiles")]
    [ApiController]
    public class KYCDetailsController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public KYCDetailsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Creates the kyc data.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{profileId}/kyc")]
        public async Task<IActionResult> CreateKYCData(int profileId,[FromBody] CreateKYCDataRequest request)
        {
            var createKYCDetailCommand = new CreateKYCDataCommand(profileId, request);
            var result = await mediator.Send(createKYCDetailCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the kyc data.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{profileId}/kyc")]
        [HttpPut]
        public async Task<IActionResult> UpdateKYCData(int profileId, [FromBody] UpdateKYCDataRequest request)
        {
            var updateKYCDetailCommand = new UpdateKYCDataCommand(profileId, request);
            var result = await mediator.Send(updateKYCDetailCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the kyc portion.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{profileId}/kyc")]
        [HttpPatch]
        public async Task<IActionResult> UpdateKYCPortion(int profileId, [FromBody] UpdateKYCPortionRequest request)
        {
            var updateKYCPortionCommand = new UpdateKYCPortionCommand(profileId, request);
            var result = await mediator.Send(updateKYCPortionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        [Route("{profileId}/kyc")]
        [HttpGet]
        public async Task<IActionResult> GetKYCDatas(int profileId)
        {
            var getUserProfileQuery = new GetKYCDataQuery(profileId);
            var result = await mediator.Send(getUserProfileQuery);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
