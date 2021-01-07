#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateSubscriptionOffersProfile --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionOffers;
using Happy.Weddings.Vendor.Core.Entity;
using System;

namespace Happy.Weddings.Vendor.Core.Profile.SubscriptionOffersProfile
{
    public class UpdateSubscriptionOffersProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOffersProfile"/> class.
        /// </summary>
        public UpdateSubscriptionOffersProfile()
        {
            CreateMap<UpdateSubscriptionOfferRequest, Subscriptionoffer>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }

}
