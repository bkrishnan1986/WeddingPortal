#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ITopUpRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.TopUp;
using Happy.Weddings.Vendor.Core.DTO.Responses.TopUps;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// This class is used to implement CRUD for the Topup
/// </summary>

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface ITopUpRepository : IRepositoryBase<Topup>
    {
        /// <summary>
        /// Gets all Topup
        /// </summary>
        /// <param name="topUpParameter">The Topup parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllTopUps(TopUpParameter topUpParameter);

        /// <summary>
        /// Gets the Topup by identifier.
        /// </summary>
        /// <param name="topupId">The Topup identifier.</param>
        /// <returns></returns>
        Task<Topup> GetTopUpById(int topupId);
        Task<List<TopUpsResponse>> GetTopUpsById(int topupId);
        
        /// <summary>
        /// Creates the Topup
        /// </summary>
        /// <param name="topup">The Topup.</param>
        void CreateTopUp(Topup topup);

        /// <summary>
        /// Updates the Topup
        /// </summary>
        /// <param name="topup">The Topup.</param>
        void UpdateTopUp(Topup topup);
    }
}
