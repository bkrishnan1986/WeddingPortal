#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  23-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ServiceSubscriptionsRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.DTO.Responses.Utility;
using Happy.Weddings.Vendor.Core.DTO.Requests.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// VendorSubscriptionsRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Vendorsubscription}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.ITopUpRepository" />
    public class UtilityRepository : RepositoryBase<Vendorserviceutilisation>, IUtilityRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<UtilityResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<UtilityResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public UtilityRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<UtilityResponse> sortHelper,
            IDataShaper<UtilityResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all utility.
        /// </summary>
        /// <param name="subscriptionUtilityParameters">The subscription utility parameters.</param>
        /// <returns></returns>
        public async Task<List<Vendorserviceutilisation>> GetAllUtility(SubscriptionUtilityParameters subscriptionUtilityParameters)
        {
            var utility = FindByCondition(utility => utility.VendorId.Equals(subscriptionUtilityParameters.VendorId)
                          && utility.Active == Convert.ToInt16(true))
                          .Include(x => x.ServiceSubscription.SubscriptionNavigation)
                          .Include(x => x.ServiceTopup.TopUp)
                          .Where(o => o.Benefit == subscriptionUtilityParameters.BenefitId &&
                                      o.ServiceSubscriptionId == subscriptionUtilityParameters.ServiceSubscriptionId &&
                                      o.ServiceTopupId == subscriptionUtilityParameters.TopupId).ToList();

            return utility;

        }

        /// <summary>
        /// Gets the utility by identifier.
        /// </summary>
        /// <param name="ServiceSubscriptionId">The service subscription identifier.</param>
        /// <returns></returns>
        public async Task<Vendorserviceutilisation> GetUtilityById(int UtilityId)
        {
            return await FindByCondition(leadAssign => leadAssign.Id.Equals(UtilityId)).FirstOrDefaultAsync();

        }

        /// <summary>
        /// Creates the utility.
        /// </summary>
        /// <param name="vendorserviceutilisation">The vendorserviceutilisation.</param>
        public void CreateUtility(Vendorserviceutilisation vendorserviceutilisation)
        {
            Create(vendorserviceutilisation);
        }

        /// <summary>
        /// Updates the utility.
        /// </summary>
        /// <param name="vendorserviceutilisation">The vendorserviceutilisation.</param>
        public void UpdateUtility(Vendorserviceutilisation vendorserviceutilisation)
        {

            Update(vendorserviceutilisation);
        }

    }
}

