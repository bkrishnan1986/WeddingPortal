#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  12-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | IOffersRepository --Interface
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.Domain;
using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;
using Happy.Weddings.Vendor.Core.DTO.Requests.Review;
using Happy.Weddings.Vendor.Core.Entity;
using System.Threading.Tasks;
using static Happy.Weddings.Vendor.Core.Entity.Commentreply;
using static Happy.Weddings.Vendor.Core.Entity.Review;
/// <summary>
/// This class is used to implement CRUD for the Reviews Repository
/// </summary>
namespace Happy.Weddings.Vendor.Core.Repository
{
    public interface IReplyCountRepository : IRepositoryBase<ReplyCount>
    {
        Task<ReplyCount> GetReplyCount(ReplyCountParameter replyCountParameter);
    }
}
