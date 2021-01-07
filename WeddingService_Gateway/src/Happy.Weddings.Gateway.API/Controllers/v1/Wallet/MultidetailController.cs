using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Multidetail;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Wallet
{
    /// <summary>
    /// Wallet operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("multidetails_wallet")]
    [ApiController]
    public class MultidetailController : ControllerBase
    {
        /// <summary>
        /// The Multidetail service
        /// </summary>
        private readonly IMultidetailService multidetailService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultidetailController"/> class.
        /// </summary>
        /// <param name="multidetailService">The Multidetail service.</param>
        public MultidetailController(
            IMultidetailService multidetailService)
        {
            this.multidetailService = multidetailService;
        }

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="multidetailParameter">The Multidetail parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllMultiDetails([FromQuery] MultidetailParameter multidetailParameter)
        {
            var result = await multidetailService.GetAllMultiDetails(multidetailParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the Multidetail.
        /// </summary>
        /// <param name="code">System Code.</param>
        /// <returns></returns>
        [Route("{code}")]
        [HttpGet]
        public async Task<IActionResult> GetMultiDetailsByCode(string code)
        {
            var result = await multidetailService.GetMultiDetailsByCode(code);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the Multidetail.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateMultiDetails([FromBody] CreateMultidetailWalletRequest request)
        {
            var result = await multidetailService.CreateMultiDetails(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{multidetailId}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateMultiDetails(int multidetailId, [FromBody] UpdateMultidetailWalletRequest request)
        {
            var result = await multidetailService.UpdateMultiDetails(new MultidetailIdDetails(multidetailId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Multidetail.
        /// </summary>
        /// <param name="multidetailId">The Multidetail identifier.</param>
        /// <returns></returns>
        [Route("{multidetailId}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMultiDetails(int multidetailId)
        {
            var result = await multidetailService.DeleteMultiDetails(new MultidetailIdDetails(multidetailId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
