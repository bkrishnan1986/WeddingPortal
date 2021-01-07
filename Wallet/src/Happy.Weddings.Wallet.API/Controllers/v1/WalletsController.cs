#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | WalletsController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Requests.Wallet;
using Happy.Weddings.Wallet.Service.Commands.v1.Wallet;
using Happy.Weddings.Wallet.Service.Queries.v1.Wallet;
using Happy.Weddings.Wallet.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.API.Controllers.v1
{
    /// <summary>
    /// Wallet operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("wallets")]
    [ApiController]
    public class WalletsController : Controller
    {
        #region Variables

        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        #endregion

        #region Constructor Overloading

        /// <summary>
        /// Initializes a new instance of the <see cref="WalletsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public WalletsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Wallet

        /// <summary>
        /// Gets the Wallet
        /// </summary>
        /// <param name="walletsParameter">The Wallets Parameter.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllWallets([FromQuery] WalletsParameter walletsParameter)
        {
            var getAllWalletsQuery = new GetAllWalletsQuery(walletsParameter);

            var result = await mediator.Send(getAllWalletsQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Wallet
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <returns></returns>
        [Route("{walletId}")]
        [HttpGet]
        public async Task<IActionResult> GetWalletDetails(int walletId)
        {
            var getWalletQuery = new GetWalletQuery(walletId);

            var result = await mediator.Send(getWalletQuery);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Wallet
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateWallet([FromBody] CreateWalletRequest request)
        {
            var createWalletCommand = new CreateWalletCommand(request);
            var result = await mediator.Send(createWalletCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates Wallet.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <param name="IsPaused">IsPaused Status.</param>
        /// <param name="IsReleased">IsReleased Status.</param>
        /// <param name="IsChurned">IsChurned Status.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{walletId}/{IsPaused}/{IsReleased}/{IsChurned}")]
        [HttpPut]
        public async Task<IActionResult> UpdateWallet(int walletId, bool IsPaused, bool IsReleased, bool IsChurned, [FromBody] UpdateWalletRequest request)
        {
            var updateWalletCommand = new UpdateWalletCommand(walletId, request, IsPaused, IsReleased, IsChurned);
            var result = await mediator.Send(updateWalletCommand);

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Wallet.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <returns></returns>
        [Route("{walletId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteWallet(int walletId)
        {
            var deleteWalletCommand = new DeleteWalletCommand(walletId);
            var result = await mediator.Send(deleteWalletCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        #endregion
    }
}