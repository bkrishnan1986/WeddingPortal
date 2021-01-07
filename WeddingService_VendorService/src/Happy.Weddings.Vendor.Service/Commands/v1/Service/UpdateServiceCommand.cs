#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | UpdateServiceCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Service;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Service
{
    public class UpdateServiceCommand : IRequest<APIResponse>
    {
        /// <summary>
     /// Gets or sets the service identifier.
     /// </summary>
     /// <value>
     /// The service identifier.
     /// </value>
        public int ServiceId { get; set; }

        ///// <summary>
        ///// Gets or sets the reuqest.
        ///// </summary>
        public UpdateServiceRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateServiceCommand" /> class.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateServiceCommand(int serviceId, UpdateServiceRequest request)
        {
            ServiceId = serviceId;
            Request = request;
        }
    }
}
