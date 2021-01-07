#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | DeleteAssetCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Asset
{

    /// <summary>
    /// Command for deleting a asset
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class DeleteAssetCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service identifier.
        /// </summary>
        public int AssetId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAssetCommand"/> class.
        /// </summary>
        /// <param name="assetId">The service identifier.</param>
        public DeleteAssetCommand(int assetId)
        {
            AssetId = assetId;
        }
    }
}
