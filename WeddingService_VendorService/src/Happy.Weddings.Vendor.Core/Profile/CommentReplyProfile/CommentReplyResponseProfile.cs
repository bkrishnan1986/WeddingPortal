#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 12-Aug-2020 | ARAVIND PERUMAL S  | Created and implemented.
//             |                    | CommentReplyResponseProfile class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses.CommentReply;
using Happy.Weddings.Vendor.Core.Entity;

namespace Happy.Weddings.Vendor.Core.Profile.CommentReplyProfile
{
    public class CommentReplyResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentReplyResponseProfile"/> class.
        /// </summary>
        public CommentReplyResponseProfile()
        {
            CreateMap<Commentreply, ReplyDataResponse>();
            CreateMap<Commentreply, CommentReplyResponse>();
        }
    }
}
