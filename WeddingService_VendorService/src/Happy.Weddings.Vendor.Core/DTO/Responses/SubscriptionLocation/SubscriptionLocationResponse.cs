#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  28-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionLocationResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionLocation
{
    /// <summary>
    /// This Class is used to map Subscription Offer Response
    /// </summary>

    public class SubscriptionLocationResponse
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int PackageType { get; set; }
        public string PackageName { get; set; }
        public int? Mode { get; set; }
        public string ModeName { get; set; }
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
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }             
    }
}
