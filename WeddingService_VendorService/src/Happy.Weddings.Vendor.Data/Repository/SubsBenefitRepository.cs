//#region File Header

//// Copyright (C) 2020 NIRA Systems (P) Ltd.
////
//// Release history:
////----------------------------------------------------------------------------------------------
////     Date     |      Author       |               Description
////----------------------------------------------------------------------------------------------
////  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
////              |                         | BenefitRepository --class
////----------------------------------------------------------------------------------------------

//#endregion File Header

//using AutoMapper;
//using Happy.Weddings.Vendor.Core.DTO.Responses.Review;
//using Happy.Weddings.Vendor.Core.Entity;
//using Happy.Weddings.Vendor.Core.Helpers;
//using Happy.Weddings.Vendor.Core.Repository;
//using Happy.Weddings.Vendor.Data.DatabaseContext;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;
//using MySql.Data.MySqlClient;
//using static Happy.Weddings.Vendor.Core.Entity.Review;
//using static Happy.Weddings.Vendor.Core.Entity.Subscriptionbenefit;
//using Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionBenefits;
//using Happy.Weddings.Vendor.Core.Domain;
//using Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionBenefits;
//using AutoMapper.QueryableExtensions;

//namespace Happy.Weddings.Vendor.Data.Repository
//{
//    /// <summary>
//    /// This class is used to implement CRUD for the Review
//    /// </summary>
//    public class SubsBenefitRepository : RepositoryBase<SubsBenefit>, ISubsBenefitRepository
//    {
//        /// <summary>
//        /// The mapper
//        /// </summary>
//        private IMapper mapper;

//        /// <summary>
//        /// The sort helper
//        /// </summary>
//        private ISortHelper<SubsBenefitDataResponse> sortHelper;

//        /// <summary>
//        /// The data shaper
//        /// </summary>
//        private IDataShaper<SubsBenefitDataResponse> dataShaper;



//        /// <summary>
//        /// Initializes a new instance of the <see cref="ReviewsRepository" /> class.
//        /// </summary>
//        /// <param name="repositoryContext">The repository context.</param>
//        /// <param name="mapper">The mapper.</param>
//        /// <param name="sortHelper">The sort helper.</param>
//        /// <param name="dataShaper">The data shaper.</param>
//        public SubsBenefitRepository(
//            VendorContext repositoryContext,

//        IMapper mapper,
//            ISortHelper<SubsBenefitDataResponse> sortHelper,
//            IDataShaper<SubsBenefitDataResponse> dataShaper)
//            : base(repositoryContext)
//        {
//            this.mapper = mapper;
//            this.sortHelper = sortHelper;
//            this.dataShaper = dataShaper;
//        }
//        /// <summary>
//        /// Gets all CommentReplies.
//        /// </summary>
//        /// <param name="averageRatingParameter">The Comment Reply parameters.</param>
//        /// <returns></returns>
//        public async Task<PagedList<Entity>> GetAllSubscriptionBenefits(SubscriptionBenefitsParameter subscriptionBenefitsParameter)
//        {
//            {
//                var getBenefitsParams = new object[] {
//                       new MySqlParameter("@p_IsForSingleData", subscriptionBenefitsParameter.IsForSingleData),
//                       new MySqlParameter("@p_IsForSubscription", subscriptionBenefitsParameter.IsForSubscription),
//                       new MySqlParameter("@p_IsForBenefit", subscriptionBenefitsParameter.IsForBenefit),
//                       new MySqlParameter("@p_Value", subscriptionBenefitsParameter.Value),
//                       new MySqlParameter("@p_ApprovalStatus", subscriptionBenefitsParameter.ApprovalStatus)
//            };
//                var subscriptionBenefits = await FindAll("CALL SpSelectActiveSubscriptionBenefit(@p_IsForSingleData, @p_IsForSubscription, @p_IsForBenefit, @p_Value, @p_ApprovalStatus)", getBenefitsParams).ToListAsync();
//                var mappedSubscriptionBenefits = subscriptionBenefits.AsQueryable().ProjectTo<SubsBenefitDataResponse>(mapper.ConfigurationProvider);
//                var sortedSubscriptionBenefits = sortHelper.ApplySort(mappedSubscriptionBenefits, subscriptionBenefitsParameter.OrderBy);
//                var shapedSubscriptionBenefits = dataShaper.ShapeData(sortedSubscriptionBenefits, subscriptionBenefitsParameter.Fields);

//                return await PagedList<Entity>.ToPagedList(shapedSubscriptionBenefits, subscriptionBenefitsParameter.PageNumber, subscriptionBenefitsParameter.PageSize);

//            }
//        }
//    }
//    }
