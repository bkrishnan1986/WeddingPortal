#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetAllLeadValidationQuery class.
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
    /// Query for getting lead Validation.
    /// </summary>
    public class GetAllLeadValidationQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead Validation parameters.
        /// </summary>
        /// <value>
        /// The lead Validation parameters.
        /// </value>
        public LeadValidationParameter LeadValidationParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLeadValidationQuery"/> class.
        /// </summary>
        /// <param name="leadValidationParameter">The lead Validation parameters.</param>
        public GetAllLeadValidationQuery(LeadValidationParameter leadValidationParameter)
        {
            LeadValidationParameter = leadValidationParameter;
        }
    }
}
