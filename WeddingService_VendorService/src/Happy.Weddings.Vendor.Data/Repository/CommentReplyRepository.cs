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
using Happy.Weddings.Vendor.Core.DTO.Responses.Benefits;
using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.Benefits;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Helpers;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;
using Happy.Weddings.Vendor.Core.DTO.Responses.CommentReply;
using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;

namespace Happy.Weddings.Vendor.Data.Repository
{
    /// <summary>
    /// This class is used to implement CRUD for the Benefits
    /// </summary>
    public class CommentReplyRepository : RepositoryBase<Commentreply>, ICommentReplyRepository
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
        /// Initializes a new instance of the <see cref="CommentReplyRepository" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="sortHelper">The sort helper.</param>
        /// <param name="dataShaper">The data shaper.</param>
        public CommentReplyRepository(
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
        /// <param name="BenefitsParameter">The Comment Reply parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllCommentReplies(CommentReplyParameter commentReplyParameter)
        {
            {

                {
                    var getCommentReplyParams = new object[] {
                new MySqlParameter("@p_Value", commentReplyParameter.value),
                new MySqlParameter("@p_AprovalStatus", commentReplyParameter.ApprovalStatus),
                new MySqlParameter("@p_IsForSingleCommentreply", commentReplyParameter.IsForSingleCommentreply),
                new MySqlParameter("@p_IsForComment", commentReplyParameter.IsForComment),
                new MySqlParameter("@p_IsForReply", commentReplyParameter.IsForReply),
                new MySqlParameter("@p_IsForCildReply", commentReplyParameter.IsForChildReply)
            };
                    var CommentReply = await FindAll("CALL SpSelectActiveCommentReply(@p_Value,@p_AprovalStatus,@p_IsForSingleCommentreply, @p_IsForComment, @p_IsForReply,@p_IsForCildReply)", getCommentReplyParams).ToListAsync();
                    var mappedCommentReply = CommentReply.AsQueryable().ProjectTo<CommentReplyResponse>(mapper.ConfigurationProvider);
                    var sortedCommentReply = sortHelper.ApplySort(mappedCommentReply, commentReplyParameter.OrderBy);
                    var shapedCommentReply = dataShaper.ShapeData(sortedCommentReply, commentReplyParameter.Fields);
                    return await PagedList<Entity>.ToPagedList(shapedCommentReply, commentReplyParameter.PageNumber, commentReplyParameter.PageSize);

                }


            }
        }
        /// <summary>
        /// Gets all CommentReplies.
        /// </summary>
        /// <param name="BenefitsParameter">The Comment Reply parameters.</param>
        /// <returns></returns>
        public async Task<PagedList<Entity>> GetAllComments(CommentParameter commentParameter)
        {
             {

                {
                    var getCommentReplyParams = new object[] {
                new MySqlParameter("@p_ReviewType", commentParameter.ReviewType),
                new MySqlParameter("@p_ReferenceId", commentParameter.ReferenceId),
                new MySqlParameter("@p_ApprovalStatus", commentParameter.ApprovalStatus)
                };
                    var CommentReply = await FindAll("CALL SpSelectActiveComments(@p_ReviewType, @p_ReferenceId,@p_ApprovalStatus)", getCommentReplyParams).ToListAsync();
                    var mappedCommentReply = CommentReply.AsQueryable().ProjectTo<CommentReplyResponse>(mapper.ConfigurationProvider);
                    var sortedCommentReply = sortHelper.ApplySort(mappedCommentReply, commentParameter.OrderBy);
                    var shapedCommentReply = dataShaper.ShapeData(sortedCommentReply, commentParameter.Fields);

                    return await PagedList<Entity>.ToPagedList(shapedCommentReply, commentParameter.PageNumber, commentParameter.PageSize);

                }


            }
        }

        /// <summary>
        /// Gets all CommentReplies.
        /// </summary>
        /// <param name="averageRatingParameter">The Comment Reply parameters.</param>
        /// <returns></returns>
        //public async Task<PagedList<Entity>> GetAverageRating(AverageRatingParameter averageRatingParameter)
        //{
        //    {

        //        {
        //            var getAverageRatingParams = new object[] {
        //        new MySqlParameter("@p_ID", averageRatingParameter.ID),
        //        new MySqlParameter("@p_ReferenceId", averageRatingParameter.ReferenceId),
        //         new MySqlParameter("@p_AprovalStatus", averageRatingParameter.AprovalStatus) 
        //        };
        //            var CommentReply = await FindAll("CALL SpSelectActiveAverageRating(@p_ID, @p_ReferenceId,@p_AprovalStatus)", getAverageRatingParams).ToListAsync();
        //            var mappedCommentReply = CommentReply.AsQueryable().ProjectTo<CommentReplyResponse>(mapper.ConfigurationProvider);
        //            var sortedCommentReply = sortHelper.ApplySort(mappedCommentReply, averageRatingParameter.OrderBy);
        //            var shapedCommentReply = dataShaper.ShapeData(sortedCommentReply, averageRatingParameter.Fields);

        //            return await PagedList<Entity>.ToPagedList(shapedCommentReply, averageRatingParameter.PageNumber, averageRatingParameter.PageSize);

        //        }


        //    }
        //}
        /// <summary>
        /// Gets the CommentReply by identifier.
        /// </summary>
        /// <param name="CommentReplyId">The CommentReply identifier.</param>
        /// <returns></returns>
        public async Task<Commentreply> GetCommentReplyById(int commentReplyId)
        {
            var getBenefitParams = new object[] {

                new MySqlParameter("@p_Value", commentReplyId),
                new MySqlParameter("@p_AprovalStatus",null),
              new MySqlParameter("@p_IsForSingleCommentreply", true),
                new MySqlParameter("@p_IsForComment", null),
                new MySqlParameter("@p_IsForReply", null),
                new MySqlParameter("@p_IsForCildReply", null)
                };

            var CommentReply = await FindAll("CALL SpSelectActiveCommentReply(@p_Value,@p_AprovalStatus,@p_IsForSingleCommentreply, @p_IsForComment, @p_IsForReply,@p_IsForCildReply)", getBenefitParams).ToListAsync();
            return CommentReply.FirstOrDefault();
        }

        /// <summary>
        /// Creates the CommentReply.
        /// </summary>
        /// <param name="commentreply">The CommentReply.</param>
        public void CreateCommentReply(Commentreply commentreply)
        {
            Create(commentreply);
        }

        /// <summary>
        /// Updates the commentreply.
        /// </summary>
        /// <param name="commentreply">The Benefit.</param>
        public void UpdateCommentReply(Commentreply commentreply)
        {

            Update(commentreply);
        }

    }
}

