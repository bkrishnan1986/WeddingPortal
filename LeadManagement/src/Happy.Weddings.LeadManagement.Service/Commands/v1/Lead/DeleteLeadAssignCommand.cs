#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | DeleteLeadAssignCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Commands.v1.Lead
{
    /// <summary>
    /// Command for deleting a lead Assign.
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.LeadManagement.Core.DTO.Responses.APIResponse}" />
    public class DeleteLeadAssignCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the lead identifier.
        /// </summary>
        /// <value>
        /// The lead identifier.
        /// </value>
        public int LeadAssignId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLeadAssignCommand"/> class.
        /// </summary>
        /// <param name="leadAssignId">The lead Assign identifier.</param>
        public DeleteLeadAssignCommand(int leadAssignId)
        {
            LeadAssignId = leadAssignId;
        }
    }
}
