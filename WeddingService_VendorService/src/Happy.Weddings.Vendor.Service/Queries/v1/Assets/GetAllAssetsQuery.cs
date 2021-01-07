#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  10-Aug-2020 |    Nithin M    | Created and implemented. 
//              |                         | GetAllAssetsQuery
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Asset;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.Assets
{

    /// <summary>
    /// Query for getting Assets
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}}" />
    public class GetAllAssetsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Asset parameters.
        /// </summary>
        public AssetParameters AssetParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllAssetsQuery"/> class.
        /// </summary>
        /// <param name="offersParameter">The Benefits parameters.</param>
        public GetAllAssetsQuery(AssetParameters assetParameter)
        {
            AssetParameter = assetParameter;
        }
    }
}
