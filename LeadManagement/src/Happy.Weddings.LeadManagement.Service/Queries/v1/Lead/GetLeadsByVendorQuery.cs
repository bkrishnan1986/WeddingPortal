#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  16-Nov-2020 |    Nikhil K Das       | Created and implemented. 
//              |                   | GetLeadsByVendorQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.Lead
{
    /// <summary>
    /// Query for getting leads By Vendor.
    /// </summary>
    public class GetLeadsByVendorQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead By Vendor parameters.
        /// </summary>
        /// <value>
        /// The lead By Vendor parameters.
        /// </value>
        public LeadsByVendorParameters LeadsByVendorParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLeadsByVendorQuery"/> class.
        /// </summary>
        /// <param name="leadsByVendorParameters">The lead By Vendor parameters.</param>
        public GetLeadsByVendorQuery(LeadsByVendorParameters leadsByVendorParameters)
        {
            LeadsByVendorParameters = leadsByVendorParameters;
        }
    }
}
