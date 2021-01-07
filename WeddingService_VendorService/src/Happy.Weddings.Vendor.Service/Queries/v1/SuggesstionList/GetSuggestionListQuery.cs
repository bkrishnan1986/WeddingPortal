#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetSuggestionListQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.SuggesstionList
{
    /// <summary>
    /// Query for getting a SuggesstionList
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetSuggestionListQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SuggesstionList identifier.
        /// </summary>
        public int SuggestionListId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionPlanQuery"/> class.
        /// </summary>
        /// <param name="suggestionListId">The SuggesstionList identifier.</param>
        public GetSuggestionListQuery(int suggestionListId)
        {
            SuggestionListId = suggestionListId;
        }
    }
}
