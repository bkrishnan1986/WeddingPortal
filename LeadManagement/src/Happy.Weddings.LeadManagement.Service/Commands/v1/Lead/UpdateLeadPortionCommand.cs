#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateLeadPortionCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Commands.v1.Lead
{
    /// <summary>
    /// Command class for update lead portion.
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.LeadManagement.Core.DTO.Responses.APIResponse}" />
    public class UpdateLeadPortionCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the profile identifier.
        /// </summary>
        /// <value>
        /// The lead identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateLeadPortionRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLeadPortionCommand"/> class.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <param name="request">The request.</param>
        public UpdateLeadPortionCommand(int leadId, UpdateLeadPortionRequest request)
        {
            Request = request;
            Id = leadId;
        }
    }
}
