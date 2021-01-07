#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | OffersController Controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.DTO.Requests.Offers;
using Happy.Weddings.Vendor.Service.Queries.v1.Offers;
using Happy.Weddings.Vendor.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Vendor.Service.Commands.v1.Offers;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionOffers;
using Happy.Weddings.Vendor.Service.Queries.v1.SubscriptionOffers;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionOffers;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Offers operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("offers")]
    [ApiController]
    public class OffersController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="OffersController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public OffersController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the  Offers
        /// </summary>
        /// <param name="offersParameters">The  Offers Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOffers([FromQuery] OffersParameter offersParameters)
        {
            var getAllOffersQuery = new GetAllOffersQuery(offersParameters);
            var result = await mediator.Send(getAllOffersQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the  Offers.
        /// </summary>
        /// <param name="offerId">The Offer identifier.</param>
        /// <returns></returns>
        [Route("{offerId}")]
        [HttpGet]
        public async Task<IActionResult> GetOffer(int offerId)
        {
            var getOfferQuery = new GetOfferQuery(offerId);
            var result = await mediator.Send(getOfferQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Offers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOffer([FromBody] CreateOfferRequest request)
        {
            var createOfferCommand = new CreateOfferCommand(request);
            var result = await mediator.Send(createOfferCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Offers.
        /// </summary>
        /// <param name="offerId">The offer identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{offerId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateOffer(int offerId, [FromBody] UpdateOfferRequest request)
        {
            var updateOfferCommand = new UpdateOfferCommand(offerId, request);
            var result = await mediator.Send(updateOfferCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the Offer.
        /// </summary>
        /// <param name="offerId">The offer identifier.</param>
        /// <returns></returns>
        [Route("{offerId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOffer(int offerId)
        {
            var deleteOfferCommand = new DeleteOfferCommand(offerId);
            var result = await mediator.Send(deleteOfferCommand);
            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Gets the subcription offers.
        /// </summary>
        /// <param name="subscriptionOffersParameters">The subscription offers parameters.</param>
        /// <returns></returns>
        [Route("subscriptionoffers")]
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionOffers([FromQuery] SubscriptionOffersParameter subscriptionOffersParameters)
        {
            var getAllSubscriptionOffersQuery = new GetAllSubscriptionOffersQuery(subscriptionOffersParameters);
            var result = await mediator.Send(getAllSubscriptionOffersQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Get the Subcription Offers.
        /// </summary>
        /// <param name="subscriptionOffersId">The SubcriptionOffers identifier.</param>
        /// <returns></returns>
        [Route("{offerId}/subscriptionoffers/{subscriptionOffersId}")]
        [HttpGet]
        public async Task<IActionResult> GetSubcriptionOffer(int subscriptionOffersId)
        {
            var getSubcriptionOffersQuery = new GetSubscriptionOfferQuery(subscriptionOffersId);
            var result = await mediator.Send(getSubcriptionOffersQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Subcription Offers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{offerId}/subscriptionoffers/")]
        [HttpPost]
        public async Task<IActionResult> CreateSubcriptionOffers([FromBody] CreateSubscriptionOfferRequest request)
        {
            var createSubcriptionOffersCommand = new CreateSubscriptionOfferCommand(request);
            var result = await mediator.Send(createSubcriptionOffersCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the Subcription Offers.
        /// </summary>
        /// <param name="subscriptionOffersId">The subcriptionOffers identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{offerId}/subscriptionoffers/{subscriptionOffersId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSubcriptionOffers(int subscriptionOffersId, [FromBody] UpdateSubscriptionOfferRequest request)
        {
            var updateSubcriptionOffersCommand = new UpdateSubscriptionOfferCommand(subscriptionOffersId, request);
            var result = await mediator.Send(updateSubcriptionOffersCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the Subcription Offers.
        /// </summary>
        /// <param name="subscriptionOffersId">The subcriptionbenefit identifier.</param>
        /// <returns></returns>
        [Route("{offerId}/subscriptionoffers/{subscriptionOffersId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSubcriptionOffers(int subscriptionOffersId)
        {
            var deleteSubcriptionOffersCommand = new DeleteSubscriptionOfferCommand(subscriptionOffersId);
            var result = await mediator.Send(deleteSubcriptionOffersCommand);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}