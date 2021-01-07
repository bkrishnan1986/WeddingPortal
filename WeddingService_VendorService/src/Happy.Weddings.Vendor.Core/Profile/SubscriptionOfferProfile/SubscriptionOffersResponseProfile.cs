#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date         | Author          | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | ARAVIND PERUMAL S  | Created and implemented.
//             |                    | SubscriptionOffersResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionOffers;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.SubscriptionOffersProfile
{
    public class SubscriptionOffersResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResponseProfile"/> class.
        /// </summary>
        public SubscriptionOffersResponseProfile()
        {
            CreateMap<Subscriptionoffer, SubscriptionOfferResponse>();
        }
    }
}