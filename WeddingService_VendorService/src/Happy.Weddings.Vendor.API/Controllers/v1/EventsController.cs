#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 05-Aug-2020 | Reji Salooja B S | Created and implemented.
// | | EventsController controller.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Event;
using Happy.Weddings.Vendor.Service.Commands.v1.Event;
using Happy.Weddings.Vendor.Service.Queries.v1.Event;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.API.Controllers.v1
{
    /// <summary>
    /// Vendors Event operations handled by this controller
    /// </summary>
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        /// <summary>
        /// The mediator
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController" /> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        public EventsController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Gets the Events by condition.
        /// </summary>
        /// <param name="eventParameters">The event parameters.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetEventsByCondition([FromQuery] EventParameters eventParameters)
        {
            var getAllEventsQuery = new GetEventsByConditionQuery(eventParameters);
            var result = await mediator.Send(getAllEventsQuery);

            if (result.Code == HttpStatusCode.OK)
            {
                Response.Headers.Add("X-Pagination", PagedList<Entity>.ToJson(result.Value as PagedList<Entity>));
            }

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
            var getEventDetailsQuery = new GetEventDetailsQueryByVendorId(eventVendorParameters);
            var result = await mediator.Send(getEventDetailsQuery);
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
            var getEventQuery = new GetEventQuery(eventId);
            var result = await mediator.Send(getEventQuery);
            return StatusCode((int)result.Code, result.Value);
        }

        /// <summary>
        /// Creates the Event.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventRequest request)
        {
            var createEventCommand = new CreateEventCommand(request);
            var result = await mediator.Send(createEventCommand);
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
        public async Task<IActionResult> UpdateEvent(int eventId, [FromBody] UpdateEventRequest request)
        {
            var updateEventCommand = new UpdateEventCommand(eventId, request);
            var result = await mediator.Send(updateEventCommand);
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
            var deleteEventCommand = new DeleteEventCommand(eventId);
            var result = await mediator.Send(deleteEventCommand);
            return StatusCode((int)result.Code, result.Value);
        }
    }
}