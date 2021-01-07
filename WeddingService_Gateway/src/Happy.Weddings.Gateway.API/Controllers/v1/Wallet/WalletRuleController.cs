using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Gateway.API.Filters;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletRule;
using Happy.Weddings.Gateway.Core.Services.v1.Wallet;
using Microsoft.AspNetCore.Authorization;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Wallet
{
    /// <summary>
    /// Wallet operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("walletRule")]
    [ApiController]
    public class WalletRuleController : ControllerBase
    {
        /// <summary>
        /// The WalletRule service
        /// </summary>
        private readonly IWalletRuleService walletRuleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletRuleController"/> class.
        /// </summary>
        /// <param name="walletRuleService">The WalletRule service.</param>
        public WalletRuleController(
            IWalletRuleService walletRuleService)
        {
            this.walletRuleService = walletRuleService;
        }

        /// <summary>
        /// Gets the WalletRules.
        /// </summary>
        /// <param name="walletRuleParameter">The WalletRule parameters request.</param>
        /// <returns></returns>
        [HttpGet]
        [RequestRateLimit(Name = "Limit Request Number", Seconds = 1)]
        public async Task<IActionResult> GetAllWallets([FromQuery] WalletRuleParameter walletRuleParameter)
        {
            var result = await walletRuleService.GetAllWalletRules(walletRuleParameter);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the WalletRuleBy Id.
        /// </summary>
        /// <param name="walletRuleId">The WalletRule identifier.</param>
        /// <returns></returns>
        [Route("{walletRuleId}")]
        [HttpGet]
        public async Task<IActionResult> GetWalletDetails(int walletRuleId)
        {
            var result = await walletRuleService.GetWalletRuleDetails(new WalletRuleIdDetails(walletRuleId));
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the WalletRule.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> CreateWallet([FromBody] CreateWalletRuleRequest request)
        {
            var result = await walletRuleService.CreateWalletRule(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates the WalletRule.
        /// </summary>
        /// <param name="walletRuleId">The WalletRule identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{walletRuleId}")]
        [HttpPut]
        //[Authorize(Roles = "Admin, Vendor")]
        public async Task<IActionResult> UpdateWallet(int walletRuleId, [FromBody] UpdateWalletRuleRequest request)
        {
            var result = await walletRuleService.UpdateWalletRule(new WalletRuleIdDetails(walletRuleId), request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the WalletRule.
        /// </summary>
        /// <param name="walletRuleId">The WalletRule identifier.</param>
        /// <returns></returns>
        [Route("{walletRuleId}")]
        [HttpDelete]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteWallet(int walletRuleId)
        {
            var result = await walletRuleService.DeleteWalletRule(new WalletRuleIdDetails(walletRuleId));
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
