#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateFollowLeadCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Commands.v1.Lead
{
    /// <summary>
    /// Create follow lead command
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.LeadManagement.Core.DTO.Responses.APIResponse}" />
    public class CreateLeadValidationCommand: IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateLeadValidationRequest Request { get; set; }

        /// <summary>
        /// Gets or sets the lead identifier.
        /// </summary>
        /// <value>
        /// The lead identifier.
        /// </value>
        public int LeadId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLeadValidationCommand"/> class.
        /// </summary>
        /// <param name="leadId">The lead identifier.</param>
        /// <param name="request">The request.</param>
        public CreateLeadValidationCommand(int leadId, CreateLeadValidationRequest request)
        {
            Request = request;
            LeadId = leadId;
        }
    }
}
