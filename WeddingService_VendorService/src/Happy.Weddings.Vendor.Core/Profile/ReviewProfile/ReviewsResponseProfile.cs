#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 11-Aug-2020 | ARAVIND PERUMAL S  | Created and implemented.
//             |                    | ReviewsResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.Review;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.ReviewProfile
{
    public class ReviewsResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OffersResponseProfile"/> class.
        /// </summary>
        public ReviewsResponseProfile()
        {
            CreateMap<Review, ReviewDataResponse>();
            CreateMap<Review, ReviewsResponse>();
        }
    }
}
