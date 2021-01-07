#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | SubscriptionPlansResponse --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;

namespace Happy.Weddings.Vendor.Core.DTO.Responses.SubscriptionPlans
{
    /// <summary>
    /// This Class is used to map SubscriptionPlans Response
    /// </summary>

    public class SubscriptionPlansResponse
    {
        public int Id { get; set; }
        public int? ParentsubscriptionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Mode { get; set; }
        public string ModeName { get; set; }
        public decimal RegistrationFee { get; set; }
        public decimal ServiceFee { get; set; }
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
        public int Validity { get; set; }
        public int ValidityUnit { get; set; }
        public string ValidityUnitName { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public short Active { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
