using System;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.Utility
{
    public class UtilityResponse
    {
        public int Id { get; set; }
        public int? ServiceSubscriptionId { get; set; }
        public int? ServiceTopupId { get; set; }
        public int Benefit { get; set; }
        public string VendorId { get; set; }
        public int UtilityCount { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
