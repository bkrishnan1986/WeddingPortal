
#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletRuleController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletRule;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletRule;
using Happy.Weddings.Wallet.Service.Queries.v1.WalletRule;
using Happy.Weddings.Wallet.Core.Domain;
using MediatR;
using System.Net;

namespace Happy.Weddings.Wallet.API.Controllers.v1
{
    /// <summary>
    /// WalletRule operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("walletRule")]
    [ApiController]
    public class WalletRuleController : ControllerBase
    {
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletRuleController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public WalletRuleController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region WalletRule

        /// <summary>
        /// Gets the WalletRules
        /// </summary>
        /// <param name="walletRuleParameter">The Wallet Rule Parameter.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllWalletRules([FromQuery] WalletRuleParameter walletRuleParameter)
        {
            var getAllWalletRuleQuery = new GetAllWalletRuleQuery(walletRuleParameter);
            var result = await mediator.Send(getAllWalletRuleQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Wallet Rule By WalletRuleId
        /// </summary>
        /// <param name="walletRuleId">The WalletRule identifier.</param>
        /// <returns></returns>
        [Route("{walletRuleId}")]
        [HttpGet]
        public async Task<IActionResult> GetWalletRuleDetails(int walletRuleId)
        {
            var getWalletRuleQuery = new GetWalletRuleQuery(walletRuleId);
            var result = await mediator.Send(getWalletRuleQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Wallet Rule
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateWalletRule([FromBody] CreateWalletRuleRequest request)
        {
            var createWalletRuleCommand = new CreateWalletRuleCommand(request);
            var result = await mediator.Send(createWalletRuleCommand);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates Wallet Rule.
        /// </summary>
        /// <param name="walletRuleId">The Wallet Rule identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{walletRuleId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateWalletRule(int walletRuleId, [FromBody] UpdateWalletRuleRequest request)
        {
            var updateWalletRuleCommand = new UpdateWalletRuleCommand(walletRuleId, request);
            var result = await mediator.Send(updateWalletRuleCommand);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Wallet Rule.
        /// </summary>
        /// <param name="walletRuleId">The Wallet Rule identifier.</param>
        /// <returns></returns>
        [Route("{walletRuleId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteWalletRule(int walletRuleId)
        {
            var deleteWalletRuleCommand = new DeleteWalletRuleCommand(walletRuleId);
            var result = await mediator.Send(deleteWalletRuleCommand);

            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}
