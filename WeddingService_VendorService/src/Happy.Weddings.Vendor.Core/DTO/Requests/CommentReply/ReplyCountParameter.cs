using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply
{
    public class ReplyCountParameter
    {
        public int Value { get; set; }

        public bool IsForReply { get; set; }

        public bool IsForChildReply { get; set; }
    }
}
