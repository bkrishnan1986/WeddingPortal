#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  21-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetAllSuggestionListsQuery --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.SuggestionList;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.SuggesstionList
{
    /// <summary>
    /// Query for getting SuggestionList
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllSuggestionListsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the SuggestionList parameters.
        /// </summary>
        public SuggestionListParameter SuggestionListParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSubscriptionplansQuery"/> class.
        /// </summary>
        /// <param name="suggestionListParameter">The SuggestionList parameters.</param>
        public GetAllSuggestionListsQuery(SuggestionListParameter suggestionListParameter)
        {
            SuggestionListParameter = suggestionListParameter;
        }
    }
}
