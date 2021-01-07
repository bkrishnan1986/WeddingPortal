#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | DeleteLeadCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;
using System;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Commands.v1.Lead
{
    /// <summary>
    /// Command for deleting a lead.
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.LeadManagement.Core.DTO.Responses.APIResponse}" />
    public class DeleteLeadCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead identifier.
        /// </summary>
        /// <value>
        /// The lead identifier.
        /// </value>
        public int LeadId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLeadCommand"/> class.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        public DeleteLeadCommand(int leadId)
        {
            LeadId = leadId;
        }
    }
}
