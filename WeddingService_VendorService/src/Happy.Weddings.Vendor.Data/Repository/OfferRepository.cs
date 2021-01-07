#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | OfferRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.DTO.Responses.Offers;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Offers;
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
    /// This class is used to implement CRUD for the Offer
    /// </summary>
    public class OfferRepository : RepositoryBase<Offers>, IOffersRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<OffersResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<OffersResponse> dataShaper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OffersRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public OfferRepository(
            VendorContext repositoryContext,
            IMapper mapper,
            ISortHelper<OffersResponse> sortHelper,
            IDataShaper<OffersResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all Offers.
        /// </summary>
        /// <param name="OfferParameter">The story parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllOffers(OffersParameter offerParameter)
        {
            {
                var getOffersParams = new object[] {
                new MySqlParameter("@p_IsForSingleOffer", offerParameter.IsForSingleOffer),
                new MySqlParameter("@p_IsForVendor", offerParameter.IsForVendor),
                new MySqlParameter("@p_Value", offerParameter.Value)

            };
                var offer = await FindAll("CALL SPSelectActiveOffer(@p_IsForSingleOffer, @p_IsForVendor, @p_Value)", getOffersParams).ToListAsync();
                var mappedOffers = offer.AsQueryable().ProjectTo<OffersResponse>(mapper.ConfigurationProvider);
                var sortedOffers = sortHelper.ApplySort(mappedOffers, offerParameter.OrderBy);
                var shapedOffers = dataShaper.ShapeData(sortedOffers, offerParameter.Fields);

                return await PagedList<Entity>.ToPagedList(shapedOffers, offerParameter.PageNumber, offerParameter.PageSize);

            }
        }
        /// <summary>
        /// Gets the Offers by identifier.
        /// </summary>
        /// <param name="OfferId">The Offer identifier.</param>
        /// <returns></returns>

        public async Task<Offers> GetOfferById(int offerId)

        {
            var getOfferParams = new object[] {
                new MySqlParameter("@p_IsForSingleOffer", true),
                new MySqlParameter("@p_IsForVendor", false),
                new MySqlParameter("@p_Value", offerId)
                };

            var Offer = await FindAll("CALL SPSelectActiveOffer(@p_IsForSingleOffer, @p_IsForVendor, @p_Value)", getOfferParams).ToListAsync();
            return Offer.FirstOrDefault();
        }

        /// <summary>
        /// Creates the Offers.
        /// </summary>
        /// <param name="story">The story.</param>
        public void CreateOffer(Offers offers)
        {
            Create(offers);
        }

        /// <summary>
        /// Updates the Offer.
        /// </summary>
        /// <param name="offers">The Offers.</param>
        public void UpdateOffer(Offers offers)
        {
            Update(offers);
        }

    }
}

