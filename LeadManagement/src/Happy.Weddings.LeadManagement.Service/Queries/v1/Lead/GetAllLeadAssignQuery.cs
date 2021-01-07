#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetAllLeadAssignQuery class.
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
    /// Query for getting lead Assign.
    /// </summary>
    public class GetAllLeadAssignQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead Assign parameters.
        /// </summary>
        /// <value>
        /// The lead Assign parameters.
        /// </value>
        public LeadAssignParameter LeadAssignParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLeadAssignQuery"/> class.
        /// </summary>
        /// <param name="leadAssignParameter">The lead Assign parameters.</param>
        public GetAllLeadAssignQuery(LeadAssignParameter leadAssignParameter)
        {
            LeadAssignParameter = leadAssignParameter;
        }
    }
}
