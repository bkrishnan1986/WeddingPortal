#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | IReviewRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Review;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;
/// <summary>
/// This class is used to implement CRUD for the Reviews Repository
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        /// <summary>
        /// Gets all Reviews.
        /// </summary>
        /// <param name="offersParameter">The Reviews parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllReviews(ReviewsParameter reviewsParameter);

        //Task<PagedList<Domain.Entity>> GetAverageRating(ReviewsParameter reviewsParameter);

        /// <summary>
        /// Gets the Review by identifier.
        /// </summary>
        /// <param name="reviewId">The reviews identifier.</param>
        /// <returns></returns>
        Task<Review> GetReviewById(int reviewId);

        /// <summary>
        /// Creates the Review.
        /// </summary>
        /// <param name="reviews">The reviews.</param>
        void CreateReview(Review reviews);

        /// <summary>
        /// Updates the Review.
        /// </summary>
        /// <param name="reviews">The reviews.</param>
        void UpdateReview(Review reviews);
    }
}
