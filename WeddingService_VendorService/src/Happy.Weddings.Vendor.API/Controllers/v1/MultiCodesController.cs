#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 03-Aug-2020 | Reji Salooja B S  | Created and implemented.
// | | MultiCodeController controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.MultiCode;
using Happy.Weddings.Vendor.Service.Commands.v1.MultiCode;
using Happy.Weddings.Vendor.Service.Queries.v1.MultiCode;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{  
    /// <summary>
   /// Vendors multicode operations handled by this controller
   /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("multicodes")]
    [ApiController]
    public class MultiCodesController : ControllerBase
    {
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiCodesController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public MultiCodesController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Task

        /// <summary>
        /// Gets all the MultiCodes.
        /// </summary>
        /// <param name="multiCodeParameters">The multicode parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetMultiCodes([FromQuery] MultiCodeParameters multiCodeParameters)
        {
            var getAllMultiCodeQuery = new GetAllMultiCodesQuery(multiCodeParameters);
            var result = await mediator.Send(getAllMultiCodeQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the multicode.
        /// </summary>
        /// <param name="code">System Code</param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpGet]
        public async Task<IActionResult> GetMultiCodeById(string code)
        {
            var getMultiCodeQuery = new GetMultiCodeQuery(code);
            var result = await mediator.Send(getMultiCodeQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the Multicode.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateMultiCode([FromBody] CreateMultiCodeRequest request)
        {
            var createMultiCodeCommand = new CreateMultiCodeCommand(request);
            var result = await mediator.Send(createMultiCodeCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates MultiCode.
        /// </summary>
        /// <param name="code">System Code</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpPut]
        public async Task<IActionResult> UpdateMultiCode(string code, [FromBody] UpdateMultiCodeRequest request)
        {
            var updateMultiCodeCommand = new UpdateMultiCodeCommand(code, request);
            var result = await mediator.Send(updateMultiCodeCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the MultiCode.
        /// </summary>
        /// <param name="code">System Code</param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMultiCode(string code)
        {
            var deleteMultiCodeCommand = new DeleteMultiCodeCommand(code);
            var result = await mediator.Send(deleteMultiCodeCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}