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
using Happy.Weddings.Vendor.Core.DTO.Requests.Wallet;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;
/// <summary>
/// This class is used to implement CRUD for the Subscription Plans.
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IWalletRepository : IRepositoryBase<Wallet>
    {
        /// <summary>
        /// Gets all Wallet
        /// </summary>
        /// <param name="walletsParameter">The Wallet parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllWallets(WalletsParameter walletsParameter);

        /// <summary>
        /// Gets the Wallet  by identifier.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <returns></returns>
        Task<Wallet> GetWalletById(int walletId);

        Task<Wallet> GetWalletByVendorId(int walletId);

        /// <summary>
        /// Creates the wallet
        /// </summary>
        /// <param name="wallet">The subscriptionPlans.</param>
        void CreateWallet(Wallet wallet);

        /// <summary>
        /// Updates the subscription plans.
        /// </summary>
        /// <param name="subscriptionPlans">The subscription plans.</param>
       // void UpdateWallet(Wallet   wallet);
    }
}
