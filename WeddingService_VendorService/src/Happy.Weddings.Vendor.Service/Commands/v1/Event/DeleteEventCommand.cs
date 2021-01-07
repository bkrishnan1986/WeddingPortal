#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | DeleteEventCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Event
{
    /// <summary>
    /// Command for deleting a event
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    
    public class DeleteEventCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteEventCommand"/> class.
        /// </summary>
        /// <param name="eventId">The multicode identifier.</param>
        public DeleteEventCommand(int eventId)
        {
           Id = eventId;
        }
    }
}
