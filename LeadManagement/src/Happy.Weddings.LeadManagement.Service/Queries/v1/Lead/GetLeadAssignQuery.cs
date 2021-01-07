#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  10-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetLeadAssignQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.Lead
{
    /// <summary>
    /// Query for getting lead Assign.
    /// </summary>
    public class GetLeadAssignQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead Assign identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLeadAssignQuery"/> class.
        /// </summary>
        /// <param name="leadAssignId">The lead Assign identifier.</param>
        public GetLeadAssignQuery(int leadAssignId)
        {
            Id = leadAssignId;
        }
    }
}
