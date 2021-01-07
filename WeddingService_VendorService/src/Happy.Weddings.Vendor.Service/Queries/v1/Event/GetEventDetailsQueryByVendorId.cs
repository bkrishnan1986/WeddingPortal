#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetEventDetailsQueryByVendorId --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Event;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Event
{
    /// <summary>
    /// Query for getting events by vendor
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetEventDetailsQueryByVendorId : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the event parameters.
        /// </summary>
        public EventVendorParameters EventVendorParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetEventDetailsQueryByVendorId"/> class.
        /// </summary>
        /// <param name="eventParameters">The event parameters.</param>
        public GetEventDetailsQueryByVendorId(EventVendorParameters eventVendorParameters)
        {
            EventVendorParameters = eventVendorParameters;
        }
    }
}
