using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Multidetail
{
    public class MultidetailResponse
    {
        public int Id { get; set; }
        public int MultiCodeId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public short Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
