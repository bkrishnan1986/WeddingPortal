#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | ICommentReplyRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;
/// <summary>
/// This class is used to implement CRUD for the Benefits
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface ICommentReplyRepository : IRepositoryBase<Commentreply>
    {
        /// <summary>
        /// Gets all Commentreply.
        /// </summary>
        /// <param name="commentReplyParameter">The Commentreply parameters.</param>
        /// <returns></returns>
        Task<PagedList<Domain.Entity>> GetAllCommentReplies(CommentReplyParameter commentReplyParameter);

        Task<PagedList<Domain.Entity>> GetAllComments(CommentParameter commentParameter);

       // Task<PagedList<Domain.Entity>> GetAverageRating(AverageRatingParameter averageRatingParameter);

        /// <summary>
        /// Gets the Commentreply by identifier.
        /// </summary>
        /// <param name="commentReplyId">The commentReply identifier.</param>
        /// <returns></returns>
        Task<Commentreply> GetCommentReplyById(int commentReplyId);

        /// <summary>
        /// Creates the commentReply.
        /// </summary>
        /// <param name="commentReply">The Benefit.</param>
        void CreateCommentReply(Commentreply commentreply);

        /// <summary>
        /// Updates the Benefit.
        /// </summary>
        /// <param name="Benefit">The Benefit.</param>
        void UpdateCommentReply(Commentreply commentreply);
    }
}
