#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionsController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionPlans;
using Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.DTO.Requests.Wallet;
using Happy.Weddings.Vendor.Service.Queries.v1.Wallet;
using Happy.Weddings.Vendor.Service.Commands.v1.Wallet;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Subscriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("wallets")]
    [ApiController]
    public class WalletsController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public WalletsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the Wallets
        /// </summary>
        /// <param name="walletsParameter">The subcription Plans Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetWaallets([FromQuery] WalletsParameter walletsParameter)
        {
            var getAllWalletsQuery = new GetAllWalletsQuery(walletsParameter);
            var result = await mediator.Send(getAllWalletsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Wallets
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <returns></returns>
        [Route("{walletId}")]
        [HttpGet]
        public async Task<IActionResult> GetWallet(int walletId)
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

        ///// <summary>
        ///// Update the Subcription Plan.
        ///// </summary>
        ///// <param name="subscriptionplanId">The subcriptionplan identifier.</param>
        ///// <param name="request">The request.</param>
        ///// <returns></returns>
        //[Route("{subscriptionplanId}")]
        //[HttpPut]
        //public async Task<IActionResult> UpdateWallet(int subscriptionplanId, [FromBody] UpdateSubscriptionPlanRequest request)
        //{
        //    var updateSubcriptionPlanCommand = new UpdateSubscriptionPlanCommand(subscriptionplanId, request);
        //    var result = await mediator.Send(updateSubcriptionPlanCommand);
        //    return StatusCode((int)result.Code, result.Value);
        //}

        ///// <summary>
        ///// Delete the Subcription Plan.
        ///// </summary>
        ///// <param name="subscriptionplanId">The subcriptionplan identifier.</param>
        ///// <returns></returns>
        //[Route("{subscriptionplanId}")]
        //[HttpDelete]
        //public async Task<IActionResult> DeleteWallet(int subscriptionplanId)
        //{
        //    var deleteSubcriptionPlanCommand = new DeleteSubscriptionPlanCommand(subscriptionplanId);
        //    var result = await mediator.Send(deleteSubcriptionPlanCommand);
        //    return StatusCode((int)result.Code, result.Value);
        //}

    }
}