#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | DeleteServiceCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Service
{
    /// <summary>
    /// Command for deleting a service
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class DeleteServiceCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteServiceCommand"/> class.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        public DeleteServiceCommand(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}

