#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
//                         | GetServicesOfferedByServiceIdQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.ServicesOffered
{
   public class GetServicesOfferedByServiceIdQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        /// <value>
        /// The service identifier.
        /// </value>
        public int ServiceId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetServicesOfferedByServiceIdQuery"/> class.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        public GetServicesOfferedByServiceIdQuery(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
