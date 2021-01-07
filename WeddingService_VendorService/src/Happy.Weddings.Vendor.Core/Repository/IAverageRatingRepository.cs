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

using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;
using static Happy.Weddings.Vendor.Core.Entity.Review;
/// <summary>
/// This class is used to implement CRUD for the Reviews Repository
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IAverageRatingRepository : IRepositoryBase<Ratings>
    {
        Task<Ratings> GetAverageRating(Review review);

       // Task<PagedList<Domain.Entity>> GetAverageRatings(AverageRatingParameter averageRatingParameter);
    }
}
