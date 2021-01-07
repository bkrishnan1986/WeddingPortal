#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionOffersRepository --class
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
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionLocation;
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionLocation;
using System.Collections.Generic;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// SubscriptionLocationRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Subscriptionoffer}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.ISubscriptionOfferRepository" />
    public class SubscriptionLocationRepository : RepositoryBase<Subscriptionlocation>, ISubscriptionLocationRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<SubscriptionLocationResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<SubscriptionLocationResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public SubscriptionLocationRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<SubscriptionLocationResponse> sortHelper,
            IDataShaper<SubscriptionLocationResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all Subscriptionlocation.
        /// </summary>
        /// <param name="subscriptionLocationsParameter">The Subscriptionlocation parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllSubscriptionLocations(SubscriptionLocationsParameter subscriptionLocationsParameter)
        {
            
                var getsubscriptionLocationsParams = new object[] {
                       new MySqlParameter("@p_IsForSingleSubscriptionLocation", subscriptionLocationsParameter.IsForSingleSubscriptionLocation),     
                       new MySqlParameter("@p_IsForSubscription", subscriptionLocationsParameter.IsForSubscription),
                       new MySqlParameter("@p_IsForLocation", subscriptionLocationsParameter.IsForLocation),
                       new MySqlParameter("@p_IsForCategory", subscriptionLocationsParameter.IsForCategory),
                       new MySqlParameter("@p_CategoryValue", subscriptionLocationsParameter.CategoryValue),
                       new MySqlParameter("@p_LocationValue",subscriptionLocationsParameter.LocationValue),
                       new MySqlParameter("@p_Value", subscriptionLocationsParameter.Value),
            };
                var subscriptionLocations = await FindAll("CALL SpSelectActiveSubscriptionPlans(@p_IsForSingleSubscriptionLocation, @p_IsForSubscription, @p_IsForLocation, " +
                    "@p_IsForCategory, @p_Value, @p_CategoryValue, @p_Value)", getsubscriptionLocationsParams).ToListAsync();
                var mappedSubscriptionLocations = subscriptionLocations.AsQueryable().ProjectTo<SubscriptionLocationResponse>(mapper.ConfigurationProvider);
                var sortedSubscriptionLocations = sortHelper.ApplySort(mappedSubscriptionLocations, subscriptionLocationsParameter.OrderBy);
                var shapedSubscriptionLocations = dataShaper.ShapeData(sortedSubscriptionLocations, subscriptionLocationsParameter.Fields);

                return await PagedList<Entity>.ToPagedList(shapedSubscriptionLocations, subscriptionLocationsParameter.PageNumber, subscriptionLocationsParameter.PageSize);
        }     

        /// <summary>
        /// Gets the Subscriptionlocation by identifier.
        /// </summary>
        /// <param name="SubscriptionLocationId">The Subscriptionlocation identifier.</param>
        /// <returns></returns>
        public async Task<Subscriptionlocation> GetSubscriptionLocationById(int SubscriptionLocationId)
        {
            {
                var getsubscriptionLocationsParams = new object[]
                {
                       new MySqlParameter("@p_IsForSingleSubscriptionLocation", false),
                       new MySqlParameter("@p_IsForSubscription", false),
                       new MySqlParameter("@p_IsForLocation",true),
                       new MySqlParameter("@p_Value", SubscriptionLocationId),
                   };
                var subscriptionLocations = await FindAll("CALL SpSelectActiveSubscriptionLocation(@p_IsForSingleSubscriptionLocation, @p_IsForSubscription, @p_IsForLocation, @p_Value)", getsubscriptionLocationsParams).ToListAsync();
                return subscriptionLocations.FirstOrDefault();
            }
        }

        public async Task<Subscriptionlocation> GetSubscriptionLocationsById(LocationParameters locationParameters)
        {
            {
                var getsubscriptionLocationsParams = new object[]
                {
                       new MySqlParameter("@p_IsForSingleSubscriptionLocation", locationParameters.IsForSingleSubscriptionLocation),
                       new MySqlParameter("@p_IsForSubscription", locationParameters.IsForSubscription),
                       new MySqlParameter("@p_IsForLocation",locationParameters.IsForLocation),
                       new MySqlParameter("@p_Value", locationParameters.Value),
                   };
                var subscriptionLocations = await FindAll("CALL SpSelectActiveSubscriptionLocation(@p_IsForSingleSubscriptionLocation, @p_IsForSubscription, @p_IsForLocation, @p_Value)", getsubscriptionLocationsParams).ToListAsync();
                return subscriptionLocations.FirstOrDefault();
            }
        }

        public async Task<List<SubscriptionLocationResponse>> GetSubscriptions(int subscriptionId)
        {
            var result = await FindByCondition(sl => sl.SubscriptionId.Equals(subscriptionId))
                       .ProjectTo<SubscriptionLocationResponse>(mapper.ConfigurationProvider)
                       .ToListAsync();
            return result;
        }

        /// <summary>
        /// Creates the Subscriptionlocation.
        /// </summary>
        /// <param name="subscriptionlocation">The Subscriptionlocation.</param>
        public void CreateSubscriptionLocation(Subscriptionlocation subscriptionlocation)
        {
            Create(subscriptionlocation);
        }

        /// <summary>
        /// Updates the Subscriptionlocation.
        /// </summary>
        /// <param name="subscriptionlocation">The Subscriptionlocation.</param>
        public void UpdateSubscriptionLocation(Subscriptionlocation subscriptionlocation)
        {

            Update(subscriptionlocation);
        }
    }
}

