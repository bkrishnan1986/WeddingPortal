#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  07-DEC-2020 |    Aravind        | Created and implemented. 
//              |                   | GetLeadQuotesQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.Lead
{
    /// <summary>
    /// GetAllLeadStatusQuery
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.LeadManagement.Core.DTO.Responses.APIResponse}" />
    public class GetAllLeadStatusQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead status parameter.
        /// </summary>
        /// <value>
        /// The lead status parameter.
        /// </value>
        public LeadStatusParameter LeadStatusParameter { get; set; }
        public int LeadId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLeadStatusQuery"/> class.
        /// </summary>
        /// <param name="leadStatusParameter">The lead status parameter.</param>
        /// <param name="leadId">The lead identifier.</param>
        public GetAllLeadStatusQuery(LeadStatusParameter leadStatusParameter, int leadId = 0)
        {
            LeadStatusParameter = leadStatusParameter;
            LeadId = leadId;
        }
    }
}
