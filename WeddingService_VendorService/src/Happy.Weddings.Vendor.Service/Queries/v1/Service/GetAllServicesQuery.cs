#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | GetAllServicesQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Service;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Service
{
    /// <summary>
    /// Query for getting services
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}}" />
    public class GetAllServicesQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service parameters.
        /// </summary>
        public ServicesParameters servicesParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllServicesQuery"/> class.
        /// </summary>
        /// <param name="serviceParameters">The service parameters.</param>
        public GetAllServicesQuery(ServicesParameters servicesParameters)
        {
            this.servicesParameters = servicesParameters;
        }
    }
}
