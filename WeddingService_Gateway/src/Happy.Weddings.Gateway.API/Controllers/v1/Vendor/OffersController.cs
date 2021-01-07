using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Offers;
using Happy.Weddings.Gateway.Core.DTO.Vendor.SubscriptionOffers;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
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
        /// The offer service
        /// </summary>
        private readonly IOfferService offerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OffersController"/> class.
        /// </summary>
        /// <param name="offerService">The offer service.</param>
        public OffersController(
            IOfferService offerService)
        {
            this.offerService = offerService;
        }

        /// <summary>
        /// Gets the  Offers
        /// </summary>
        /// <param name="offersParameters">The  Offers Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOffers([FromQuery] OffersParameter offersParameters)
        {
            var result = await offerService.GetOffers(offersParameters);
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
            var result = await offerService.GetOffer(offerId);
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
            var result = await offerService.CreateOffer(request);
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
            var result = await offerService.UpdateOffer(offerId,request);
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
            var result = await offerService.DeleteOffer(offerId);
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
            var result = await offerService.GetSubcriptionOffers(subscriptionOffersParameters);
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
            var result = await offerService.GetSubcriptionOffer(subscriptionOffersId);
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
            var result = await offerService.CreateSubcriptionOffers(request);
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
            var result = await offerService.UpdateSubcriptionOffers(subscriptionOffersId,request);
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
            var result = await offerService.DeleteSubcriptionOffers(subscriptionOffersId);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
