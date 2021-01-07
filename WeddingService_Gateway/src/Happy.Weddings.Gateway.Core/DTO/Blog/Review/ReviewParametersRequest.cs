using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Blog.Review
{
    public class ReviewParametersRequest
    {
        public int ReviewTypeId { get; set; }
        public int ReferenceId { get; set; }
        public int ApprovalStatusOrId { get; set; }
        public bool IsForSingReview { get; set; }
    }
}
