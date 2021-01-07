using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ReviewComments
{
    public class ReplyCountParameter
    {
        public int Value { get; set; }

        public bool IsForReply { get; set; }

        public bool IsForChildReply { get; set; }
    }
}
