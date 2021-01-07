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
using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionOffers;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionOffers;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// SubscriptionOffersRepository
    /// </summary>
    /// <seealso cref="Happy.Weddings.Vendor.Data.Repository.RepositoryBase{Happy.Weddings.Vendor.Core.Entity.Subscriptionoffer}" />
    /// <seealso cref="Happy.Weddings.Vendor.Core.Repository.ISubscriptionOfferRepository" />
    public class SubscriptionOffersRepository : RepositoryBase<Subscriptionoffer>, ISubscriptionOfferRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<SubscriptionOfferResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<SubscriptionOfferResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoriesRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public SubscriptionOffersRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<SubscriptionOfferResponse> sortHelper,
            IDataShaper<SubscriptionOfferResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all subscriptionOffer.
        /// </summary>
        /// <param name="subscriptionBenefitsParameter">The story parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllSubscriptionOffers(SubscriptionOffersParameter subscriptionOffersParameter)
        {
            {
                var getOffersParams = new object[] {
                       new MySqlParameter("@p_IsForSingleData", subscriptionOffersParameter.IsForSingleData),
                       new MySqlParameter("@p_IsForSubscription", subscriptionOffersParameter.IsForSubscription),
                       new MySqlParameter("@p_IsForOffer", subscriptionOffersParameter.IsForOffer),
                       new MySqlParameter("@p_Value", subscriptionOffersParameter.Value),
                       new MySqlParameter("@p_ApprovalStatus", subscriptionOffersParameter.ApprovalStatus)
            };
                var subscriptionOffers = await FindAll("CALL SpSelectActiveSubscriptionOffer(@p_IsForSingleData, @p_IsForSubscription, @p_IsForOffer, @p_Value, @p_ApprovalStatus)", getOffersParams).ToListAsync();            
                var mappedSubscriptionOffers = subscriptionOffers.AsQueryable().ProjectTo<SubscriptionOfferResponse>(mapper.ConfigurationProvider);
                var sortedSubscriptionOffers = sortHelper.ApplySort(mappedSubscriptionOffers, subscriptionOffersParameter.OrderBy);
                var shapedSubscriptionOffers = dataShaper.ShapeData(sortedSubscriptionOffers, subscriptionOffersParameter.Fields);

                return await PagedList<Entity>.ToPagedList(shapedSubscriptionOffers, subscriptionOffersParameter.PageNumber, subscriptionOffersParameter.PageSize);

            }
        }
        /// <summary>
        /// Gets the subscriptionOffer by identifier.
        /// </summary>
        /// <param name="SubscriptionBenefitId">The story identifier.</param>
        /// <returns></returns>
        public async Task<Subscriptionoffer> GetSubscriptionOfferById(int SubscriptionOfferId)
        {
            var getOfferParams = new object[] {

                       new MySqlParameter("@p_IsForSingleData", true),
                       new MySqlParameter("@p_IsForSubscription",false),
                       new MySqlParameter("@p_IsForOffer", false),
                       new MySqlParameter("@p_Value",SubscriptionOfferId),
                       new MySqlParameter("@p_ApprovalStatus", null)
                };

            var subscriptionOffer = await FindAll("CALL SpSelectActiveSubscriptionOffer(@p_IsForSingleData, @p_IsForSubscription, @p_IsForOffer, @p_Value, @p_ApprovalStatus)", getOfferParams).ToListAsync();
            return subscriptionOffer.FirstOrDefault();
        }





    /// <summary>
    /// Creates the subscriptionOffer.
    /// </summary>
    /// <param name="story">The story.</param>
    public void CreateSubscriptionOffer(Subscriptionoffer subscriptionoffer)
        {
            Create(subscriptionoffer);
        }

        /// <summary>
        /// Updates the subscriptionOffer.
        /// </summary>
        /// <param name="subscriptionPlans">The SubscriptionPlan.</param>
        public void UpdateSubscriptionOffer(Subscriptionoffer subscriptionoffer)
        {

            Update(subscriptionoffer);
        }
    }
}

