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
using Happy.Weddings.Vendor.Core.DTO.Requests.Utility;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// This class is used to implement CRUD for the ServiceSubscription
/// </summary>

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IUtilityRepository : IRepositoryBase<Vendorserviceutilisation>
    {
        /// <summary>
        /// Gets all utility.
        /// </summary>
        /// <param name="subscriptionUtilityParameters">The subscription utility parameters.</param>
        /// <returns></returns>
        Task<List<Vendorserviceutilisation>> GetAllUtility(SubscriptionUtilityParameters subscriptionUtilityParameters);


        /// <summary>
        /// Gets the utility by identifier.
        /// </summary>
        /// <param name="vendorSubscriptionId">The vendor subscription identifier.</param>
        /// <returns></returns>
        Task<Vendorserviceutilisation> GetUtilityById(int vendorSubscriptionId);


        /// <summary>
        /// Creates the utility.
        /// </summary>
        /// <param name="vendorserviceutilisation">The vendorserviceutilisation.</param>
        void CreateUtility(Vendorserviceutilisation vendorserviceutilisation);

        /// <summary>
        /// Updates the utility.
        /// </summary>
        /// <param name="vendorserviceutilisation">The vendorserviceutilisation.</param>
        void UpdateUtility(Vendorserviceutilisation vendorserviceutilisation);
    }
}
