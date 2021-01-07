#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | ARAVIND PERUMAL S  | Created and implemented.
//             |                    | BenefitsResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.Offers;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.OffersProfile
{
    public class OffersResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OffersResponseProfile"/> class.
        /// </summary>
        public OffersResponseProfile()
        {
            CreateMap<Offers, OffersResponse>();
        }
    }
}
