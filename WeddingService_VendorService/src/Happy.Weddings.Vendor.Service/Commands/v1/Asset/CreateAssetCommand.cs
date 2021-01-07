#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | CreateAssetCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Requests.Asset;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Asset
{

    /// <summary>
    /// Command for creating a Asset
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class CreateAssetCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        public AddAssetRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAssetCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateAssetCommand(AddAssetRequest request)
        {
            Request = request;
        }
    }
}
