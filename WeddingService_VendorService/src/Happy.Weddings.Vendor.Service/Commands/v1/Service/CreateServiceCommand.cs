#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | CreateServiceCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Requests.Service;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Service
{
    /// <summary>
 /// Command for creating a service
 /// </summary>
 /// <seealso cref="MediatR.IRequest{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class CreateServiceCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        public AddServicesRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServiceCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateServiceCommand(AddServicesRequest request)
        {
            Request = request;
        }
    }
}
