#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ISubscriptionPlansRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionPlans;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
/// <summary>
/// This class is used to implement CRUD for the Subscription Plans.
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface ISubscriptionPlansRepository : IRepositoryBase<Subscription>
    {
        /// <summary>
        /// Gets all Subscription Plans.
        /// </summary>
        /// <param name="subscriptionPlansParameter">The SubscriptionPlans parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllSubscriptionPlans(SubscriptionPlansParameter subscriptionPlansParameter);

        /// <summary>
        /// Gets the Subscription Plans by identifier.
        /// </summary>
        /// <param name="subscriptionId">The SubscriptionPlans identifier.</param>
        /// <returns></returns>
        Task<Subscription> GetSubscriptionPlanById(int subscriptionId);
        Task<List<SubscriptionPlansResponse>> GetSubscriptionPlans(int subscriptionId);

        /// <summary>
        /// Creates the subscription plans.
        /// </summary>
        /// <param name="subscriptionPlans">The subscriptionPlans.</param>
        void CreateSubscriptionPlan(Subscription subscriptionPlans);

        /// <summary>
        /// Updates the subscription plans.
        /// </summary>
        /// <param name="subscriptionPlans">The subscription plans.</param>
        void UpdateSubscriptionPlan(Subscription subscriptionPlans);
    }
}
