using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.CommentReply
{
    public class CommentReplyParametersRequest
    {
        public int value { get; set; }
        public int ApprovalStatus { get; set; }
        public bool IsForSingleCommentreply { get; set; }
        public bool IsForComment { get; set; }
        public bool IsForReply { get; set; }
        public bool IsForChildReply { get; set; }
    }
}
