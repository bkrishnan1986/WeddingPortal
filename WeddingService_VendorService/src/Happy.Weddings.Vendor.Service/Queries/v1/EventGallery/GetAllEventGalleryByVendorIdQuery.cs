#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  10-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetAllEventGalleryByVendorIdQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.EventGallery;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.EventGallery
{
    /// <summary>
    /// Query for getting event gallery by vendor
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class GetAllEventGalleryByVendorIdQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the event gallery parameters.
        /// </summary>
        /// <value>
        /// The event gallery parameters.
        /// </value>
        public EventGalleryParameters EventGalleryParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllEventGalleryByVendorIdQuery"/> class.
        /// </summary>
        /// <param name="eventGalleryParameters">The event gallery parameters.</param>
        public GetAllEventGalleryByVendorIdQuery(EventGalleryParameters eventGalleryParameters)
        {
            EventGalleryParameters = eventGalleryParameters;
        }
    }
}

