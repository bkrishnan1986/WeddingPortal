#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | IOffersRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Offers;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;
/// <summary>
/// This class is used to implement CRUD for the Offers Repository
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IOffersRepository : IRepositoryBase<Offers>
    {
        /// <summary>
        /// Gets all Offers.
        /// </summary>
        /// <param name="offersParameter">The Offers parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllOffers(OffersParameter offersParameter);

        /// <summary>
        /// Gets the Offer by identifier.
        /// </summary>
        /// <param name="offerId">The Offers identifier.</param>
        /// <returns></returns>
        Task<Offers> GetOfferById(int offerId);

        /// <summary>
        /// Creates the offers.
        /// </summary>
        /// <param name="offers">The offer.</param>
        void CreateOffer(Offers offers);

        /// <summary>
        /// Updates the offers.
        /// </summary>
        /// <param name="offers">The story.</param>
        void UpdateOffer(Offers offers);
    }
}
