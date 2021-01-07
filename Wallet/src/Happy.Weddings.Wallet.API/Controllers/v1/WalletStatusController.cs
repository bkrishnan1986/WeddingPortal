#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS    | Created and implemented. 
//              |                         | WalletStatusController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Wallet.Core.DTO.Requests.WalletStatus;
using Happy.Weddings.Wallet.Service.Commands.v1.WalletStatus;
using Happy.Weddings.Wallet.Service.Queries.v1.WalletStatus;
using Happy.Weddings.Wallet.Core.Domain;
using MediatR;
using System.Net;
using Happy.Weddings.Wallet.Core.DTO.Requests.Wallet;
using Happy.Weddings.Wallet.Service.Queries.v1.Wallet;

namespace Happy.Weddings.Wallet.API.Controllers.v1
{
    /// <summary>
    /// Wallet Status operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("walletStatus")]
    [ApiController]
    public class WalletStatusController : ControllerBase
    {
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletStatusController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public WalletStatusController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Wallet

        /// <summary>
        /// Gets the Wallet Status
        /// </summary>
        /// <param name="walletStatusParameter">The Wallet Status Parameter.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllWalletStatus([FromQuery] WalletStatusParameter walletStatusParameter)
        {
            var getAllWalletStatusQuery = new GetAllWalletStatusQuery(walletStatusParameter);

            var result = await mediator.Send(getAllWalletStatusQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Wallet Status
        /// </summary>
        /// <param name="walletStatusId">The Wallet Status identifier.</param>
        /// <returns></returns>
        [Route("{walletStatusId}")]
        [HttpGet]
        public async Task<IActionResult> GetWalletStatusDetails(int walletStatusId)
        {
            var getWalletStatusQuery = new GetWalletStatusQuery(walletStatusId);

            var result = await mediator.Send(getWalletStatusQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Wallet Status
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateWalletStatus([FromBody] CreateWalletStatusRequest request)
        {
            var createWalletStatusCommand = new CreateWalletStatusCommand(request);
            var result = await mediator.Send(createWalletStatusCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates Wallet Status.
        /// </summary>
        /// <param name="walletStatusId">The Wallet Status identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{walletStatusId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateWalletStatus(int walletStatusId, [FromBody] UpdateWalletStatusRequest request)
        {
            var updateWalletStatusCommand = new UpdateWalletStatusCommand(walletStatusId, request);
            var result = await mediator.Send(updateWalletStatusCommand);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Wallet Status.
        /// </summary>
        /// <param name="walletStatusId">The Wallet Status identifier.</param>
        /// <returns></returns>
        [Route("{walletStatusId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteWalletStatus(int walletStatusId)
        {
            var deleteWalletStatusCommand = new DeleteWalletStatusCommand(walletStatusId);
            var result = await mediator.Send(deleteWalletStatusCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}
