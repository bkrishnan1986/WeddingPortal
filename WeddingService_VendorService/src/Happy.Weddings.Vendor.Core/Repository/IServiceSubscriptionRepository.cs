#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | IServiceSubscriptionRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceSubscription;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceSubscriptions;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// This class is used to implement CRUD for the ServiceSubscription
/// </summary>

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IServiceSubscriptionRepository : IRepositoryBase<Servicesubscription>
    {
        /// <summary>
        /// Gets all ServiceSubscriptions
        /// </summary>
        /// <param name="vendorSubscriptionsParameter">The Service Subscriptions parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllServiceSubscriptions(ServiceSubscriptionsParameter serviceSubscriptionsParameter);


        /// <summary>
        /// Gets the Service Subscriptions by identifier.
        /// </summary>
        /// <param name="vendorsubscriptionId">The Service Subscriptions identifier.</param>
        /// <returns></returns>
        Task<Servicesubscription> GetServiceSubscriptionById(int vendorSubscriptionId);


        /// <summary>
        /// Creates the ServiceSubscription
        /// </summary>
        /// <param name="vendorsubscription">The ServiceSubscription.</param>
        void CreateServicesubscription(List<Servicesubscription> servicesubscription);

        /// <summary>
        /// Updates the Service Subscription
        /// </summary>
        /// <param name="subscriptionBenefits">The Service Subscription</param>
        void UpdateServiceSubscription(Servicesubscription servicesubscription);
    }
}
