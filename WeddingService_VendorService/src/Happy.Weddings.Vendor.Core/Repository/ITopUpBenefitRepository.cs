#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ITopUpBenefitRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.TopUpBenefit;
using Happy.Weddings.Vendor.Core.DTO.Responses.TopUps;
using Happy.Weddings.Vendor.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// This class is used to implement CRUD for the VendorSubscription
/// </summary>

namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface ITopUpBenefitRepository : IRepositoryBase<Topupbenefit>
    {
        /// <summary>
        /// Gets all Topupbenefit
        /// </summary>
        /// <param name="topUpBenefitParameter">The Topupbenefit parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllTopUpBenefits(TopUpBenefitParameter topUpBenefitParameter);


        Task<List<TopUpBenefitResponse>> GetAllTopUpBenefitsByTopupId(TopUpBenefitParameter topUpBenefitParameter);

        /// <summary>
        /// Gets the Topupbenefitby identifier.
        /// </summary>
        /// <param name="topupbenefitId">The Topupbenefit identifier.</param>
        /// <returns></returns>
        Task<Topupbenefit> GetTopUpBenefitById(int topupbenefitId);    
        Task<List<TopUpBenefitResponse>> GetTopUpBenefitsById(int topupBenefitId);

        /// <summary>
        /// Creates the Topupbenefit
        /// </summary>
        /// <param name="topUpBenefit">The Topupbenefit.</param>
        void CreateTopUpBenefit(Topupbenefit topUpBenefit);

        /// <summary>
        /// Updates the Topupbenefit
        /// </summary>
        /// <param name="topUpBenefit">The Topupbenefit.</param>
        void UpdateTopUpBenefit(Topupbenefit topUpBenefit);
    }
}
