#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | BenefitRepository --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Happy.Weddings.Vendor.Core.DTO.Responses.Review;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Review;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;
using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;
using Happy.Weddings.Vendor.Core.DTO.Responses.CommentReply;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1.Crmf;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// This class is used to implement CRUD for the Review
    /// </summary>
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<ReviewsResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<ReviewsResponse> dataShaper;

       

        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewsRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public ReviewRepository(
            VendorContext repositoryContext,

        IMapper mapper,
            ISortHelper<ReviewsResponse> sortHelper,
            IDataShaper<ReviewsResponse> dataShaper)
            : base(repositoryContext)
        {
            this.mapper = mapper;
            this.sortHelper = sortHelper;
            this.dataShaper = dataShaper;
        }

        /// <summary>
        /// Gets all Reviews.
        /// </summary>
        /// <param name="BenefitsParameter">The Reviews parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllReviews(ReviewsParameter reviewsParameter)
        {
            {

                {
                    var getReviewsParams = new object[] {
                new MySqlParameter("@p_ReviewTypeId", reviewsParameter.ReviewTypeId),
                new MySqlParameter("@p_ReferenceId", reviewsParameter.ReferenceId),
                new MySqlParameter("@p_ApprovalStatusOrId", reviewsParameter.ApprovalStatusOrId),
                 new MySqlParameter("@p_IsForSingReview", reviewsParameter.IsForSingReview)
            };
                    var Reviews = await FindAll("CALL SpSelectActiveReview(@p_ReviewTypeId, @p_ReferenceId, @p_ApprovalStatusOrId,@p_IsForSingReview)", getReviewsParams).ToListAsync();
                    var mappedReviews = Reviews.AsQueryable().ProjectTo<ReviewsResponse>(mapper.ConfigurationProvider);
                    var sortedReviews = sortHelper.ApplySort(mappedReviews, reviewsParameter.OrderBy);
                    var shapedReviews = dataShaper.ShapeData(sortedReviews, reviewsParameter.Fields);
                    return await PagedList<Entity>.ToPagedList(shapedReviews, reviewsParameter.PageNumber, reviewsParameter.PageSize);

                }


            }
        }

        //private int AverageReview()
        //{

        //}

        /// <summary>
        /// Gets all CommentReplies.
        /// </summary>
        /// <param name="averageRatingParameter">The Comment Reply parameters.</param>
        /// <returns></returns>
        //public async Task<PagedList<Entity>> GetAverageRating(ReviewsParameter reviewsParameter)
        //{
        //    {

        //        {
        //            var getAverageRatingParams = new object[] {
        //        new MySqlParameter("@p_ID", reviewsParameter.ReviewTypeId),
        //        new MySqlParameter("@p_ReferenceId", reviewsParameter.ReferenceId),
        //         new MySqlParameter("@p_AprovalStatus", reviewsParameter.ApprovalStatusId)
        //        };
        //            var CommentReply = await FindAll("CALL SpSelectActiveReview(@p_ID, @p_ReferenceId, @p_ApprovalStatus)", getAverageRatingParams).ToListAsync();
        //            //var CommentReply = await RepositoryContext.Query<Review>().FromSql("CALL SpSelectActiveAverageRating(@p_ID, @p_ReferenceId,@p_AprovalStatus)", getAverageRatingParams).ToListAsync();
        //            //var CommentReply = FromSql($"RetrieveEmployeeRecord {param1}, {param2}");
        //            var mappedCommentReply = CommentReply.AsQueryable().ProjectTo<ReviewsResponse>(mapper.ConfigurationProvider);
        //            var sortedCommentReply = sortHelper.ApplySort(mappedCommentReply, reviewsParameter.OrderBy);
        //            var shapedCommentReply = dataShaper.ShapeData(sortedCommentReply, reviewsParameter.Fields);

        //            return await PagedList<Entity>.ToPagedList(shapedCommentReply, reviewsParameter.PageNumber, reviewsParameter.PageSize);

        //        }


        //    }
        //}
        /// <summary>
        /// Gets the Reviews by identifier.
        /// </summary>
        /// <param name="reviewId">The Reviews identifier.</param>
        /// <returns></returns>
        public async Task<Review> GetReviewById(int reviewId)
        {
            var getReviewParams = new object[] {
                new MySqlParameter("@p_ReviewTypeId", false),
                new MySqlParameter("@p_ReferenceId", false),
                new MySqlParameter("@p_ApprovalStatusOrId",reviewId ),
                new MySqlParameter("@p_IsForSingReview", true)
                };

            var Reviews = await FindAll("CALL SpSelectActiveReview(@p_ReviewTypeId, @p_ReferenceId, @p_ApprovalStatusOrId,@p_IsForSingReview)", getReviewParams).ToListAsync();
            return Reviews.FirstOrDefault();
        }

        /// <summary>
        /// Creates the Review.
        /// </summary>
        /// <param name="reviews">The Benefits.</param>
        public void CreateReview(Review reviews)
        {

            Create(reviews);
        }

        /// <summary>
        /// Updates the Reviews.
        /// </summary>
        /// <param name="reviews">The Benefit.</param>
        public void UpdateReview(Review reviews)
        {

            Update(reviews);
        }

    }
}

