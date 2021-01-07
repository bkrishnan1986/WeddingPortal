#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | KYCDataRepository class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Identity.Core.Entity;
using Happy.Weddings.Identity.Core.Helpers;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Data.DatabaseContext;
using System.Collections.Generic;
using Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail;

#endregion

namespace Happy.Weddings.Identity.Data.Repository
{
    /// <summary>
    /// Repository class that performs KYC related operations.
    /// </summary>
    public class KYCDataRepository : RepositoryBase<Kycdata>, IKYCDataRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<KYCDataResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<KYCDataResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="KYCDataRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public KYCDataRepository(
            IdentityContext repositoryContext,
            IMapper mapper,
            ISortHelper<KYCDataResponse> sortHelper,
            IDataShaper<KYCDataResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Creates the kyc detail.
        /// </summary>
        /// <param name="kycDatas"></param>
        public void CreateKYCData(List<Kycdata> kycDatas)
        {
            CreateRange(kycDatas);
        }

        /// <summary>
        /// Gets the kyc data by profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<KYCDetailResponse>> GetKYCDetailsByProfileId(int profileId)
        {
            return await FindByCondition(kyc => kyc.VendorId.Equals(profileId))
                .Include(ac => ac.Kycdetails)
                .Include(gs => gs.Gstdetails)
                .ProjectTo<KYCDetailResponse>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        /// <summary>
        /// Gets the kyc data by profile identifier.
        /// </summary>
        /// <param name="profileId">The profile identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Kycdata>> GetKYCDataByProfileId(int profileId)
        {
            return await FindByCondition(kyc => kyc.VendorId.Equals(profileId))
                .Include(ac => ac.Kycdetails)
                .Include(gs => gs.Gstdetails)
                .ToListAsync();
        }

        /// <summary>
        /// Updates the kyc detail.
        /// </summary>
        /// <param name="kycData">The kyc data.</param>
        public void UpdateKYCDetail(IEnumerable<Kycdata> kycData)
        {
            UpdateRange(kycData);            
        }

        /// <summary>
        /// Updates the kyc data.
        /// </summary>
        /// <param name="kycData">The kyc data.</param>
        public void UpdateKYCData(Kycdata kycData)
        {
            Update(kycData);
        }
    }
}
