using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;
using Happy.Weddings.Vendor.Core.DTO.Responses.CommentReply;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Happy.Weddings.Vendor.Core.Entity.Commentreply;

namespace Happy.Weddings.Vendor.Data.Repository
{
    public class ReplyCountRepository : RepositoryBase<ReplyCount>, IReplyCountRepository
    {
        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The sort helper
        /// </summary>
        private ISortHelper<CommentReplyResponse> sortHelper;

        /// <summary>
        /// The data shaper
        /// </summary>
        private IDataShaper<CommentReplyResponse> dataShaper;



        /// <summary>
        /// Initializes a new instance of the <see cref="ReviewsRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public ReplyCountRepository(
            VendorContext repositoryContext,

        IMapper mapper,
            ISortHelper<CommentReplyResponse> sortHelper,
            IDataShaper<CommentReplyResponse> dataShaper)
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
        public async Task<ReplyCount> GetReplyCount(ReplyCountParameter replyCountParameter)
        {
            {

                {
                    var getAverageRatingParams = new object[] {
               new MySqlParameter("@p_Value", replyCountParameter.Value),
                new MySqlParameter("@p_IsForReply", replyCountParameter.IsForReply),
                 new MySqlParameter("@p_IsForCildReply", replyCountParameter.IsForChildReply)
                };
                    var AverageRating = await FindAll("CALL SpSelectActiveReplyCount(@p_Value, @p_IsForReply, @p_IsForCildReply)", getAverageRatingParams).ToListAsync();



                    return AverageRating.FirstOrDefault();

                }


            }
        }
    }
}
