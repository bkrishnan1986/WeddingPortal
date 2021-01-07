#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  28-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ISubscriptionLocationRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
/// <summary>
/// This class is used to implement CRUD for the Subscription location
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface ISubscriptionLocationRepository : IRepositoryBase<Subscriptionlocation>
    {
        /// <summary>
        /// Gets all Subscription Location.
        /// </summary>
        /// <param name="subscriptionLocationParameter">The SubscriptionLocation parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllSubscriptionLocations(SubscriptionLocationsParameter subscriptionLocationParameter);

        /// <summary>
        /// Gets the Subscription Location by identifier.
        /// </summary>
        /// <param name="subscriptionLocationId">The SubscriptionLocation identifier.</param>
        /// <returns></returns>
        Task<Subscriptionlocation> GetSubscriptionLocationById(int subscriptionLocationId);

        /// <summary>
        /// Gets the subscription locations by identifier.
        /// </summary>
        /// <param name="subscriptionLocationId">The subscription location identifier.</param>
        /// <returns></returns>
        Task<Subscriptionlocation> GetSubscriptionLocationsById(LocationParameters locationParameters);

        /// <summary>
        /// Gets the subscriptions.
        /// </summary>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <returns></returns>
        Task<List<SubscriptionLocationResponse>> GetSubscriptions(int subscriptionId);

        /// <summary>
        /// Creates the Subscription Location.
        /// </summary>
        /// <param name="subscriptionlocation">The SubscriptionLocation.</param>
        void CreateSubscriptionLocation(Subscriptionlocation subscriptionlocation);

        /// <summary>
        /// Updates the Subscription Location
        /// </summary>
        /// <param name="subscriptionlocation">The SubscriptionLocation.</param>
        void UpdateSubscriptionLocation(Subscriptionlocation subscriptionlocation);

    }
}
