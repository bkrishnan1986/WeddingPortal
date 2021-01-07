#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ISubscriptionOfferRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionOffers;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;
/// <summary>
/// This class is used to implement CRUD for the Subscription offer
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface ISubscriptionOfferRepository : IRepositoryBase<Subscriptionoffer>
    {
        /// <summary>
        /// Gets all Subscription Offer.
        /// </summary>
        /// <param name="subscriptionOffersParameter">The SubscriptionOffer parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllSubscriptionOffers(SubscriptionOffersParameter subscriptionOffersParameter);

        /// <summary>
        /// Gets the Subscription Offer by identifier.
        /// </summary>
        /// <param name="subscriptionOfferId">The SubscriptionOffer identifier.</param>
        /// <returns></returns>
        Task<Subscriptionoffer> GetSubscriptionOfferById(int subscriptionOfferId);

        /// <summary>
        /// Creates the Subscription Offer.
        /// </summary>
        /// <param name="subscriptionBenefits">The SubscriptionOffer.</param>
        void CreateSubscriptionOffer(Subscriptionoffer subscriptionoffer);

        /// <summary>
        /// Updates the Subscription Offer
        /// </summary>
        /// <param name="subscriptionOffer">The SubscriptionOffer.</param>
        void UpdateSubscriptionOffer(Subscriptionoffer subscriptionOffer);

    }
}
