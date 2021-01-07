using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Wallet
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("walletDeduction")]
    [ApiController]
    public class WalletDeductionController : ControllerBase
    {
        /// <summary>
        /// The WalletDeduction service
        /// </summary>
        private readonly IWalletDeductionService walletDeductionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletDeductionController"/> class.
        /// </summary>
        /// <param name="walletDeductionService">The WalletDeduction service.</param>
        public WalletDeductionController(
            IWalletDeductionService walletDeductionService)
        {
            this.walletDeductionService = walletDeductionService;
        }

        /// <summary>
        /// Gets the WalletDeduction.
        /// </summary>
        /// <param name="walletDeductionParameter">The WalletDeduction parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllWalletDeduction([FromQuery] WalletDeductionParameter walletDeductionParameter)
        {
            var result = await walletDeductionService.GetAllWalletDeduction(walletDeductionParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the WalletDeduction.
        /// </summary>
        /// <param name="walletDeductionId">The WalletDeduction identifier.</param>
        /// <returns></returns>
        [Route("{walletDeductionId}")]
        [HttpGet]
        public async Task<IActionResult> GetWalletDeductionDetails(int walletDeductionId)
        {
            var result = await walletDeductionService.GetWalletDeductionDetails(new WalletDeductionIdDetails(walletDeductionId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the WalletDeduction.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateWalletDeduction([FromBody] CreateWalletDeductionRequest request)
        {
            var result = await walletDeductionService.CreateWalletDeduction(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the WalletDeduction.
        /// </summary>
        /// <param name="walletDeductionId">The WalletDeduction identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{walletDeductionId}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateWalletDeduction(int walletDeductionId, [FromBody] UpdateWalletDeductionRequest request)
        {
            var result = await walletDeductionService.UpdateWalletDeduction(new WalletDeductionIdDetails(walletDeductionId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the WalletDeduction.
        /// </summary>
        /// <param name="walletDeductionId">The WalletDeduction identifier.</param>
        /// <returns></returns>
        [Route("{walletDeductionId}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteWalletDeduction(int walletDeductionId)
        {
            var result = await walletDeductionService.DeleteWalletDeduction(new WalletDeductionIdDetails(walletDeductionId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
