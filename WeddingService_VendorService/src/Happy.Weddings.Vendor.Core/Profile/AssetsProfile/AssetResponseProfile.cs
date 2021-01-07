#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 10-Aug-2020 | Nithin M  | Created and implemented.
// | | AssetResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header


using Happy.Weddings.Vendor.Core.DTO.Responses.Asset;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.AssetsProfile
{

    public class AssetResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssetResponseProfile"/> class.
        /// </summary>
        public AssetResponseProfile()
        {
            CreateMap<Assets, AssetResponse>();
        }
    }
}
