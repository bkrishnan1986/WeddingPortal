using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Assets
{
   
    /// <summary>
    /// Query for getting a Asset
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAssetQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Benefits identifier.
        /// </summary>
        public int AssetId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssetQuery"/> class.
        /// </summary>
        /// <param name="assetId">The Asset identifier.</param>
        public GetAssetQuery(int assetId)
        {
            AssetId = assetId;
        }
    }
}
