#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | DeleteLeadQuoteCommand class.
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
    /// Command for deleting a lead quote.
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.LeadManagement.Core.DTO.Responses.APIResponse}" />
    public class DeleteLeadQuoteCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the quote identifier.
        /// </summary>
        /// <value>
        /// The quote identifier.
        /// </value>
        public int QuoteId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLeadQuoteCommand"/> class.
        /// </summary>
        /// <param name="quoteId">The quote identifier.</param>
        public DeleteLeadQuoteCommand(int quoteId)
        {
            QuoteId = quoteId;
        }
    }
}
