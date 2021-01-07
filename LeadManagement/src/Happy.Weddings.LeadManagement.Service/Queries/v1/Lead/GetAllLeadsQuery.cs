#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  11-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetAllLeadsQuerycs class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

#endregion

#endregion

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.Lead
{
    /// <summary>
    /// Query for getting leads.
    /// </summary>
    public class GetAllLeadsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead parameters.
        /// </summary>
        /// <value>
        /// The lead parameters.
        /// </value>
        public LeadParameters LeadParameters{ get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLeadsQuery"/> class.
        /// </summary>
        /// <param name="leadParameters">The lead parameters.</param>
        public GetAllLeadsQuery(LeadParameters leadParameters)
        {
            LeadParameters = leadParameters;
        }
    }
}
