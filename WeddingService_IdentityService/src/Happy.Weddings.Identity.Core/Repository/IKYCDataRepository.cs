#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | IKYCDataRepository interface.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail;
using Happy.Weddings.Identity.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.Identity.Core.Repository
{
    /// <summary>
    /// Repository interface for KYC operations.
    /// </summary>
    public interface IKYCDataRepository : IRepositoryBase<Kycdata>
    {
        /// <summary>
        /// Creates the kyc detail.
        /// </summary>
        /// <param name="kycData">The kyc data.</param>
        void CreateKYCData(List<Kycdata> kycDatas);

        /// <summary>
        /// Updates the kyc detail.
        /// </summary>
        /// <param name="kycData">The kyc data.</param>
        void UpdateKYCDetail(IEnumerable<Kycdata> kycData);

        /// <summary>
        /// Updates the kyc data.
        /// </summary>
        /// <param name="kycData">The kyc data.</param>
        void UpdateKYCData(Kycdata kycData);

        /// <summary>
        /// Gets the kyc data by profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<KYCDetailResponse>> GetKYCDetailsByProfileId(int profileId);

        /// <summary>
        /// Gets the kyc data by profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<Kycdata>> GetKYCDataByProfileId(int profileId);
    }
}
