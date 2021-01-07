using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Wallet
{
    /// <summary>
    /// Wallet operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("wallet")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        /// <summary>
        /// The Wallet service
        /// </summary>
        private readonly IWalletService walletService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletController"/> class.
        /// </summary>
        /// <param name="walletService">The Wallet service.</param>
        public WalletController(
            IWalletService walletService)
        {
            this.walletService = walletService;
        }

        /// <summary>
        /// Gets the Wallet.
        /// </summary>
        /// <param name="walletParameter">The Wallet parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllWallets([FromQuery] WalletParameter walletParameter)
        {
            var result = await walletService.GetAllWallets(walletParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the Wallet.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <returns></returns>
        [Route("{walletId}")]
        [HttpGet]
        public async Task<IActionResult> GetWalletDetails(int walletId)
        {
            var result = await walletService.GetWalletDetails(new WalletIdDetails(walletId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the Wallet.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateWallet([FromBody] CreateWalletRequest request)
        {
            var result = await walletService.CreateWallet(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the Wallet.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <param name="IsPaused">IsPaused Status.</param>
        /// <param name="IsReleased">IsReleased Status.</param>
        /// <param name="IsChurned">IsChurned Status.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{walletId}/{IsPaused}/{IsReleased}/{IsChurned}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateWallet(int walletId, bool IsPaused, bool IsReleased , bool IsChurned, [FromBody] UpdateWalletRequest request)
        {
            var result = await walletService.UpdateWallet(new WalletIdDetails(walletId, IsPaused, IsReleased, IsChurned), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Wallet.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <returns></returns>
        [Route("{walletId}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteWallet(int walletId)
        {
            var result = await walletService.DeleteWallet(new WalletIdDetails(walletId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
