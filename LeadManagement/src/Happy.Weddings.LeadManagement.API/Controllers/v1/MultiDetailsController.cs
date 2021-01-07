#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | Reji Salooja B S  | Created and implemented.
//             |                   | MultiDetailController controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.LeadManagement.Core.Domain;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.MultiDetail;
using Happy.Weddings.LeadManagement.Service.Commands.v1.MultiDetail;
using Happy.Weddings.LeadManagement.Service.Queries.v1.MultiDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Happy.Weddings.LeadManagement.API.Controllers.v1
{
    /// <summary>
    /// Lead management multidetail operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("multidetails")]
    [ApiController]
    public class MultiDetailsController : ControllerBase
    {
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiDetailsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public MultiDetailsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Task

        /// <summary>
        /// Gets All the multidetails.
        /// </summary>
        /// <param name="multiDetailParameters">The multidetail parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllMultiDetails([FromQuery] MultiDetailParameters multiDetailParameters)
        {
            var getAllMultiDetailsQuery = new GetAllMultiDetailsQuery(multiDetailParameters);
            var result = await mediator.Send(getAllMultiDetailsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the multidetails
        /// </summary>
        /// <param name="code">System Code</param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpGet]
        public async Task<IActionResult> GetMultiDetailsByCode(string code)
        {
            var getMultiDetailQuery = new GetMultiDetailsByIdQuery(code);
            var result = await mediator.Send(getMultiDetailQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the multidetail.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMultiDetails([FromBody] CreateMultiDetailsRequest request)
        {
            var createMultiDetailsCommand = new CreateMultiDetailsCommand(request);
            var result = await mediator.Send(createMultiDetailsCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates MultiDetail.
        /// </summary>
        /// <param name="multidetailId">The multidetail identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{multidetailId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMultiDetails(int multidetailId, [FromBody] UpdateMultiDetailsRequest request)
        {
            var updateMultiDetailCommand = new UpdateMultiDetailsCommand(multidetailId, request);
            var result = await mediator.Send(updateMultiDetailCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the MultiDetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        [Route("{multidetailId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMultiDetails(int multidetailId)
        {
            var deleteMultiDetailsCommand = new DeleteMultiDetailsCommand(multidetailId);
            var result = await mediator.Send(deleteMultiDetailsCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}