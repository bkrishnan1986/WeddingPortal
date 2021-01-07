using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.LeadManagement.Service.Queries.v1.Lead
{
    public class GetLeadIdQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public LeadIdParameters Parameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLeadIdQuery"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public GetLeadIdQuery(LeadIdParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
