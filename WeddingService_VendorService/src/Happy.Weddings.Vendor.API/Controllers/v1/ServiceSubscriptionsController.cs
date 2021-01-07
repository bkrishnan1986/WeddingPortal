#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | VendorSubscriptionsController-- Controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Net;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceSubscriptions;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceSubscription;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceSubscriptions;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Vendors Subcriptions operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("servicesubscriptions")]
    [ApiController]
    public class ServiceSubscriptionsController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceSubscriptionsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ServiceSubscriptionsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the Service Subcription 
        /// </summary>
        /// <param name="serviceSubscriptionsParameter">The Service subcription  Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetServiceSubscriptions([FromQuery] ServiceSubscriptionsParameter serviceSubscriptionsParameter)
        {
            var getAllserviceSubscriptionsQuery = new GetAllServiceSubscriptionsQuery(serviceSubscriptionsParameter);
            var result = await mediator.Send(getAllserviceSubscriptionsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Get the Service Subscription.
        /// </summary>
        /// <param name="serviceSubscriptionId">The Service Subscription identifier.</param>
        /// <returns></returns>
        [Route("{serviceSubscriptionId}")]
        [HttpGet]
        public async Task<IActionResult> GetServiceSubscriptionById(int serviceSubscriptionId)
        {
            var getServiceSubscriptionIdQuery = new GetServiceSubscriptionQuery(serviceSubscriptionId);
            var result = await mediator.Send(getServiceSubscriptionIdQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the Service Subscription
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateServiceSubscription([FromBody] CreateServiceSubscriptionRequest request)
        {
            var createserviceSubcriptionCommand = new CreateServiceSubscriptioncommand(request);
            var result = await mediator.Send(createserviceSubcriptionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the servicesubscription 
        /// </summary>
        /// <param name="servicesubscriptionId">The vendor subscription identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{servicesubscriptionId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateVendorSubscription(int servicesubscriptionId, [FromBody] UpdateServiceSubscriptionRequest request)
        {
            var updateServiceSubscriptionCommand = new UpdateServiceSubscriptionCommand(servicesubscriptionId, request);
            var result = await mediator.Send(updateServiceSubscriptionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the service subscription.
        /// </summary>
        /// <param name="servicesubscriptionId">The subcriptionbenefit identifier.</param>
        /// <returns></returns>
        [Route("{servicesubscriptionId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteServiceSubscription(int servicesubscriptionId)
        {
            var deleteServiceSubscriptionCommand = new DeleteServiceSubscriptionCommand(servicesubscriptionId);
            var result = await mediator.Send(deleteServiceSubscriptionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}