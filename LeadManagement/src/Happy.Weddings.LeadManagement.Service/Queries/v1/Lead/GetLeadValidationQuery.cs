#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  10-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetLeadValidationQuery class.
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
    /// Query for getting lead Validation.
    /// </summary>
    public class GetLeadValidationQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead Validation identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLeadValidationQuery"/> class.
        /// </summary>
        /// <param name="leadValidationId">The lead Validation identifier.</param>
        public GetLeadValidationQuery(int leadValidationId)
        {
            Id = leadValidationId;
        }
    }
}
