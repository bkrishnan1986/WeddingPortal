#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ISubscriptionBenefitRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionBenefits;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
/// <summary>
/// This class is used to implement CRUD for the Subscription benefit
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IsubscriptionBenefitRepository : IRepositoryBase<Subscriptionbenefit>
    {
        /// <summary>
        /// Gets all Subscription Benefits.
        /// </summary>
        /// <param name="subscriptionBenefitsParameter">The SubscriptionBenefits parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllSubscriptionBenefits(SubscriptionBenefitsParameter subscriptionBenefitsParameter);

        Task<List<SubscriptionBenefitsResponse>> GetAllSubscriptionBenefitsBySubsId(SubscriptionBenefitsParameter subscriptionBenefitsParameter);

        /// <summary>
        /// Gets the Subscription Benefits by identifier.
        /// </summary>
        /// <param name="subscriptionBenefitId">The SubscriptionBenefits identifier.</param>
        /// <returns></returns>
        Task<Subscriptionbenefit> GetSubscriptionBenefitById(int subscriptionBenefitId);
        Task<List<SubscriptionBenefitsResponse>> GetSubscriptionBenefitsById(int SubscriptionBenefitId);

        /// <summary>
        /// Creates the subscription Benefits.
        /// </summary>
        /// <param name="subscriptionBenefits">The Subscription Benefits ..</param>
        void CreateSubscriptionBenefit(Subscriptionbenefit subscriptionBenefits);

        /// <summary>
        /// Updates the subscription Benefits.
        /// </summary>
        /// <param name="subscriptionBenefits">The Subscription Benefits ..</param>
        void UpdateSubscriptionBenefit(Subscriptionbenefit subscriptionbenefit);
    }
}
