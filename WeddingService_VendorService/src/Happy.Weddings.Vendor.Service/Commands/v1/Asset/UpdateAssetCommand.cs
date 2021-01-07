#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | UpdateAssetCommand class.
//----------------------------------------------------------------------------------------------

#endregion File Header
using Happy.Weddings.Vendor.Core.DTO.Requests.Asset;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.Asset
{

    public class UpdateAssetCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the asset identifier.
        /// </summary>
        /// <value>
        /// The asset identifier.
        /// </value>
        public int AssetId { get; set; }

        ///// <summary>
        ///// Gets or sets the reuqest.
        ///// </summary>
        public UpdateAssetRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAssetCommand" /> class.
        /// </summary>
        /// <param name="AssetId">The asset identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateAssetCommand(int assetId, UpdateAssetRequest request)
        {
            AssetId = assetId;
            Request = request;
        }
    }


}
