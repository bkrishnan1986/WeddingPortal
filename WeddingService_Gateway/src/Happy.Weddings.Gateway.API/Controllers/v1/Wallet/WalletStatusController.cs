using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletStatus;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Wallet
{
    /// <summary>
    /// Wallet operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("walletStatus")]
    [ApiController]
    public class WalletStatusController : ControllerBase
    {
        /// <summary>
        /// The WalletStatus service
        /// </summary>
        private readonly IWalletStatusService walletStatusService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletStatusController"/> class.
        /// </summary>
        /// <param name="walletStatusService">The WalletStatus service.</param>
        public WalletStatusController(
            IWalletStatusService walletStatusService)
        {
            this.walletStatusService = walletStatusService;
        }

        /// <summary>
        /// Gets the WalletStatus.
        /// </summary>
        /// <param name="walletStatusParameter">The WalletStatus parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllWalletStatus([FromQuery] WalletStatusParameter walletStatusParameter)
        {
            var result = await walletStatusService.GetAllWalletStatus(walletStatusParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the WalletStatus.
        /// </summary>
        /// <param name="walletStatusId">The WalletStatus identifier.</param>
        /// <returns></returns>
        [Route("{walletStatusId}")]
        [HttpGet]
        public async Task<IActionResult> GetWalletDetails(int walletStatusId)
        {
            var result = await walletStatusService.GetWalletStatusDetails(new WalletStatusIdDetails(walletStatusId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the WalletStatus.
        /// </summary>
        /// <param name="IsPaused">IsPaused Status.</param>
        /// <param name="IsReleased">IsReleased Status.</param>
        /// <param name="IsChurned">IsChurned Status.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{IsPaused}/{IsReleased}/{IsChurned}")]
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateWalletStatus(bool IsPaused, bool IsReleased, bool IsChurned, [FromBody] CreateWalletStatusRequest request)
        {
            var result = await walletStatusService.CreateWalletStatus(IsPaused, IsReleased, IsChurned, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the WalletStatus.
        /// </summary>
        /// <param name="walletStatusId">The WalletStatus identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{walletStatusId}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateWalletStatus(int walletStatusId, [FromBody] UpdateWalletStatusRequest request)
        {
            var result = await walletStatusService.UpdateWalletStatus(new WalletStatusIdDetails(walletStatusId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the WalletStatus.
        /// </summary>
        /// <param name="walletStatusId">The WalletStatus identifier.</param>
        /// <returns></returns>
        [Route("{walletStatusId}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteWalletStatus(int walletStatusId)
        {
            var result = await walletStatusService.DeleteWalletStatus(new WalletStatusIdDetails(walletStatusId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
