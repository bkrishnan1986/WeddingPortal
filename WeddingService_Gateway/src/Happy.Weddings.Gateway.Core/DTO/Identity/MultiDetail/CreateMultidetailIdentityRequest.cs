using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Identity.Multidetail
{
    public class CreateMultidetailIdentityRequest
    {
        public int MultiCodeId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
    }
}
