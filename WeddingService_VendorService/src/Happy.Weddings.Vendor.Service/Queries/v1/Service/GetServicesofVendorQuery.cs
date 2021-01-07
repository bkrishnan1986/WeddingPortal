#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | GetServicesofVendorQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Service
{

    /// <summary>
    /// Query for getting a services Of vendor
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}}" />
    public class GetServicesofVendorQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        public string VendorId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetServicesofVendorQuery"/> class.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        public GetServicesofVendorQuery(string vendorId)
        {
            VendorId = vendorId;
        }
    }
}
