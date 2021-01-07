#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  28-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateSubscriptionLocationRequest --class
//----------------------------------------------------------------------------------------------

#endregion File Header

namespace Happy.Weddings.Vendor.Core.DTO.Requests.SubscriptionLocation
{
    /// <summary>
    /// This Class is used to map Update SubscriptionPlan Request
    /// </summary>
    public class UpdateSubscriptionLocationRequest
    {
        public int SubscriptionId { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }
        public int PackageType { get; set; }
        public int? Mode { get; set; }
        public decimal? RegistrationFee { get; set; }
        public decimal? ServiceFee { get; set; }
        public int? CgstRatePercentage { get; set; }
        public decimal? Cgstamount { get; set; }
        public int? SgstRatePercentage { get; set; }
        public decimal? Sgstamount { get; set; }
        public int? IgstRatePercentage { get; set; }
        public decimal? Igstamount { get; set; }
        public int? GstRatePercentage { get; set; }
        public decimal? Gstamount { get; set; }
        public decimal? Cplamount { get; set; }
        public decimal? CommissionAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public short Active { get; set; }
        public int UpdatedBy { get; set; }
    }
}
