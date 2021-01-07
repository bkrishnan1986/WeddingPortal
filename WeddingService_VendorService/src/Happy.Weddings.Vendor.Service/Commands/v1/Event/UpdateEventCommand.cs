#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | UpdateEventCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Event;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Event
{
    /// <summary>
    /// Command for updating a Event
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    
    public class UpdateEventCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateEventRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultiCodeCommand" /> class.
        /// </summary>
        /// <param name="eventId">The multicode identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateEventCommand(int eventId, UpdateEventRequest request)
        {
            Id = eventId;
            Request = request;
        }
    }
}
