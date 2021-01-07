#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
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
    /// Query for getting lead quotes.
    /// </summary>
    public class GetAllLeadQuotesQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead quote parameters.
        /// </summary>
        /// <value>
        /// The lead quote parameters.
        /// </value>
        public LeadQuoteParameters LeadQuoteParameters { get; set; }
        public int LeadId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLeadQuotesQuery"/> class.
        /// </summary>
        /// <param name="leadParameters">The lead parameters.</param>
        public GetAllLeadQuotesQuery(LeadQuoteParameters leadParameters, int leadId = 0)
        {
            LeadQuoteParameters = leadParameters;
            LeadId = leadId;
        }
    }
}
