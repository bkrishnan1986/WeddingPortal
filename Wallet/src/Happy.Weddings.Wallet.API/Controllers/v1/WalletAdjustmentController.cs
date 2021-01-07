#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |   NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletAdjustmentController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletAdjustment;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletAdjustment;
using Happy.Weddings.Wallet.Service.Queries.v1.WalletAdjustment;
using Happy.Weddings.Wallet.Core.Domain;
using MediatR;
using System.Net;

namespace Happy.Weddings.Wallet.API.Controllers.v1
{
    /// <summary>
    /// Wallet Adjustment operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("walletAdjustment")]
    [ApiController]
    public class WalletAdjustmentController : ControllerBase
    {
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletAdjustmentController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public WalletAdjustmentController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Wallet Adjustment

        /// <summary>
        /// Gets the Wallet Adjustment
        /// </summary>
        /// <param name="walletAdjustmentParameter">The Wallets Adjustment Parameter.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllWalletAdjustment([FromQuery] WalletAdjustmentParameter walletAdjustmentParameter)
        {
            var getAllWalletAdjustmentQuery = new GetAllWalletAdjustmentQuery(walletAdjustmentParameter);

            var result = await mediator.Send(getAllWalletAdjustmentQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Wallet Adjustment
        /// </summary>
        /// <param name="walletAdjustmentId">The Wallet Adjustment identifier.</param>
        /// <returns></returns>
        [Route("{walletAdjustmentId}")]
        [HttpGet]
        public async Task<IActionResult> GetWalletAdjustmentDetails(int walletAdjustmentId)
        {
            var getWalletAdjustmentQuery = new GetWalletAdjustmentQuery(walletAdjustmentId);

            var result = await mediator.Send(getWalletAdjustmentQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Wallet Adjustment
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateWalletAdjustment([FromBody] CreateWalletAdjustmentRequest request)
        {
            var createWalletAdjustmentCommand = new CreateWalletAdjustmentCommand(request);
            var result = await mediator.Send(createWalletAdjustmentCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates Wallet Adjustment.
        /// </summary>
        /// <param name="walletAdjustmentId">The Wallet Adjustment identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{walletAdjustmentId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateWalletAdjustment(int walletAdjustmentId, [FromBody] UpdateWalletAdjustmentRequest request)
        {
            var updateWalletAdjustmentCommand = new UpdateWalletAdjustmentCommand(walletAdjustmentId, request);
            var result = await mediator.Send(updateWalletAdjustmentCommand);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Wallet Adjustment.
        /// </summary>
        /// <param name="walletAdjustmentId">The Wallet Adjustment identifier.</param>
        /// <returns></returns>
        [Route("{walletAdjustmentId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteWalletAdjustment(int walletAdjustmentId)
        {
            var deleteWalletAdjustmentCommand = new DeleteWalletAdjustmentCommand(walletAdjustmentId);
            var result = await mediator.Send(deleteWalletAdjustmentCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}
