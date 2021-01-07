#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateSuggestionListCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.SuggesstionList;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.SuggestionList
{
    /// <summary>
    /// Command for creating a SuggestionList
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class CreateSuggestionListCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateSuggestionListRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStoryCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateSuggestionListCommand(CreateSuggestionListRequest request)
        {
            Request = request;
        }
    }
}
