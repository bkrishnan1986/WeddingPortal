using Happy.Weddings.Gateway.Core.DTO.Vendor.EventGallery;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
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
        /// The event gallery service
        /// </summary>
        private readonly IEventGalleryService eventGalleryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsGalleryController"/> class.
        /// </summary>
        /// <param name="eventGalleryService">The event gallery service.</param>
        public EventsGalleryController(
            IEventGalleryService eventGalleryService)
        {
            this.eventGalleryService = eventGalleryService;
        }

        /// <summary>
        /// Gets the events gallery by vendor identifier.
        /// </summary>
        /// <param name="eventGalleryParameters">The event gallery parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEventGalleryByVendorId([FromQuery] EventGalleryParameters eventGalleryParameters)
        {
            var result = await eventGalleryService.GetEventGalleryByVendorId(eventGalleryParameters);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
