#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletDeductionController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletDeduction;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletDeduction;
using Happy.Weddings.Wallet.Service.Queries.v1.WalletDeduction;
using Happy.Weddings.Wallet.Core.Domain;
using MediatR;
using System.Net;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.API.Controllers.v1
{
    /// <summary>
    /// WalletDeduction operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("walletDeduction")]
    [ApiController]
    public class WalletDeductionController : ControllerBase
    {
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletDeductionController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public WalletDeductionController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Wallet

        /// <summary>
        /// Gets the Wallet Deduction
        /// </summary>
        /// <param name="walletDeductionParameter">The Wallets Deduction Parameter.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllWalletDeduction([FromQuery] WalletDeductionParameter walletDeductionParameter)
        {
            var getAllWalletDeductionQuery = new GetAllWalletDeductionQuery(walletDeductionParameter);

            var result = await mediator.Send(getAllWalletDeductionQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Wallet Deduction
        /// </summary>
        /// <param name="walletDeductionId">The Wallet Deduction identifier.</param>
        /// <returns></returns>
        [Route("{walletDeductionId}")]
        [HttpGet]
        public async Task<IActionResult> GetWalletDeductionDetails(int walletDeductionId)
        {
            var getWalletDeductionQuery = new GetWalletDeductionQuery(walletDeductionId);

            var result = await mediator.Send(getWalletDeductionQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Wallet Deduction
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateWalletDeduction([FromBody] CreateWalletDeductionRequest request)
        {
            var createWalletDeductionCommand = new CreateWalletDeductionCommand(request);
            var result = await mediator.Send(createWalletDeductionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates Wallet Deduction.
        /// </summary>
        /// <param name="walletDeductionId">The Wallet Deduction identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{walletDeductionId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateWalletDeduction(int walletDeductionId, [FromBody] UpdateWalletDeductionRequest request)
        {
            var updateWalletDeductionCommand = new UpdateWalletDeductionCommand(walletDeductionId, request);
            var result = await mediator.Send(updateWalletDeductionCommand);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Wallet Deduction.
        /// </summary>
        /// <param name="walletDeductionId">The Wallet Deduction identifier.</param>
        /// <returns></returns>
        [Route("{walletDeductionId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteWalletDeduction(int walletDeductionId)
        {
            var deleteWalletDeductionCommand = new DeleteWalletDeductionCommand(walletDeductionId);
            var result = await mediator.Send(deleteWalletDeductionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}
