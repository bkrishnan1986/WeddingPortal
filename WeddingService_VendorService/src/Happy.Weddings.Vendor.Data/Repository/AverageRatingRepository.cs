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
using Happy.Weddings.Vendor.Core.DTO.Responses.Review;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static Happy.Weddings.Vendor.Core.Entity.Review;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// This class is used to implement CRUD for the Review
    /// </summary>
    public class AverageRatingRepository : RepositoryBase<Ratings>, IAverageRatingRepository
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
        public AverageRatingRepository(
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
        /// Gets all CommentReplies.
        /// </summary>
        /// <param name="averageRatingParameter">The Comment Reply parameters.</param>
        /// <returns></returns>
        public async Task<Ratings> GetAverageRating(Review review)
        {
            {

                {
                    var getAverageRatingParams = new object[] {
               new MySqlParameter("@p_ReviewTypeId", review.ReviewType),
                new MySqlParameter("@p_ReferenceId", review.ReferenceId),
                 new MySqlParameter("@p_ApprovalStatusId", review.ApprovalStatus)
                };
                    var AverageRating = await FindAll("CALL SpSelectActiveAverageRating(@p_ReviewTypeId, @p_ReferenceId, @p_ApprovalStatusId)", getAverageRatingParams).ToListAsync();                         
                    return AverageRating.FirstOrDefault();

                }


            }
        }
    }
}

//public async Task<PagedList<Entity>> GetAverageRatings(AverageRatingParameter averageRatingParameter)
//{
//    {
//        {
//            var getAverageRatingsParams = new object[] {
//        new MySqlParameter("@p_ReviewTypeId", averageRatingParameter.ReviewTypeID),
//        new MySqlParameter("@p_ReferenceId",averageRatingParameter.ReferenceId),
//        new MySqlParameter("@p_ApprovalStatusId", averageRatingParameter.AprovalStatus)
//    };
//            var Benefits = await FindAll("CALL SpSelectActiveBenefit(@p_Limit, @p_Offset, @p_SearchKeyword, @p_Value, @p_FromDate,@p_ToDate)", getAverageRatingsParams).ToListAsync();
//            var mappedBenefits = Benefits.AsQueryable().ProjectTo<ReviewDataResponse>(mapper.ConfigurationProvider);
//            var sortedBenefits = sortHelper.ApplySort(mappedBenefits, averageRatingParameter.OrderBy);
//            var shapedBenefits = dataShaper.ShapeData(sortedBenefits, averageRatingParameter.Fields);

//            return await PagedList<Entity>.ToPagedList(shapedBenefits, averageRatingParameter.PageNumber, averageRatingParameter.PageSize);

//        }


//    }
//}
