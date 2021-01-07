#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  22-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | IVendorSubscriptionRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceSubscription;
using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceTopup;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceTopup;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// This class is used to implement CRUD for the VendorSubscription
/// </summary>

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IServiceTopupRepository : IRepositoryBase<Servicetopup>
    {
        /// <summary>
        /// Gets all Servicetopup
        /// </summary>
        /// <param name="vendorSubscriptionsParameter">The Servicetopup parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllServiceTopups(ServiceTopupParameter serviceTopupParameter);    

        /// <summary>
        /// Gets the Servicetopup by identifier.
        /// </summary>
        /// <param name="servicetopupId">The Servicetopup identifier.</param>
        /// <returns></returns>
        Task<Servicetopup> GetServiceTopupById(int servicetopupId);
        Task<List<ServiceTopupResponse>> GetServiceTopups(int ServiceId);

        /// <summary>
        /// Creates the Servicetopup
        /// </summary>
        /// <param name="vendorsubscription">The vendor Subscriptions.</param>
        void CreateServiceTopup(List<Servicetopup> servicetopup);

        /// <summary>
        /// Updates the Servicetopup
        /// </summary>
        /// <param name="subscriptionBenefits">The Servicetopup.</param>
        void UpdateServiceTopup(Servicetopup servicetopup);
    }
}
