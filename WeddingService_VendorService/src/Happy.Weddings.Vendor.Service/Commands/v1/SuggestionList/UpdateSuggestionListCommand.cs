#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateSuggestionListCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header


using Happy.Weddings.Vendor.Core.DTO.Requests.SuggesstionList;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.SuggestionList
{
    /// <summary>
    /// Command for updating a SuggestionList
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateSuggestionListCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SuggestionList identifier.
        /// </summary>
        /// <value>
        /// The story identifier.
        /// </value>
        public int SuggestionListId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateSuggestionListRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriptionPlanCommand" /> class.
        /// </summary>
        /// <param name="suggestionListId">The SuggestionList identifier.</param>
        /// <param name="request">The request.</param>
        public UpdateSuggestionListCommand(int suggestionListId, UpdateSuggestionListRequest request)
        {
            SuggestionListId = suggestionListId;
            Request = request;
        }
    }
}
