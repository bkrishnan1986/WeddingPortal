using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletAdjustment;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Wallet
{
    /// <summary>
    /// Wallet operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("walletAdjustment")]
    [ApiController]
    public class WalletAdjustmentController : ControllerBase
    {
        /// <summary>
        /// The WalletAdjustment service
        /// </summary>
        private readonly IWalletAdjustmentService walletAdjustmentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletAdjustmentController"/> class.
        /// </summary>
        /// <param name="walletAdjustmentService">The WalletAdjustment service.</param>
        public WalletAdjustmentController(
            IWalletAdjustmentService walletAdjustmentService)
        {
            this.walletAdjustmentService = walletAdjustmentService;
        }

        /// <summary>
        /// Gets the WalletAdjustment.
        /// </summary>
        /// <param name="walletAdjustmentParameter">The WalletAdjustment parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllWalletAdjustment([FromQuery] WalletAdjustmentParameter walletAdjustmentParameter)
        {
            var result = await walletAdjustmentService.GetAllWalletAdjustment(walletAdjustmentParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the WalletAdjustment.
        /// </summary>
        /// <param name="walletAdjustmentId">The WalletAdjustment identifier.</param>
        /// <returns></returns>
        [Route("{walletAdjustmentId}")]
        [HttpGet]
        public async Task<IActionResult> GetWalletAdjustmentDetails(int walletAdjustmentId)
        {
            var result = await walletAdjustmentService.GetWalletAdjustmentDetails(new WalletAdjustmentIdDetails(walletAdjustmentId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the WalletAdjustment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateWalletAdjustment([FromBody] CreateWalletAdjustmentRequest request)
        {
            var result = await walletAdjustmentService.CreateWalletAdjustment(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the WalletAdjustment.
        /// </summary>
        /// <param name="walletAdjustmentId">The WalletAdjustment identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{walletAdjustmentId}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateWalletAdjustment(int walletAdjustmentId, [FromBody] UpdateWalletAdjustmentRequest request)
        {
            var result = await walletAdjustmentService.UpdateWalletAdjustment(new WalletAdjustmentIdDetails(walletAdjustmentId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the WalletAdjustment.
        /// </summary>
        /// <param name="walletAdjustmentId">The WalletAdjustment identifier.</param>
        /// <returns></returns>
        [Route("{walletAdjustmentId}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteWalletAdjustment(int walletAdjustmentId)
        {
            var result = await walletAdjustmentService.DeleteWalletAdjustment(new WalletAdjustmentIdDetails(walletAdjustmentId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
