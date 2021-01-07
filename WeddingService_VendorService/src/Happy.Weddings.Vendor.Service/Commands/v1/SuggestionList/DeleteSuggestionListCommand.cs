#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | DeleteSubscriptionPlanCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.SuggestionList
{
    /// <summary>
    /// Command for deleting a SuggestionList
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class DeleteSuggestionListCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SuggestionList identifier.
        /// </summary>
        public int SuggestionListId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriptionPlanCommand"/> class.
        /// </summary>
        /// <param name="storyId">The SuggestionList identifier.</param>
        public DeleteSuggestionListCommand(int suggestionListId)
        {
            SuggestionListId = suggestionListId;
        }
    }
}
