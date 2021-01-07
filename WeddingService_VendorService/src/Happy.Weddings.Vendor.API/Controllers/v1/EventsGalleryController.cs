#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 10-Aug-2020 | Reji Salooja B S | Created and implemented.
//                                | EventsGalleryController controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.EventGallery;
using Happy.Weddings.Vendor.Service.Queries.v1.EventGallery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Vendors Event Gallery operations handled by this controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("eventsgallery")]
    [ApiController]
    public class EventsGalleryController : ControllerBase
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;
        /// <summary>
        /// Initializes a new instance of the <see cref="EventsGalleryController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public EventsGalleryController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the events gallery by vendor identifier.
        /// </summary>
        /// <param name="eventGalleryParameters">The event gallery parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEventGalleryByVendorId([FromQuery] EventGalleryParameters eventGalleryParameters)
        {
            var getAllEventsQuery = new GetAllEventGalleryByVendorIdQuery(eventGalleryParameters);
            var result = await mediator.Send(getAllEventsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

            return StatusCode((int)result.Code, result.Value);
        }         
    }
}