#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  10-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetLeadQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.Lead
{
    /// <summary>
    /// Query for getting a lead
    /// </summary>
    public class GetLeadQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLeadQuery"/> class.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        public GetLeadQuery(string leadId)
        {
            Id = leadId;
        }
    }
}
