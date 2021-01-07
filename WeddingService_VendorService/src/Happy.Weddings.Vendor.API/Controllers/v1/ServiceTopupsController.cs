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
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceTopup;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceTopup;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceTopup;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// ServiceTopup operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("servicetopup")]
    [ApiController]
    public class ServiceTopupsController : Controller
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceSubscriptionsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public ServiceTopupsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the ServiceTopup
        /// </summary>
        /// <param name="serviceTopupParameter">The ServiceTopup  Parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetServiceTopups([FromQuery] ServiceTopupParameter serviceTopupParameter)
        {
            var getAllserviceSubscriptionsQuery = new GetAllServiceTopupQuery(serviceTopupParameter);
            var result = await mediator.Send(getAllserviceSubscriptionsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }
        /// <summary>
        /// Get the ServiceTopup
        /// </summary>
        /// <param name="servicetopupId">The ServiceTopupidentifier.</param>
        /// <returns></returns>
        [Route("{servicetopupId}")]
        [HttpGet]
        public async Task<IActionResult> GetServiceTopupById(int servicetopupId)
        {
            var getServiceSubscriptionIdQuery = new GetServiceTopupQuery(servicetopupId);
            var result = await mediator.Send(getServiceSubscriptionIdQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Create the ServiceTopup
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateServiceTopup([FromBody] CreateServiceTopupRequest request)
        {
            var createserviceSubcriptionCommand = new CreateServiceTopupCommand(request);
            var result = await mediator.Send(createserviceSubcriptionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Update the ServiceTopup
        /// </summary>
        /// <param name="servicesubscriptionId">The ServiceTopup identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{servicetopupId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateServiceTopup(int servicesubscriptionId, [FromBody] UpdateServiceTopupRequest request)
        {
            var updateServiceSubscriptionCommand = new UpdateServiceTopupCommand(servicesubscriptionId, request);
            var result = await mediator.Send(updateServiceSubscriptionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Delete the ServiceTopup
        /// </summary>
        /// <param name="servicetopupId">The ServiceTopup identifier.</param>
        /// <returns></returns>
        [Route("{servicetopupId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteServiceTopup(int servicetopupId)
        {
            var deleteServiceSubscriptionCommand = new DeleteServiceTopupCommand(servicetopupId);
            var result = await mediator.Send(deleteServiceSubscriptionCommand);
            return StatusCode((int)result.Code, result.Value);
        }

    }
}