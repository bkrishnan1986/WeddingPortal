#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  12-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateCommentReplyProfile --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;
using Happy.Weddings.Vendor.Core.Entity;
using System;


namespace Happy.Weddings.Vendor.Core.Profile.CommentReplyProfile
{
    public class UpdateCommentReplyProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCommentReplyProfile"/> class.
        /// </summary>
        public UpdateCommentReplyProfile()
        {
            CreateMap<UpdateCommentReplyRequest, Commentreply>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }

}