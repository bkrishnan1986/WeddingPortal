#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  11-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateReviewProfile --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.Review;
using Happy.Weddings.Vendor.Core.Entity;
using System;


namespace Happy.Weddings.Vendor.Core.Profile.ReviewProfile
{
    public class UpdateReviewProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOffersProfile"/> class.
        /// </summary>
        public UpdateReviewProfile()
        {
            CreateMap<UpdateReviewRequest, Review>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }

}