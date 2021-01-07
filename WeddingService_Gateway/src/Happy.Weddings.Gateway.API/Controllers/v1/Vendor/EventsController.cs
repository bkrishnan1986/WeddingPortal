using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Happy.Weddings.Gateway.Core.DTO.Vendor.Event;
using Happy.Weddings.Gateway.Core.Services.v1.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace Happy.Weddings.Gateway.API.Controllers.v1.Vendor
{
    /// <summary>
    /// Vendors Event operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    //[Consumes("application/json")]
    [Route("events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        /// <summary>
        /// The event service
        /// </summary>
        private readonly IEventService eventService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController"/> class.
        /// </summary>
        /// <param name="eventService">The event service.</param>
        public EventsController(
            IEventService eventService)
        {
            this.eventService = eventService;
        }

        /// <summary>
        /// Gets the Events by condition.
        /// </summary>
        /// <param name="eventParameters">The event parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEventsByCondition([FromQuery] EventParameters eventParameters)
        {
            var result = await eventService.GetEventsByCondition(eventParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the event details by vendor.
        /// </summary>
        /// <param name="eventVendorParameters"></param>
        /// <returns></returns>
        [Route("eventVendorParameters")]
        [HttpGet]
        public async Task<IActionResult> GetEventDetailsById([FromQuery] EventVendorParameters eventVendorParameters)
        {
            var result = await eventService.GetEventDetailsById(eventVendorParameters);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [Route("{eventId}")]
        [HttpGet]
        public async Task<IActionResult> GetEventById(int eventId)
        {
            var result = await eventService.GetEventById(eventId);
            return StatusCode((int)result.Code, result.Value); ;
        }

        /// <summary>
        /// Creates the Event.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromForm] CreateEventRequest request)
        {
            var result = await eventService.CreateEvent(request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Updates Event.
        /// </summary>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [Route("{eventId}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEvent(int eventId, [FromForm] UpdateEventRequest request)
        {
            var result = await eventService.UpdateEvent(eventId, request);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Deletes the Event.
        /// </summary>
        /// <param name="eventId">The Event identifier.</param>
        /// <returns></returns>
        [Route("{eventId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            var result = await eventService.DeleteEvent(eventId);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}
